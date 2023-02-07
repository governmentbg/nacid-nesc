using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCard.Data.Rdpzsd.Students.Parts;

namespace StudentCard.Persistence.Configurations.Rdpzsd
{
    public class PersonStudentDuplicateDiplomaFileConfiguration : IEntityTypeConfiguration<PersonStudentDuplicateDiplomaFile>
    {
        public void Configure(EntityTypeBuilder<PersonStudentDuplicateDiplomaFile> builder)
        {
            builder.HasOne(p => p.DuplicateDiploma)
                   .WithOne(a => a.File)
                   .HasForeignKey<PersonStudentDuplicateDiplomaFile>(p => p.Id);
        }
    }
}
