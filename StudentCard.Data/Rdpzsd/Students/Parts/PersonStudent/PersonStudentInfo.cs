using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Students.Parts.Base;

namespace StudentCard.Data.Rdpzsd.Students.Parts
{
    public class PersonStudentInfo : PartInfo
    {
        [Skip]
        public PersonStudent PersonStudent { get; set; }
    }
}
