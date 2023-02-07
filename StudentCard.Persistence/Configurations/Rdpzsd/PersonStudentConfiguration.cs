using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCard.Data.Rdpzsd.Students.Parts;

namespace StudentCard.Persistence.Configurations.Rdpzsd
{
    public class PersonStudentConfiguration : IEntityTypeConfiguration<PersonStudent>
    {
        public void Configure(EntityTypeBuilder<PersonStudent> builder)
        {
            builder.HasMany(e => e.Semesters)
                .WithOne()
                .HasForeignKey(e => e.PartId);
        }
    }
}
