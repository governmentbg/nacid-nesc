using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCard.Data.Rdpzsd.Students.Parts.History;

namespace StudentCard.Persistence.Configurations.Rdpzsd
{
    public class PersonBasicHistoryInfoConfiguration : IEntityTypeConfiguration<PersonBasicHistoryInfo>
    {
        public void Configure(EntityTypeBuilder<PersonBasicHistoryInfo> builder)
        {
            builder.HasOne(p => p.PersonBasicHistory)
                   .WithOne(a => a.PartInfo)
                   .HasForeignKey<PersonBasicHistoryInfo>(p => p.Id);
        }
    }
}
