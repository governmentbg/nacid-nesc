using StudentCard.Application.Users.Dtos;
using StudentCard.Infrastructure.Interfaces.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Infrastructure.Users.Interfaces
{
    public interface IForgottenPasswordService<TContext>
        where TContext : IBaseContext
    {
        Task SendMail(EmailForgottenPasswordDto model, CancellationToken cancellationToken);
        Task RecoverPassword(ForgottenPasswordDto model, CancellationToken cancellationToken);
    }
}
