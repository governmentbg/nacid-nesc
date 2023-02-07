using StudentCard.Data.Rdpzsd.Base;

namespace StudentCard.Data.Rdpzsd.Nomenclatures
{
    public class StudentEventQualification : EntityVersion
    {
        public int StudentEventId { get; set; }
        public int EducationalQualificationId { get; set; }
        [Skip]
        public EducationalQualification EducationalQualification { get; set; }
    }
}
