using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Parts.Base;

namespace StudentCard.Data.Rdpzsd.Students.Parts
{
    public class PersonDoctoralPeRecognitionDocument : RdpzsdAttachedFile
    {
        [Skip]
        public PersonDoctoral PersonDoctoral { get; set; }
    }
}
