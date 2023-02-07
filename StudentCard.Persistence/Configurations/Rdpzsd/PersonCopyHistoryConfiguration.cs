using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCard.Data.Rdpzsd.Students.Parts.History;

namespace StudentCard.Persistence.Configurations.Rdpzsd
{
    public class PersonCopyHistoryConfiguration : IEntityTypeConfiguration<PassportCopyHistory>
    {
        public void Configure(EntityTypeBuilder<PassportCopyHistory> builder)
        {
            builder.HasOne(p => p.PersonBasicHistory)
                   .WithOne(a => a.PassportCopy)
                   .HasForeignKey<PassportCopyHistory>(p => p.Id);
        }
    }
}
