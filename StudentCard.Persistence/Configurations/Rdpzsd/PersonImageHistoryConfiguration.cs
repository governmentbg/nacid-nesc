using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCard.Data.Rdpzsd.Students.Parts.History;

namespace StudentCard.Persistence.Configurations.Rdpzsd
{
    public class PersonImageHistoryConfiguration : IEntityTypeConfiguration<PersonImageHistory>
    {
        public void Configure(EntityTypeBuilder<PersonImageHistory> builder)
        {
            builder.HasOne(p => p.PersonBasicHistory)
                   .WithOne(a => a.PersonImage)
                   .HasForeignKey<PersonImageHistory>(p => p.Id);
        }
    }
}
