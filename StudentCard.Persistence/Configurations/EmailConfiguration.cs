using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCard.Data.Emails;

namespace StudentCard.Persistence.StudentCard.Configurations
{
    public class EmailConfiguration : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder
                .HasMany(e => e.Addressees)
                .WithOne(a => a.Email)
                .HasForeignKey(a => a.EmailId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
