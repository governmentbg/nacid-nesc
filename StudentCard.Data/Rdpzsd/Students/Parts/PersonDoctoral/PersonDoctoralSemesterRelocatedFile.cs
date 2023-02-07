using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Parts.Base;

namespace StudentCard.Data.Rdpzsd.Students.Parts
{
    public class PersonDoctoralSemesterRelocatedFile : RdpzsdAttachedFile
    {
        [Skip]
        public PersonDoctoralSemester PersonDoctoralSemester { get; set; }
    }
}
