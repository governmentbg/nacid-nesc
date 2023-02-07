using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Parts.Base;

namespace StudentCard.Data.Rdpzsd.Students.Parts.History
{
    public class PassportCopyHistory : RdpzsdAttachedFile
    {
        [Skip]
        public PersonBasicHistory PersonBasicHistory { get; set; }
    }
}
