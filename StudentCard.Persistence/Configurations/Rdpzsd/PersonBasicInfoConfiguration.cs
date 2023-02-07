using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCard.Data.Rdpzsd.Students.Parts;

namespace StudentCard.Persistence.Configurations.Rdpzsd
{
    public class PersonBasicInfoConfiguration : IEntityTypeConfiguration<PersonBasicInfo>
    {
        public void Configure(EntityTypeBuilder<PersonBasicInfo> builder)
        {
            builder.HasOne(p => p.PersonBasic)
                   .WithOne(a => a.PartInfo)
                   .HasForeignKey<PersonBasicInfo>(p => p.Id);
        }
    }
}
