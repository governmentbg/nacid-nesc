using StudentCard.Application.Users.Dtos;
using StudentCard.Application.Users.Models;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Application.Users.Interfaces
{
    public interface IUserService
    {
        Task ChangeUserPassword(ChangePasswordDto dto, CancellationToken cancellationToken);
        Task SendUserChangeEmailAddressLink(ChangeEmailAddressDto dto, CancellationToken cancellationToken);
        Task SendEmail(int userId, string emailType, string emailReceiver, CancellationToken cancellationToken);
        RegiXGRAOResponse ResponseNamesToFirstUpper(RegiXGRAOResponse response);
    }
}
