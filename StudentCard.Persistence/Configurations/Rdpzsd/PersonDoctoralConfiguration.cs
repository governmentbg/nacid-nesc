using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCard.Data.Rdpzsd.Students.Parts;

namespace StudentCard.Persistence.Configurations.Rdpzsd
{
    public class PersonDoctoralConfiguration : IEntityTypeConfiguration<PersonDoctoral>
    {
        public void Configure(EntityTypeBuilder<PersonDoctoral> builder)
        {
            builder.HasMany(e => e.Semesters)
                .WithOne()
                .HasForeignKey(e => e.PartId);

            builder.Property(e => e.PeDiplomaNumber)
                .HasMaxLength(25);

            builder.Property(e => e.PeInstitutionName)
                .HasMaxLength(100);

            builder.Property(e => e.PeSubordinateName)
                .HasMaxLength(100);

            builder.Property(e => e.PeSpecialityName)
                .HasMaxLength(100);

            builder.Property(e => e.PeAcquiredSpeciality)
                .HasMaxLength(100);

            builder.Property(e => e.PeRecognizedSpeciality)
                .HasMaxLength(100);

            builder.Property(e => e.PeRecognitionNumber)
                .HasMaxLength(30);
        }
    }
}
