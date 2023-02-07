using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Enums.Nomenclature.School;
using StudentCard.Data.Rdpzsd.Nomenclatures.Base;

namespace StudentCard.Data.Rdpzsd.Nomenclatures.Others
{
    public class School : Nomenclature
    {
        public SchoolState State { get; set; }
        public SchoolType Type { get; set; }
        public SchoolOwnershipType OwnershipType { get; set; }

        public int SettlementId { get; set; }
        [Skip]
        public Settlement Settlement { get; set; }
        public int MunicipalityId { get; set; }
        [Skip]
        public Municipality Municipality { get; set; }
        public int DistrictId { get; set; }
        [Skip]
        public District District { get; set; }
        public int? MigrationId { get; set; }
        public int? ParentId { get; set; }
        [Skip]
        public School Parent { get; set; }
    }
}
