using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Nomenclatures;
using StudentCard.Data.Rdpzsd.Nomenclatures.Others;
using StudentCard.Data.Rdpzsd.Students.Parts.Base;
using System;

namespace StudentCard.Data.Rdpzsd.Students.Parts.PersonSecondary.Base
{
    public abstract class BasePersonSecondary<TPartInfo> : Part<TPartInfo>
         where TPartInfo : PartInfo
    {
        public int GraduationYear { get; set; }
        public int CountryId { get; set; }
        [Skip]
        public Country Country { get; set; }
        public int? SchoolId { get; set; }
        [Skip]
        public School School { get; set; }
        public string ForeignSchoolName { get; set; }
        public string Profession { get; set; }
        public string DiplomaNumber { get; set; }
        public DateTime? DiplomaDate { get; set; }
        public string RecognitionNumber { get; set; }
        public DateTime? RecognitionDate { get; set; }
        public bool MissingSchoolFromRegister { get; set; }
        public string MissingSchoolName { get; set; }
        public int? MissingSchoolSettlementId { get; set; }
        [Skip]
        public Settlement MissingSchoolSettlement { get; set; }
    }
}
