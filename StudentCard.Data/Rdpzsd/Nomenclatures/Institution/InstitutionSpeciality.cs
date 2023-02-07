using StudentCard.Data.Rdpzsd.Base;

namespace StudentCard.Data.Rdpzsd.Nomenclatures
{
    public class InstitutionSpeciality : EntityVersion
    {
        public int InstitutionId { get; set; }
        [Skip]
        public Institution Institution { get; set; }

        public int SpecialityId { get; set; }
        [Skip]
        public Speciality Speciality { get; set; }
        public int? EducationalFormId { get; set; }
        [Skip]
        public EducationalForm EducationalForm { get; set; }
        public int? NsiRegionId { get; set; }
        public int? NationalStatisticalInstituteId { get; set; }
        public decimal? Duration { get; set; }
        public bool IsAccredited { get; set; }
        public bool IsForCadets { get; set; }
        // It will be false if IsActive = false or PartState = Erased
        public bool IsActive { get; set; }
        public bool? IsJointSpeciality { get; set; }
    }
}
