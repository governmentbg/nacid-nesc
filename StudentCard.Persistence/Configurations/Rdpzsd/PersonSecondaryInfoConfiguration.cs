using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCard.Data.Rdpzsd.Students.Parts.PersonSecondary;

namespace StudentCard.Persistence.Configurations.Rdpzsd
{
    public class PersonSecondaryInfoConfiguration : IEntityTypeConfiguration<PersonSecondaryInfo>
    {
        public void Configure(EntityTypeBuilder<PersonSecondaryInfo> builder)
        {
            builder.HasOne(p => p.PersonSecondary)
                   .WithOne(a => a.PartInfo)
                   .HasForeignKey<PersonSecondaryInfo>(p => p.Id);
        }
    }
}
