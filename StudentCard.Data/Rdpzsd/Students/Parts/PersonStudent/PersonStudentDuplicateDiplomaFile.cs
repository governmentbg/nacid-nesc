using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Parts.Base;

namespace StudentCard.Data.Rdpzsd.Students.Parts
{
    public class PersonStudentDuplicateDiplomaFile : RdpzsdAttachedFile
    {
        [Skip]
        public PersonStudentDuplicateDiploma DuplicateDiploma { get; set; }
    }
}
