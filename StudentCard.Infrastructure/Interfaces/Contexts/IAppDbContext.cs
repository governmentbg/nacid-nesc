using Microsoft.EntityFrameworkCore.Storage;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Infrastructure.Interfaces.Contexts
{
    public interface IAppDbContext : IBaseContext
    {
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
    }
}
