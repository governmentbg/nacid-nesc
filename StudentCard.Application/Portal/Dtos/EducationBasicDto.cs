using StudentCard.Infrastructure.Helpers.Dtos;

namespace StudentCard.Application.Portal.Dtos
{
    public class EducationBasicDto
    {
        public int Id { get; set; }
        public InstitutionDto Institution { get; set; }

        public NomenclatureDto Speciality { get; set; }

        public NomenclatureDto EducationalQualification { get; set; }

        public NomenclatureDto EducationalForm { get; set; }

        public StudentStatusDto Status { get; set; }
    }
}
