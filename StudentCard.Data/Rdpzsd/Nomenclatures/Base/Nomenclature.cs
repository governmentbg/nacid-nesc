using StudentCard.Data.Rdpzsd.Base;

namespace StudentCard.Data.Rdpzsd.Nomenclatures.Base
{
    public class Nomenclature : EntityVersion
    {
        public string Name { get; set; }
        public string NameAlt { get; set; }
        public string Alias { get; set; }

        public bool IsActive { get; set; } = true;

        public int? ViewOrder { get; set; }
    }
}
