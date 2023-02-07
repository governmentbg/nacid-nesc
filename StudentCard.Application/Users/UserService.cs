using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentCard.Application.Users.Dtos;
using StudentCard.Application.Users.Interfaces;
using StudentCard.Application.Users.Models;
using StudentCard.Data.Emails;
using StudentCard.Data.Nomenclatures.Constants;
using StudentCard.Data.Rdpzsd.Students;
using StudentCard.Data.Users;
using StudentCard.Infrastructure.Configurations;
using StudentCard.Infrastructure.DomainValidation;
using StudentCard.Infrastructure.DomainValidation.Enums;
using StudentCard.Infrastructure.Emails;
using StudentCard.Infrastructure.Interfaces;
using StudentCard.Infrastructure.Interfaces.Contexts;
using StudentCard.Infrastructure.Users.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Application.Users
{
    public class UserService : IUserService
    {
        private readonly IAppDbContext context;
        private readonly DomainValidationService validation;
        private readonly IEmailService<IAppDbContext> emailService;
        private readonly IUserContext userContext;
        private readonly IPasswordService passwordService;
        private readonly IRdpzsdDbContext rdpzsdDbContext;
        private readonly AuthConfiguration authConfig;

        public UserService(
            IAppDbContext context,
            DomainValidationService validation,
            IEmailService<IAppDbContext> emailService,
            IOptions<AuthConfiguration> options,
            IUserContext userContext,
            IPasswordService passwordService,
            IRdpzsdDbContext rdpzsdDbContext
            )
        {
            this.context = context;
            this.validation = validation;
            this.emailService = emailService;
            this.userContext = userContext;
            this.passwordService = passwordService;
            this.rdpzsdDbContext = rdpzsdDbContext;
            this.authConfig = options.Value;
        }

        public async Task ChangeUserPassword(ChangePasswordDto dto, CancellationToken cancellationToken)
        {
            if (dto.NewPassword != dto.NewPasswordAgain)
            {
                this.validation.ThrowErrorMessage(UserErrorCode.UserChangePasswordNewPasswordsMismatch);
            }

            var user = await this.CompareUserPasswords(dto.OldPassword, cancellationToken);

            string newPasswordSalt = this.passwordService.GenerateSalt(128);
            string newPasswordHash = this.passwordService.HashPassword(dto.NewPassword, newPasswordSalt);
            user.ChangePassword(newPasswordHash, newPasswordSalt);

            await this.context.SaveChangesAsync(cancellationToken);
        }

        public async Task SendUserChangeEmailAddressLink(ChangeEmailAddressDto dto, CancellationToken cancellationToken)
        {
            if (dto.NewEmailAddress.Trim().ToLower() != dto.NewEmailAddressAgain.Trim().ToLower())
            {
                this.validation.ThrowErrorMessage(UserErrorCode.UserChangeEmailNewEmailsMismatch);
            }

            var user = await this.CompareUserPasswords(dto.Password, cancellationToken);

            var isEmailTakenInStudentCard = await this.CheckIsEmailTakenInStudentCard(dto.NewEmailAddress, cancellationToken);
            var isEmailTakenInRdpzsd = await this.CheckIsEmailTakenInRdpzsd(dto.NewEmailAddress, cancellationToken);
            if (isEmailTakenInStudentCard || isEmailTakenInRdpzsd)
            {
                this.validation.ThrowErrorMessage(UserErrorCode.UserEmailTaken);
            }

            user.NewEmailRequest = dto.NewEmailAddress;

            await this.UseOldTokens(user.Id, cancellationToken);

            await this.SendEmail(user.Id, EmailTypeAlias.USER_CHANGE_EMAIL_ADDRESS, dto.NewEmailAddress, cancellationToken);
        }

        public async Task SendEmail(int userId, string emailType, string emailReceiver, CancellationToken cancellationToken)
        {
            PasswordToken passwordToken = new(userId, 20160);
            this.context.Set<PasswordToken>().Add(passwordToken);

            var payload = new
            {
                ActivationLink = "",
                Username = ""
            };

            if (emailType == EmailTypeAlias.USER_ACTIVATION)
            {
                payload = new
                {
                    ActivationLink = $"{this.authConfig.Issuer}/user/activation?token={passwordToken.Value}",
                    Username = emailReceiver
                };
            }
            else if (emailType == EmailTypeAlias.USER_CHANGE_EMAIL_ADDRESS)
            {
                payload = new
                {
                    ActivationLink = $"{this.authConfig.Issuer}/user/changeEmail?token={passwordToken.Value}",
                    Username = ""
                };
            }

            Email email = await this.emailService.ComposeEmailAsync(emailType, payload, emailReceiver);
            this.context.Set<Email>().Add(email);

            await this.context.SaveChangesAsync(cancellationToken);
        }

        private async Task<bool> CheckIsEmailTakenInStudentCard(string emailToCheck, CancellationToken cancellationToken)
        {
            return await this.context.Set<User>()
                    .AnyAsync(e => e.Email.Trim().ToLower() == emailToCheck.Trim().ToLower(), cancellationToken);
        }

        private async Task<bool> CheckIsEmailTakenInRdpzsd(string emailToCheck, CancellationToken cancellationToken)
        {
            return await this.rdpzsdDbContext.Set<PersonLot>()
                    .AnyAsync(e => e.PersonBasic.Email.Trim().ToLower() == emailToCheck.Trim().ToLower(), cancellationToken);
        }

        private async Task UseOldTokens(int userId, CancellationToken cancellationToken)
        {
            var oldTokens = await this.context.Set<PasswordToken>()
                .Where(e => !e.IsUsed && e.UserId == userId)
                .ToListAsync(cancellationToken);

            foreach (var oldToken in oldTokens)
            {
                oldToken.Use();
            }

            await this.context.SaveChangesAsync(cancellationToken);
        }

        private async Task<User> CompareUserPasswords(string passwordToCompare, CancellationToken cancellationToken)
        {
            var user = await this.context.Set<User>()
                    .SingleAsync(e => e.Id == this.userContext.UserId, cancellationToken);

            if (!this.passwordService.VerifyHashedPassword(user.Password, passwordToCompare, user.PasswordSalt))
            {
                this.validation.ThrowErrorMessage(UserErrorCode.UserInvalidPassword);
            }

            return user;
        }

        public RegiXGRAOResponse ResponseNamesToFirstUpper(RegiXGRAOResponse response)
        { 
            response.LatinNames.FirstName = response.LatinNames.FirstName[0].ToString().ToUpper() + response.LatinNames.FirstName.Substring(1).ToLower();
            response.LatinNames.SurName = response.LatinNames.SurName[0].ToString().ToUpper() + response.LatinNames.SurName.Substring(1).ToLower();
            response.LatinNames.FamilyName = response.LatinNames.FamilyName[0].ToString().ToUpper() + response.LatinNames.FamilyName.Substring(1).ToLower();

            response.PersonNames.FirstName = response.PersonNames.FirstName[0].ToString().ToUpper() + response.PersonNames.FirstName.Substring(1).ToLower();
            response.PersonNames.SurName = response.PersonNames.SurName[0].ToString().ToUpper() + response.PersonNames.SurName.Substring(1).ToLower();
            response.PersonNames.FamilyName = response.PersonNames.FamilyName[0].ToString().ToUpper() + response.PersonNames.FamilyName.Substring(1).ToLower();

            return response;
        } 
    }
}
