using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCard.Data.Rdpzsd.Students.Parts.History;

namespace StudentCard.Persistence.Configurations.Rdpzsd
{
    public class PersonBasicHistoryConfiguration : IEntityTypeConfiguration<PersonBasicHistory>
    {
        public void Configure(EntityTypeBuilder<PersonBasicHistory> builder)
        {
            builder.Property(e => e.Uin)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnType("character varying");

            builder.Property(e => e.ForeignerNumber)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnType("character varying");

            builder.Property(e => e.FirstName)
                .HasMaxLength(50);

            builder.Property(e => e.MiddleName)
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .HasMaxLength(50);

            builder.Property(e => e.FirstNameAlt)
                .HasMaxLength(50);

            builder.Property(e => e.MiddleNameAlt)
                .HasMaxLength(50);

            builder.Property(e => e.LastNameAlt)
                .HasMaxLength(50);

            builder.Property(e => e.OtherNames)
                .HasMaxLength(100);

            builder.Property(e => e.OtherNamesAlt)
                .HasMaxLength(100);

            builder.Property(e => e.ForeignerBirthSettlement)
                .HasMaxLength(255);

            builder.Property(e => e.Email)
                .HasMaxLength(50);

            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(18);

            builder.Property(e => e.ResidenceAddress)
                .HasMaxLength(255);

            builder.Property(e => e.IdnNumber)
                .HasMaxLength(50);

            builder.Property(e => e.PostCode)
                .HasMaxLength(4);
        }
    }
}
