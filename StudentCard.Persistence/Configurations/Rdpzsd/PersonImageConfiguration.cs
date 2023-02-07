using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCard.Data.Rdpzsd.Students.Parts;

namespace StudentCard.Persistence.Configurations.Rdpzsd
{
    public class PersonImageConfiguration : IEntityTypeConfiguration<PersonImage>
    {
        public void Configure(EntityTypeBuilder<PersonImage> builder)
        {
            builder.HasOne(p => p.PersonBasic)
                   .WithOne(a => a.PersonImage)
                   .HasForeignKey<PersonImage>(p => p.Id);
        }
    }
}
