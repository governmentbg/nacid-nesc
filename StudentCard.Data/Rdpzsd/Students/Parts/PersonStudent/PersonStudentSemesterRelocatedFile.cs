using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Parts.Base;

namespace StudentCard.Data.Rdpzsd.Students.Parts
{
    public class PersonStudentSemesterRelocatedFile : RdpzsdAttachedFile
    {
        [Skip]
        public PersonStudentSemester PersonStudentSemester { get; set; }
    }
}
