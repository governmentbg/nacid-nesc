using Microsoft.EntityFrameworkCore;
using StudentCard.Data.Logs;

namespace StudentCard.Persistence
{
    public abstract partial class LogContext<TContext> : DbContext
        where TContext : DbContext
    {
        protected LogContext(DbContextOptions<TContext> options)
            : base(options)
        {
        }

        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.ClrType.Name.ToLower());

                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.Name.ToLower());
                }
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
