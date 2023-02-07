using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Enums;
using StudentCard.Data.Rdpzsd.Nomenclatures;
using StudentCard.Data.Rdpzsd.Nomenclatures.Others;
using System;
using System.Collections.Generic;

namespace StudentCard.Data.Rdpzsd.Students.Parts.Base
{
    public abstract class BasePersonStudentDoctoral<TPartInfo, TSemester> : Part<TPartInfo>
       where TPartInfo : PartInfo
       where TSemester : BasePersonSemester, new()
    {
        public int InstitutionId { get; set; }
        [Skip]
        public Institution Institution { get; set; }

        public int? SubordinateId { get; set; }
        [Skip]
        public Institution Subordinate { get; set; }

        public int InstitutionSpecialityId { get; set; }
        [Skip]
        public InstitutionSpeciality InstitutionSpeciality { get; set; }
        public int StudentStatusId { get; set; }
        [Skip]
        public StudentStatus StudentStatus { get; set; }
        public int StudentEventId { get; set; }
        [Skip]
        public StudentEvent StudentEvent { get; set; }

        public int AdmissionReasonId { get; set; }
        [Skip]
        public AdmissionReason AdmissionReason { get; set; }

        [SkipUpdate]
        public List<TSemester> Semesters { get; set; } = new List<TSemester>();

        #region PreviousEducation
        public PreviousEducationType PeType { get; set; }
        public PreviousHighSchoolEducationType? PeHighSchoolType { get; set; }

        public string PeDiplomaNumber { get; set; }
        public DateTime? PeDiplomaDate { get; set; }
        public int? PeResearchAreaId { get; set; }
        [Skip]
        public ResearchArea PeResearchArea { get; set; }
        public int? PeEducationalQualificationId { get; set; }
        [Skip]
        public EducationalQualification PeEducationalQualification { get; set; }

        public int? PeAcquiredForeignEducationalQualificationId { get; set; }
        [Skip]
        public EducationalQualification PeAcquiredForeignEducationalQualification { get; set; }

        // FromRegister
        public int? PePartId { get; set; }

        // FromRegister, MissingInRegister
        public int? PeInstitutionId { get; set; }
        [Skip]
        public Institution PeInstitution { get; set; }
        public int? PeSubordinateId { get; set; }
        [Skip]
        public Institution PeSubordinate { get; set; }
        public int? PeInstitutionSpecialityId { get; set; }

        [Skip]
        public InstitutionSpeciality PeInstitutionSpeciality { get; set; }
        public bool? PeSpecialityMissingInRegister { get; set; }

        // Abroad, ClosedInstitution
        public string PeInstitutionName { get; set; }
        public string PeSubordinateName { get; set; }

        // ClosedInstitution
        public string PeSpecialityName { get; set; }

        // Abroad
        public int? PeCountryId { get; set; }
        [Skip]
        public Country PeCountry { get; set; }
        public string PeRecognizedSpeciality { get; set; }
        public string PeAcquiredSpeciality { get; set; }

        public string PeRecognitionNumber { get; set; }
        public DateTime? PeRecognitionDate { get; set; }
        #endregion
    }
}
