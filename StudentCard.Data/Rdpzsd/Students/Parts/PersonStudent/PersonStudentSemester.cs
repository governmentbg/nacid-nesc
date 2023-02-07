using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Enums;
using StudentCard.Data.Rdpzsd.Nomenclatures;
using StudentCard.Data.Rdpzsd.Nomenclatures.Others;
using StudentCard.Data.Rdpzsd.Students.Parts.Base;
using System;

namespace StudentCard.Data.Rdpzsd.Students.Parts
{
    public class PersonStudentSemester : BasePersonSemester
    {
        public int PeriodId { get; set; }
        [Skip]
        public Period Period { get; set; }

        public CourseType Course { get; set; }
        public Semester StudentSemester { get; set; }
        // Specific field which can be true only if StudentEvent is TwoYearsForOne and its the second period from this event
        public bool SecondFromTwoYearsPlan { get; set; } = false;

        public string SemesterRelocatedNumber { get; set; }
        public DateTime? SemesterRelocatedDate { get; set; }
        public PersonStudentSemesterRelocatedFile SemesterRelocatedFile { get; set; }

        public CourseType? IndividualPlanCourse { get; set; }
        public Semester? IndividualPlanSemester { get; set; }

        [Skip]
        public PersonStudent RelocatedFromPart { get; set; }
        public int SemesterInstitutionId { get; set; }
        [Skip]
        public Institution SemesterInstitution { get; set; }
    }
}
