using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCard.Data.Rdpzsd.Students.Parts;

namespace StudentCard.Persistence.Configurations.Rdpzsd
{
    public class PersonStudentDiplomaFileConfiguration : IEntityTypeConfiguration<PersonStudentDiplomaFile>
    {
        public void Configure(EntityTypeBuilder<PersonStudentDiplomaFile> builder)
        {
            builder.HasOne(p => p.Diploma)
                   .WithOne(a => a.File)
                   .HasForeignKey<PersonStudentDiplomaFile>(p => p.Id);
        }
    }
}
