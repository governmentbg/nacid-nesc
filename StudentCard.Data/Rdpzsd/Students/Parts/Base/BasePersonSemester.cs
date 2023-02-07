using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Nomenclatures;
using StudentCard.Data.Rdpzsd.Nomenclatures.Others;

namespace StudentCard.Data.Rdpzsd.Students.Parts.Base
{
    public class BasePersonSemester : EntityVersion
    {
        public int PartId { get; set; }
        public int StudentStatusId { get; set; }
        [Skip]
        public StudentStatus StudentStatus { get; set; }
        public int StudentEventId { get; set; }
        [Skip]
        public StudentEvent StudentEvent { get; set; }

        public int? EducationFeeTypeId { get; set; }
        [Skip]
        public EducationFeeType EducationFeeType { get; set; }

        public int? RelocatedFromPartId { get; set; }

        public string Note { get; set; }

        public bool HasScholarship { get; set; }
        public bool UseHostel { get; set; }
        public bool UseHolidayBase { get; set; }
        public bool ParticipatedIntPrograms { get; set; }
    }
}
