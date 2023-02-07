using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCard.Data.Rdpzsd.Nomenclatures;

namespace StudentCard.Persistence.Configurations.Rdpzsd
{
    public class InstitutionConfiguration : IEntityTypeConfiguration<Institution>
    {
        public void Configure(EntityTypeBuilder<Institution> builder)
        {
            builder.HasOne(e => e.Parent)
                .WithMany()
                .HasForeignKey(e => e.ParentId);

            builder.HasOne(e => e.Root)
                .WithMany()
                .HasForeignKey(e => e.RootId);
        }
    }
}
