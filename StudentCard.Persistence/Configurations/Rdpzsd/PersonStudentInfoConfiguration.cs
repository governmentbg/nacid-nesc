using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCard.Data.Rdpzsd.Students.Parts;

namespace StudentCard.Persistence.Configurations.Rdpzsd
{
    public class PersonStudentInfoConfiguration : IEntityTypeConfiguration<PersonStudentInfo>
    {
        public void Configure(EntityTypeBuilder<PersonStudentInfo> builder)
        {
            builder.HasOne(p => p.PersonStudent)
                   .WithOne(a => a.PartInfo)
                   .HasForeignKey<PersonStudentInfo>(p => p.Id);
        }
    }
}
