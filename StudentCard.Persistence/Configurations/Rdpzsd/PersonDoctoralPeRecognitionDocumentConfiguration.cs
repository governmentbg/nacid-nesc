using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCard.Data.Rdpzsd.Students.Parts;

namespace StudentCard.Persistence.Configurations.Rdpzsd
{
    public class PersonDoctoralPeRecognitionDocumentConfiguration : IEntityTypeConfiguration<PersonDoctoralPeRecognitionDocument>
    {
        public void Configure(EntityTypeBuilder<PersonDoctoralPeRecognitionDocument> builder)
        {
            builder.HasOne(e => e.PersonDoctoral)
                .WithOne(s => s.PeRecognitionDocument)
                .HasForeignKey<PersonDoctoralPeRecognitionDocument>(p => p.Id);
        }
    }
}
