using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Nomenclatures.Base;

namespace StudentCard.Data.Rdpzsd.Nomenclatures
{
    public class Speciality : NomenclatureCode
    {
        public int? ResearchAreaId { get; set; }
        [Skip]
        public ResearchArea ResearchArea { get; set; }

        public int EducationalQualificationId { get; set; }
        [Skip]
        public EducationalQualification EducationalQualification { get; set; }

        public bool IsRegulated { get; set; }
    }
}
