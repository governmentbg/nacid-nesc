using StudentCard.Application.Students.Dtos.PersonLotDtos.BaseDtos;
using StudentCard.Data.Rdpzsd.Enums;

namespace StudentCard.Application.Students.Dtos.PersonLotDtos.PersonStudentDtos
{
    public class StudentSemesterDto : BaseSemesterDto
    {
        public PeriodDto Period { get; set; }
        public CourseType Course { get; set; }

        public Semester Semester { get; set; }
    }
}
