using StudentCard.Data.Rdpzsd.Base;
using System;

namespace StudentCard.Data.Rdpzsd.Students.Parts
{
    public class PersonStudentDiploma : EntityVersion
    {
        [Skip]
        public PersonStudent PersonStudent { get; set; }

        public string DiplomaNumber { get; set; }
        public string RegistrationDiplomaNumber { get; set; }
        public DateTime? DiplomaDate { get; set; }

        public PersonStudentDiplomaFile File { get; set; }

        public bool IsValid { get; set; } = true;
    }
}
