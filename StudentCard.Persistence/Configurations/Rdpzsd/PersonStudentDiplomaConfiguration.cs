using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCard.Data.Rdpzsd.Students.Parts;

namespace StudentCard.Persistence.Configurations.Rdpzsd
{
    public class PersonStudentDiplomaConfiguration : IEntityTypeConfiguration<PersonStudentDiploma>
    {
        public void Configure(EntityTypeBuilder<PersonStudentDiploma> builder)
        {
            builder.HasOne(p => p.PersonStudent)
                   .WithOne(a => a.Diploma)
                   .HasForeignKey<PersonStudentDiploma>(p => p.Id);

            builder.Property(e => e.DiplomaNumber)
                .HasMaxLength(30);

            builder.Property(e => e.RegistrationDiplomaNumber)
                .HasMaxLength(25);
        }
    }
}
