using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentCard.Application.Users.Dtos;
using StudentCard.Data.Emails;
using StudentCard.Data.Nomenclatures.Constants;
using StudentCard.Data.Users;
using StudentCard.Data.Users.Enums;
using StudentCard.Infrastructure.Configurations;
using StudentCard.Infrastructure.DomainValidation;
using StudentCard.Infrastructure.DomainValidation.Enums;
using StudentCard.Infrastructure.Emails;
using StudentCard.Infrastructure.Interfaces.Contexts;
using StudentCard.Infrastructure.Users.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Infrastructure.Users
{
    public class ForgottenPasswordService<TContext> : IForgottenPasswordService<TContext>
        where TContext : IBaseContext
    {
        private readonly TContext context;
        private readonly IEmailService<TContext> emailService;
        private readonly IPasswordService passwordService;
        private readonly DomainValidationService validation;
        private readonly AuthConfiguration authConfig;

        public ForgottenPasswordService(
            TContext context,
            IEmailService<TContext> emailService,
            IPasswordService passwordService,
            DomainValidationService validation,
            IOptions<AuthConfiguration> options)
        {
            this.context = context;
            this.emailService = emailService;
            this.passwordService = passwordService;
            this.validation = validation;
            this.authConfig = options.Value;
        }

        public async Task SendMail(EmailForgottenPasswordDto model, CancellationToken cancellationToken)
        {
            var user = await this.context.Set<User>()
                    .AsNoTracking()
                    .SingleOrDefaultAsync(e => e.Email.Trim().ToLower() == model.Mail.Trim().ToLower());

            if (user == null)
            {
                this.validation.ThrowErrorMessage(UserErrorCode.UserInvalidEmail);
            }

            if (user.Status == UserStatus.Deactivated || user.Status == UserStatus.Inactive)
            {
                this.validation.ThrowErrorMessage(UserErrorCode.UserDeactivated);
            }

            PasswordToken passwordToken = new PasswordToken(user.Id, 20160);
            this.context.Set<PasswordToken>().Add(passwordToken);

            var payload = new
            {
                Username = user.Username,
                ForgottenPasswordLink = $"{authConfig.Issuer}/passwordRecovery?token={passwordToken.Value}"
            };

            Email email = await this.emailService.ComposeEmailAsync(EmailTypeAlias.FORGOTTEN_PASSWORD, payload, user.Email);
            this.context.Set<Email>().Add(email);
            await this.context.SaveChangesAsync(cancellationToken);
        }

        public async Task RecoverPassword(ForgottenPasswordDto model, CancellationToken cancellationToken)
        {
            if (model.NewPassword != model.NewPasswordAgain)
            {
                this.validation.ThrowErrorMessage(UserErrorCode.UserChangePasswordNewPasswordsMismatch);
            }

            if (string.IsNullOrWhiteSpace(model.Token) || string.IsNullOrWhiteSpace(model.NewPassword))
            {
                this.validation.ThrowErrorMessage(SystemErrorCode.SystemIncorrectParameters);
            }

            PasswordToken passwordToken = await this.context.Set<PasswordToken>()
                .Include(e => e.User)
                .SingleOrDefaultAsync(e => e.Value == model.Token, cancellationToken);

            if (passwordToken.IsUsed)
            {
                this.validation.ThrowErrorMessage(UserErrorCode.NewPasswordRecoveryTokenAlreadyUsed);
            }

            if (passwordToken.ExpirationTime < DateTime.UtcNow)
            {
                this.validation.ThrowErrorMessage(UserErrorCode.NewPasswordRecoveryTokenExpired);
            }

            passwordToken.Use();

            string salt = this.passwordService.GenerateSalt(128);
            string hash = this.passwordService.HashPassword(model.NewPassword, salt);
            passwordToken.User.ChangePassword(hash, salt);
            await this.context.SaveChangesAsync(cancellationToken);
        }
    }
}
