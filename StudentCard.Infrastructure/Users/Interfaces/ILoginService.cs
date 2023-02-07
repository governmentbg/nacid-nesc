using StudentCard.Application.Users.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Infrastructure.Users.Interfaces
{
    public interface ILoginService
    {
        Task<UserLoginInfoDto> Login(UserCredentialsDto model, CancellationToken cancellationToken);
    }
}
