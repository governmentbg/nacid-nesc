using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Students.Parts.Base;

namespace StudentCard.Data.Rdpzsd.Students.Parts.History
{
    public class PersonBasicHistoryInfo : PartInfo
    {
        [Skip]
        public PersonBasicHistory PersonBasicHistory { get; set; }
    }
}
