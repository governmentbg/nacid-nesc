using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCard.Data.Students;

namespace StudentCard.Persistence.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .HasOne(e => e.User)
                .WithOne()
                .HasForeignKey<Student>(e => e.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
