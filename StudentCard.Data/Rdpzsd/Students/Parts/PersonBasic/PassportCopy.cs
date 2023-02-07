using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Parts.Base;

namespace StudentCard.Data.Rdpzsd.Students.Parts
{
    public class PassportCopy : RdpzsdAttachedFile
    {
        [Skip]
        public PersonBasic PersonBasic { get; set; }
    }
}
