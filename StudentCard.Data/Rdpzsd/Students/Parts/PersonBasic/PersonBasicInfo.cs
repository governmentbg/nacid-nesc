using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Students.Parts.Base;

namespace StudentCard.Data.Rdpzsd.Students.Parts
{
    public class PersonBasicInfo : PartInfo
    {
        [Skip]
        public PersonBasic PersonBasic { get; set; }
    }
}
