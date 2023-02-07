using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCard.Data.Rdpzsd.Students;
using StudentCard.Data.Rdpzsd.Students.Parts;
using StudentCard.Data.Rdpzsd.Students.Parts.PersonSecondary;

namespace StudentCard.Persistence.Configurations.Rdpzsd
{
    public class PersonLotConfiguration : IEntityTypeConfiguration<PersonLot>
    {
        public void Configure(EntityTypeBuilder<PersonLot> builder)
        {
            builder.HasIndex(e => e.Uan)
                .IsUnique();

            builder.HasOne(e => e.PersonBasic)
                .WithOne(c => c.Lot)
                .HasForeignKey<PersonBasic>();

            builder.HasOne(e => e.PersonSecondary)
               .WithOne(c => c.Lot)
               .HasForeignKey<PersonSecondary>();

            builder.HasMany(e => e.PersonStudents)
                .WithOne(c => c.Lot)
                .HasForeignKey(e => e.LotId);

            builder.HasMany(e => e.PersonDoctorals)
                .WithOne(c => c.Lot)
                .HasForeignKey(e => e.LotId);
        }
    }
}
