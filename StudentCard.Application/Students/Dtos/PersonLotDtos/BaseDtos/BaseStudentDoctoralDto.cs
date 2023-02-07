using StudentCard.Infrastructure.Helpers.Dtos;

namespace StudentCard.Application.Students.Dtos.PersonLotDtos.BaseDtos
{
    public class BaseStudentDoctoralDto : BasePeDto
    {
        public NomenclatureDto Institution { get; set; }

        public NomenclatureDto Subordinate { get; set; }

        public NomenclatureDto Speciality { get; set; }

        public NomenclatureDto AdmissionReason { get; set; }

        public NomenclatureDto EducationalForm { get; set; }

        public NomenclatureDto EducationalQualification { get; set; }

        public NomenclatureDto StudentStatus { get; set; }

        public NomenclatureDto StudentEvent { get; set; }

        public decimal? Duration { get; set; }
    }
}
