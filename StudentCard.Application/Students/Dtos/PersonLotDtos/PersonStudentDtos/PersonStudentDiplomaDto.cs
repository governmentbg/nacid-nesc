using StudentCard.Data.Rdpzsd.Students.Parts;
using System;

namespace StudentCard.Application.Students.Dtos.PersonLotDtos.PersonStudentDtos
{
    public class PersonStudentDiplomaDto
    {
        public string DiplomaNumber { get; set; }
        public string RegistrationDiplomaNumber { get; set; }
        public DateTime? DiplomaDate { get; set; }

        public PersonStudentDiplomaFile File { get; set; }

        public bool IsValid { get; set; } = true;
    }
}
