using StudentCard.Data.Rdpzsd.Enums;
using StudentCard.Data.Rdpzsd.Nomenclatures.Base;

namespace StudentCard.Data.Rdpzsd.Nomenclatures.Others
{
    public class Period : Nomenclature
    {
        public int Year { get; set; }
        public Semester Semester { get; set; }
    }
}
