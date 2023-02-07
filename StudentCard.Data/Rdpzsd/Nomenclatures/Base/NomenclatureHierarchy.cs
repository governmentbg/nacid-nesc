using StudentCard.Data.Rdpzsd.Enums;

namespace StudentCard.Data.Rdpzsd.Nomenclatures.Base
{
    public class NomenclatureHierarchy : NomenclatureCode
    {
        public int RootId { get; set; }
        public int? ParentId { get; set; }
        public Level Level { get; set; }
    }
}
