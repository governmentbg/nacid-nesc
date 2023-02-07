using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentCard.Application.Students.Interfaces;
using StudentCard.Application.Users.Dtos;
using StudentCard.Application.Users.Interfaces;
using StudentCard.Data.Emails;
using StudentCard.Data.Emails.Enums;
using StudentCard.Data.Nomenclatures.Constants;
using StudentCard.Data.Rdpzsd.Students;
using StudentCard.Data.Students;
using StudentCard.Data.Users;
using StudentCard.Infrastructure.Configurations;
using StudentCard.Infrastructure.DomainValidation;
using StudentCard.Infrastructure.DomainValidation.Enums;
using StudentCard.Infrastructure.Emails;
using StudentCard.Infrastructure.Interfaces.Contexts;
using StudentCard.Infrastructure.Users.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Application.Users
{
    public class ActivationService : IActivationService
    {
        private readonly IAppDbContext context;
        private readonly IPasswordService passwordService;
        private readonly IEmailService<IAppDbContext> emailService;
        private readonly DomainValidationService validation;
		private readonly IRdpzsdDbContext rdpzsdDbContext;
		private readonly IRdpzsdService rdpzsdService;
		private readonly AuthConfiguration authConfig;

        public ActivationService(
            IAppDbContext context,
            IPasswordService passwordService,
            IEmailService<IAppDbContext> emailService,
            DomainValidationService validation,
            IOptions<AuthConfiguration> options,
            IRdpzsdDbContext rdpzsdDbContext,
            IRdpzsdService rdpzsdService
            )
        {
            this.context = context;
            this.passwordService = passwordService;
            this.emailService = emailService;
            this.validation = validation;
			this.rdpzsdDbContext = rdpzsdDbContext;
			this.rdpzsdService = rdpzsdService;
			this.authConfig = options.Value;
        }

        public async Task SendActivationLink(int userId, CancellationToken cancellationToken)
        {
            var user = await this.context.Set<User>()
                    .AsNoTracking()
                    .SingleOrDefaultAsync(e => e.Id == userId, cancellationToken);

            var oldTokens = await this.context.Set<PasswordToken>()
                .Where(e => !e.IsUsed && e.UserId == userId)
                .ToListAsync(cancellationToken);

            foreach (var oldToken in oldTokens)
            {
                oldToken.Use();
            }

            await this.context.SaveChangesAsync(cancellationToken);

            PasswordToken passwordToken = new PasswordToken(user.Id, 20160);
            this.context.Set<PasswordToken>().Add(passwordToken);

            var payload = new
            {
                ActivationLink = $"{authConfig.Issuer}/user/activation?token={passwordToken.Value}",
            };

            Email email = await this.emailService.ComposeEmailAsync(EmailTypeAlias.USER_ACTIVATION, payload, user.Email);
            this.context.Set<Email>().Add(email);

            await this.context.SaveChangesAsync(cancellationToken);
        }

        public async Task<PasswordToken> CheckToken(string token, TypeOfActivation typeOfActivation, CancellationToken cancellationToken)
        {
            PasswordToken passwordToken = await this.GetPasswordToken(token, cancellationToken);

            if (passwordToken.IsUsed)
            {
                if (typeOfActivation == TypeOfActivation.NewEmailActivation)
                {
                    this.validation.ThrowErrorMessage(UserErrorCode.NewEmailActivationTokenAlreadyUsed);
                }
                else if(typeOfActivation == TypeOfActivation.UserActivation)
                {
                    this.validation.ThrowErrorMessage(UserErrorCode.UserActivationTokenAlreadyUsed);
                }
                else
                {
                    this.validation.ThrowErrorMessage(UserErrorCode.NewPasswordRecoveryTokenAlreadyUsed);
                }
            }

            if (passwordToken.ExpirationTime < DateTime.UtcNow)
            {
                if (typeOfActivation == TypeOfActivation.NewEmailActivation)
                {
                    this.validation.ThrowErrorMessage(UserErrorCode.NewEmailActivationTokenExpired);
                }
                else if (typeOfActivation == TypeOfActivation.UserActivation)
                {
                    this.validation.ThrowErrorMessage(UserErrorCode.UserActivationTokenExpired);
                }
                else
                {
                    this.validation.ThrowErrorMessage(UserErrorCode.NewPasswordRecoveryTokenExpired);
                }
            }

            return passwordToken;
        }

        public async Task ActivateUser(UserActivationDto model, CancellationToken cancellationToken)
        {
            var passwordToken = await this.CheckToken(model.Token, TypeOfActivation.UserActivation, cancellationToken);

            var areBirthDatesEqual = await this.CheckStudentBirthDate(passwordToken.User.Id, model.BirthDate, cancellationToken);
            if (!areBirthDatesEqual)
            {
                this.validation.ThrowErrorMessage(UserErrorCode.UserIncorrectBirthDate);
            }

            passwordToken.Use();

            string salt = this.passwordService.GenerateSalt(128);
            string hash = this.passwordService.HashPassword(model.Password, salt);
            passwordToken.User.Activate(hash, salt);

            await this.context.SaveChangesAsync(cancellationToken);
        }

        public async Task ActivateUserNewEmail(UserActivationNewEmailAddressDto model, CancellationToken cancellationToken)
        {
            var passwordToken = await this.CheckToken(model.Token, TypeOfActivation.NewEmailActivation, cancellationToken);

            var areBirthDatesEqual = await this.CheckStudentBirthDate(passwordToken.User.Id, model.BirthDate, cancellationToken);
            if (!areBirthDatesEqual)
            {
                this.validation.ThrowErrorMessage(UserErrorCode.UserIncorrectBirthDate);
            }

            passwordToken.Use();

            var student = await this.context.Set<Student>()
                .Where(s => s.Id == passwordToken.UserId)
                .Include(s => s.User)
                .SingleOrDefaultAsync(cancellationToken);

            student.ChangeEmail(passwordToken.User.NewEmailRequest);
            await this.rdpzsdService.UpdateEmail(student.UAN, passwordToken.User.NewEmailRequest);

            student.User.NewEmailRequest = null;
            await this.context.SaveChangesAsync(cancellationToken);
        }

        private async Task<bool> CheckStudentBirthDate(int? studentId, DateTime birthDate, CancellationToken cancellationToken)
        {
            var student = await this.context.Set<Student>()
                .SingleOrDefaultAsync(s => s.Id == studentId, cancellationToken);

            return student.BirthDate.Date == birthDate.ToLocalTime().Date;
        }
        private async Task<PasswordToken> GetPasswordToken(string token, CancellationToken cancellationToken)
        {
            return await this.context.Set<PasswordToken>()
                .Include(e => e.User)
                .SingleOrDefaultAsync(e => e.Value == token, cancellationToken);
        }
    }
}
