using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Parts.Base;

namespace StudentCard.Data.Rdpzsd.Students.Parts
{
    public class PersonStudentPeRecognitionDocument : RdpzsdAttachedFile
    {
        [Skip]
        public PersonStudent PersonStudent { get; set; }
    }
}
