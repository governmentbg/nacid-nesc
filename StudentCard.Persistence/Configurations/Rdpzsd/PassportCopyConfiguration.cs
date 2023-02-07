using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCard.Data.Rdpzsd.Students.Parts;

namespace StudentCard.Persistence.Configurations.Rdpzsd
{
    public class PassportCopyConfiguration : IEntityTypeConfiguration<PassportCopy>
    {
        public void Configure(EntityTypeBuilder<PassportCopy> builder)
        {
            builder.HasOne(p => p.PersonBasic)
                   .WithOne(a => a.PassportCopy)
                   .HasForeignKey<PassportCopy>(p => p.Id);
        }
    }
}
