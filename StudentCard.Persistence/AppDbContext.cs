using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using StudentCard.Data.Common.Interfaces;
using StudentCard.Data.Emails;
using StudentCard.Data.HistoryLogs;
using StudentCard.Data.IpAddresses;
using StudentCard.Data.Students;
using StudentCard.Data.Users;
using StudentCard.Infrastructure.Interfaces;
using StudentCard.Infrastructure.Interfaces.Contexts;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace StudentCard.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        private readonly IUserContext userContext;


        public AppDbContext(
            IUserContext userContext,
            DbContextOptions<AppDbContext> options)
            : base(options)
        {
            this.userContext = userContext;
        }

        #region Users

        public DbSet<User> Users { get; set; }
        public DbSet<PasswordToken> PasswordTokens { get; set; }

        public DbSet<Email> Emails { get; set; }
        public DbSet<EmailAddressee> EmailAddressees { get; set; }

        #endregion

        #region Students

        public DbSet<Student> Students { get; set; }

        #endregion

        public DbSet<HistoryLog> HistoryLogs { get; set; }
        public DbSet<ExceptionIpAddress> ExceptionIpAddresses { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // Configure name mappings
                entity.SetTableName(entity.ClrType.Name.ToLower());

                if (typeof(IEntity).IsAssignableFrom(entity.ClrType))
                {
                    modelBuilder.Entity(entity.ClrType)
                        .HasKey(nameof(IEntity.Id));
                }

                if (typeof(IConcurrency).IsAssignableFrom(entity.ClrType))
                {
                    modelBuilder.Entity(entity.ClrType)
                        .Property(nameof(IConcurrency.Version))
                        .IsConcurrencyToken()
                        .HasDefaultValue(0);
                }

                entity.GetProperties()
                    .ToList()
                    .ForEach(e => e.SetColumnName(e.Name.ToLower()));

                entity.GetForeignKeys()
                    .Where(e => !e.IsOwnership && e.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(e => e.DeleteBehavior = DeleteBehavior.Restrict);
            }

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                   .Where(t => t.GetInterfaces().Any(gi =>
                       gi.IsGenericType
                       && gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)) && t.Namespace == "StudentCard.Persistence.Configurations")
                   .ToList();
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            return Database.BeginTransactionAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (typeof(IAuditable).IsAssignableFrom(entry.Entity.GetType()) && entry.State == EntityState.Added)
                {
                    var entity = entry.Entity as IAuditable;
                    entity.CreateDate = DateTime.Now;
                    entity.CreatorUserId = this.userContext.UserId;
                }

                if (typeof(IConcurrency).IsAssignableFrom(entry.Entity.GetType()) && entry.State == EntityState.Modified)
                {
                    var entity = entry.Entity as IConcurrency;
                    entity.Version++;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
