using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Enums.Nomenclature.Institution;
using StudentCard.Data.Rdpzsd.Nomenclatures.Base;
using System.Collections.Generic;

namespace StudentCard.Data.Rdpzsd.Nomenclatures
{
    public class Institution : NomenclatureHierarchy
    {
        public int LotNumber { get; set; }
        public InstitutionCommitState? State { get; set; }

        [Skip]
        public Institution Parent { get; set; }
        [Skip]
        public Institution Root { get; set; }

        public string Uic { get; set; }
        public string ShortName { get; set; }
        public string ShortNameAlt { get; set; }

        public OrganizationType? OrganizationType { get; set; }
        public OwnershipType? OwnershipType { get; set; }

        public int? SettlementId { get; set; }
        [Skip]
        public Settlement Settlement { get; set; }
        public int? MunicipalityId { get; set; }
        [Skip]
        public Municipality Municipality { get; set; }
        public int? DistrictId { get; set; }
        [Skip]
        public District District { get; set; }

        public bool IsResearchUniversity { get; set; }

        public List<InstitutionSpeciality> InstitutionSpecialities { get; set; } = new List<InstitutionSpeciality>();
    }
}
