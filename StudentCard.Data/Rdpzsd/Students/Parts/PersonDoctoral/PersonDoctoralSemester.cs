using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Enums;
using StudentCard.Data.Rdpzsd.Students.Parts.Base;
using System;

namespace StudentCard.Data.Rdpzsd.Students.Parts
{
    public class PersonDoctoralSemester : BasePersonSemester
    {
        public DateTime ProtocolDate { get; set; }
        public string ProtocolNumber { get; set; }
        public YearType YearType { get; set; }
        public AttestationType? AttestationType { get; set; }
        [Skip]
        public PersonDoctoral RelocatedFromPart { get; set; }
        public string SemesterRelocatedNumber { get; set; }
        public DateTime SemesterRelocatedDate { get; set; }
        public PersonDoctoralSemesterRelocatedFile SemesterRelocatedFile { get; set; }
    }
}
