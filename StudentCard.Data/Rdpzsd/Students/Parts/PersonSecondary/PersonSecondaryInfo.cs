using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Students.Parts.Base;

namespace StudentCard.Data.Rdpzsd.Students.Parts.PersonSecondary
{
    public class PersonSecondaryInfo : PartInfo
    {
        [Skip]
        public PersonSecondary PersonSecondary { get; set; }
    }
}
