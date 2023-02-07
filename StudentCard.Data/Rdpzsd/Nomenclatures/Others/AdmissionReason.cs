using StudentCard.Data.Rdpzsd.Enums.Nomenclature.AdmissionReason;
using StudentCard.Data.Rdpzsd.Enums.Nomenclature.Country;
using StudentCard.Data.Rdpzsd.Nomenclatures.Base;
using System.Collections.Generic;

namespace StudentCard.Data.Rdpzsd.Nomenclatures.Others
{
    public class AdmissionReason : Nomenclature
    {
        public string OldCode { get; set; }
        public string ShortName { get; set; }
        public string ShortNameAlt { get; set; }
        public string Description { get; set; }
        public AdmissionReasonStudentType? AdmissionReasonStudentType { get; set; }
        public CountryUnion? CountryUnion { get; set; }
        public ICollection<AdmissionReasonEducationFee> AdmissionReasonEducationFees { get; set; }

        public AdmissionReason()
        {
            AdmissionReasonEducationFees = new List<AdmissionReasonEducationFee>();
        }
    }
}
