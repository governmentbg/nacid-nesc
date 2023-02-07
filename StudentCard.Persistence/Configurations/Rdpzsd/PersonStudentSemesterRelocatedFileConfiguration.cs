using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCard.Data.Rdpzsd.Students.Parts;

namespace StudentCard.Persistence.Configurations.Rdpzsd
{
    public class PersonStudentSemesterRelocatedFileConfiguration : IEntityTypeConfiguration<PersonStudentSemesterRelocatedFile>
    {
        public void Configure(EntityTypeBuilder<PersonStudentSemesterRelocatedFile> builder)
        {
            builder.HasOne(p => p.PersonStudentSemester)
                   .WithOne(a => a.SemesterRelocatedFile)
                   .HasForeignKey<PersonStudentSemesterRelocatedFile>(p => p.Id);
        }
    }
}
