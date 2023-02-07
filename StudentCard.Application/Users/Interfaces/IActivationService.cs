using StudentCard.Application.Users.Dtos;
using StudentCard.Data.Emails.Enums;
using StudentCard.Data.Users;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Application.Users.Interfaces
{
    public interface IActivationService
    {
        Task SendActivationLink(int userId, CancellationToken cancellationToken);
        Task<PasswordToken> CheckToken(string token,TypeOfActivation typeOfActivation, CancellationToken cancellationToken);
        Task ActivateUser(UserActivationDto model, CancellationToken cancellationToken);
        Task ActivateUserNewEmail(UserActivationNewEmailAddressDto model, CancellationToken cancellationToken);
    }
}
