using StudentCard.Data.Common.Models;

namespace StudentCard.Data.Nomenclatures
{
    public class EmailType : Nomenclature
    {
        public string Subject { get; set; }

        public string Body { get; set; }

        public string Alias { get; set; }
    }
}
