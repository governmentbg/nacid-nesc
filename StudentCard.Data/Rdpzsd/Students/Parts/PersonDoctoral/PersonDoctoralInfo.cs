using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Students.Parts.Base;

namespace StudentCard.Data.Rdpzsd.Students.Parts
{
    public class PersonDoctoralInfo : PartInfo
    {
        [Skip]
        public PersonDoctoral PersonDoctoral { get; set; }
    }

}
