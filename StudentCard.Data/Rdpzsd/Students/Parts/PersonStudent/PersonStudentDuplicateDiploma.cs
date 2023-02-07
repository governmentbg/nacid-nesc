using StudentCard.Data.Rdpzsd.Base;
using System;

namespace StudentCard.Data.Rdpzsd.Students.Parts
{
    public class PersonStudentDuplicateDiploma : EntityVersion
    {
        public int PartId { get; set; }

        public int DuplicateStickerYear { get; set; }
        public string DuplicateDiplomaNumber { get; set; }
        public string DuplicateRegistrationDiplomaNumber { get; set; }
        public DateTime? DuplicateDiplomaDate { get; set; }

        public PersonStudentDuplicateDiplomaFile File { get; set; }

        public bool IsValid { get; set; } = true;
    }
}
