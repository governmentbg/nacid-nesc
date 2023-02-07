using System;

namespace StudentCard.Application.Students.Dtos
{
    public class StudentDto
    {
        public string Email { get; set; }

        public string UAN { get; set; }

        public int ExternalId { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
