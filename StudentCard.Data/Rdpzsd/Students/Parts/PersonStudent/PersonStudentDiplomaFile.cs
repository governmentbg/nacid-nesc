using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Parts.Base;

namespace StudentCard.Data.Rdpzsd.Students.Parts
{
    public class PersonStudentDiplomaFile : RdpzsdAttachedFile
    {
        [Skip]
        public PersonStudentDiploma Diploma { get; set; }
    }
}
