using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCard.Data.Rdpzsd.Students.Parts;

namespace StudentCard.Persistence.Configurations.Rdpzsd
{
    public class PersonDoctoralSemesterRelocatedFileConfiguration : IEntityTypeConfiguration<PersonDoctoralSemesterRelocatedFile>
    {
        public void Configure(EntityTypeBuilder<PersonDoctoralSemesterRelocatedFile> builder)
        {
            builder.HasOne(e => e.PersonDoctoralSemester)
                    .WithOne(a => a.SemesterRelocatedFile)
                    .HasForeignKey<PersonDoctoralSemesterRelocatedFile>(p => p.Id);
        }
    }
}
