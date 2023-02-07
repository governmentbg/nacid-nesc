using StudentCard.Data.Rdpzsd.Enums;
using StudentCard.Infrastructure.Helpers.Dtos;
using System;

namespace StudentCard.Application.Students.Dtos.PersonLotDtos.BaseDtos
{
    public class BasePeDto
    {
        public PreviousEducationType PeType { get; set; }
        public PreviousHighSchoolEducationType? PeHighSchoolType { get; set; }

        public string PeDiplomaNumber { get; set; }
        public DateTime? PeDiplomaDate { get; set; }
        public ResearchAreaDto PeResearchArea { get; set; }

        //RecognizedEQ
        public NomenclatureDto PeEducationalQualification { get; set; }
        public NomenclatureDto PeAcquiredForeignEducationalQualification { get; set; }

        public NomenclatureDto PeInstitution { get; set; }
        public NomenclatureDto PeSubordinate { get; set; }
        public NomenclatureDto PeSpeciality { get; set; }

        // Abroad, ClosedInstitution
        public string PeInstitutionName { get; set; }
        public string PeSubordinateName { get; set; }

        // ClosedInstitution
        public string PeSpecialityName { get; set; }

        // Abroad
        public NomenclatureDto PeCountry { get; set; }
        public string PeRecognizedSpeciality { get; set; }
        public string PeAcquiredSpeciality { get; set; }

        public string PeRecognitionNumber { get; set; }
        public DateTime? PeRecognitionDate { get; set; }
    }
}
