using StudentCard.Application.Students.Dtos.PersonLotDtos.BaseDtos;
using StudentCard.Infrastructure.Helpers.Dtos;
using System.Collections.Generic;

namespace StudentCard.Application.Students.Dtos.PersonLotDtos.PersonStudentDtos
{
    public class PersonStudentDto : BaseStudentDoctoralDto
    {
        public string FacultyNumber { get; set; }

        public string Qualification { get; set; }

        public PersonStudentDiplomaDto Diploma { get; set; }

        public List<StudentSemesterDto> Semesters { get; set; } = new List<StudentSemesterDto>();

        public NomenclatureDto School { get; set; }
        public NomenclatureDto SchoolSettlement { get; set; }
    }
}
