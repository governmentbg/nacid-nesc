using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Nomenclatures.Base;

namespace StudentCard.Data.Rdpzsd.Nomenclatures
{
    public class Municipality : NomenclatureCode
    {
        public int DistrictId { get; set; }
        [Skip]
        public District District { get; set; }
        public string Code2 { get; set; }
        public string MainSettlementCode { get; set; }
        public string Category { get; set; }
    }
}
