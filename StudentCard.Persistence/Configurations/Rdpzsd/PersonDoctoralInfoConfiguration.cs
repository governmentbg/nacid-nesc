using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCard.Data.Rdpzsd.Students.Parts;

namespace StudentCard.Persistence.Configurations.Rdpzsd
{
    public class PersonDoctoralInfoConfiguration : IEntityTypeConfiguration<PersonDoctoralInfo>
    {
        public void Configure(EntityTypeBuilder<PersonDoctoralInfo> builder)
        {
            builder.HasOne(p => p.PersonDoctoral)
                   .WithOne(a => a.PartInfo)
                   .HasForeignKey<PersonDoctoralInfo>(p => p.Id);
        }
    }
}
