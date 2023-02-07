using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Infrastructure.Interfaces.Contexts
{
    public interface IBaseContext
    {
        DbSet<T> Set<T>() where T : class;
        EntityEntry<TEntity> Entry<TEntity>([NotNull] TEntity entity) where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
