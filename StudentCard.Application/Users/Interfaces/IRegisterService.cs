using StudentCard.Application.Users.Models;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Application.Users.Interfaces
{
    public interface IRegisterService
    {
        Task<string> Register(UserRegisterInfoDto model, CancellationToken cancellationToken);
    }
}
