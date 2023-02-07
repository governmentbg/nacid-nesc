using StudentCard.Data.Rdpzsd.Enums;
using StudentCard.Infrastructure.Helpers.Dtos;

namespace StudentCard.Application.Students.Dtos.PersonLotDtos.PersonStudentDtos
{
    public class PeriodDto : NomenclatureDto
    {
        public int Year { get; set; }
        public Semester Semester { get; set; }
    }
}
