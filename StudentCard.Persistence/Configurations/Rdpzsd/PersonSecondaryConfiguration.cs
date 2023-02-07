using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCard.Data.Rdpzsd.Students.Parts.PersonSecondary;

namespace StudentCard.Persistence.Configurations.Rdpzsd
{
    public class PersonSecondaryConfiguration : IEntityTypeConfiguration<PersonSecondary>
    {
        public void Configure(EntityTypeBuilder<PersonSecondary> builder)
        {
            builder.Property(e => e.DiplomaNumber)
                   .HasMaxLength(100);

            builder.Property(e => e.ForeignSchoolName)
                   .HasMaxLength(180);

            builder.Property(e => e.Profession)
                   .HasMaxLength(200);

            builder.Property(e => e.RecognitionNumber)
                   .HasMaxLength(30);

            builder.Property(e => e.MissingSchoolName)
                   .HasMaxLength(180);
        }
    }
}
