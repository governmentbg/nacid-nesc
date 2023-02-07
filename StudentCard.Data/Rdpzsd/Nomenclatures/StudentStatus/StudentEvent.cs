using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Nomenclatures.Base;
using System.Collections.Generic;

namespace StudentCard.Data.Rdpzsd.Nomenclatures
{
    public class StudentEvent : Nomenclature
    {
        public int StudentStatusId { get; set; }
        [Skip]
        public StudentStatus StudentStatus { get; set; }

        public List<StudentEventQualification> StudentEventQualifications { get; set; } = new List<StudentEventQualification>();
    }
}
