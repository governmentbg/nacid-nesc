using Microsoft.EntityFrameworkCore;
using StudentCard.Application.Users.Dtos;
using StudentCard.Data.Rdpzsd.Students;
using StudentCard.Data.Rdpzsd.Students.Parts;
using StudentCard.Data.Students;
using StudentCard.Data.Users;
using StudentCard.Data.Users.Enums;
using StudentCard.Infrastructure.DomainValidation;
using StudentCard.Infrastructure.DomainValidation.Enums;
using StudentCard.Infrastructure.Interfaces.Contexts;
using StudentCard.Infrastructure.Users.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Infrastructure.Users
{
    public class LoginService : ILoginService
    {
        private readonly IAppDbContext context;
        private readonly IPasswordService passwordService;
        private readonly IJWTService jwtService;
        private readonly DomainValidationService validation;
        private readonly IRdpzsdDbContext rdpzsdDbContext;

        public LoginService(
            IAppDbContext context,
            IPasswordService passwordService,
            DomainValidationService validation,
            IJWTService jwtService,
            IRdpzsdDbContext rdpzsdDbContext)
        {
            this.context = context;
            this.passwordService = passwordService;
            this.validation = validation;
            this.jwtService = jwtService;
            this.rdpzsdDbContext = rdpzsdDbContext;
        }

        public async Task<UserLoginInfoDto> Login(UserCredentialsDto model, CancellationToken cancellationToken)
        {
            var user = await this.Authenticate(model, cancellationToken);

            var student = await this.context.Set<Student>()
                .Where(s => s.Id == user.Id)
                .SingleOrDefaultAsync(cancellationToken);

            var result = new UserLoginInfoDto
            {
                Token = this.jwtService.CreateToken(user.Id, user.Username),
                Username = user.Username
            };

            var personBasic = await this.rdpzsdDbContext.Set<PersonLot>()
                .Where(pl => pl.Uan == student.UAN)
                .Select(pl => pl.PersonBasic)
                .SingleOrDefaultAsync(cancellationToken);

            result.FullName = personBasic.FirstName + " " + personBasic.LastName;
            result.FullNameAlt = personBasic.FirstNameAlt + " " + personBasic.LastNameAlt;

            return result;
        }

        private async Task<User> Authenticate(UserCredentialsDto model, CancellationToken cancellationToken)
        {
            var user = await this.context.Set<User>()
                    .AsNoTracking()
                    .SingleOrDefaultAsync(u => u.Username.Trim().ToLower() == model.Username.Trim().ToLower(), cancellationToken);

            if (user == null)
            {
                this.validation.ThrowErrorMessage(UserErrorCode.UserInvalidCredentials);
            }

            if (user.Status == UserStatus.Deactivated)
            {
                this.validation.ThrowErrorMessage(UserErrorCode.UserDeactivated);
            }

            bool isSamePassword = this.passwordService.VerifyHashedPassword(user.Password, model.Password, user.PasswordSalt);
            if (!isSamePassword)
            {
                this.validation.ThrowErrorMessage(UserErrorCode.UserInvalidCredentials);
            }

            return user;
        }
    }
}
