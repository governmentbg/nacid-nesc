using StudentCard.Data.Rdpzsd.Nomenclatures.Base;

namespace StudentCard.Data.Rdpzsd.Nomenclatures
{
    public class District : NomenclatureCode
    {
        public string Code2 { get; set; }
        public string SecondLevelRegionCode { get; set; }
        public string MainSettlementCode { get; set; }
    }
}
