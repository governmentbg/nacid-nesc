using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Enums;
using StudentCard.Data.Rdpzsd.Nomenclatures;
using System;

namespace StudentCard.Data.Rdpzsd.Students
{
    public class PersonLotAction : EntityVersion
    {
        public int LotId { get; set; }

        public int? UserId { get; set; }
        public string UserFullname { get; set; }
        public DateTime ActionDate { get; set; }

        public int? InstitutionId { get; set; }
        [Skip]
        public Institution Institution { get; set; }
        public int? SubordinateId { get; set; }
        [Skip]
        public Institution Subordinate { get; set; }

        public PersonLotActionType ActionType { get; set; }

        public string Note { get; set; }
    }
}
