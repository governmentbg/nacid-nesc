using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCard.Data.Rdpzsd.Students.Parts;

namespace StudentCard.Persistence.Configurations.Rdpzsd
{
    public class PersonStudentPeRecognitionDocumentConfiguration : IEntityTypeConfiguration<PersonStudentPeRecognitionDocument>
    {
        public void Configure(EntityTypeBuilder<PersonStudentPeRecognitionDocument> builder)
        {
            builder.HasOne(e => e.PersonStudent)
                .WithOne(s => s.PeRecognitionDocument)
                .HasForeignKey<PersonStudentPeRecognitionDocument>(p => p.Id);
        }
    }
}
