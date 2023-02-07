using StudentCard.Infrastructure.Helpers.Dtos;

namespace StudentCard.Application.Students.Dtos.PersonLotDtos.BaseDtos
{
    public class BaseSemesterDto
    {
        public int Id { get; set; }
        public StudentStatusDto StudentStatus { get; set; }
        public NomenclatureDto StudentEvent { get; set; }

        public NomenclatureDto EducationFeeType { get; set; }
    }
}
