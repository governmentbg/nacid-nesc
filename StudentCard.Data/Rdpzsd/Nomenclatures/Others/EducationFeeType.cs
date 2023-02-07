using StudentCard.Data.Rdpzsd.Nomenclatures.Base;
using System.Collections.Generic;

namespace StudentCard.Data.Rdpzsd.Nomenclatures.Others
{
    public class EducationFeeType : Nomenclature
    {
        public string OldCode { get; set; }

        public ICollection<AdmissionReasonEducationFee> AdmissionReasonEducationFees { get; set; }

        public EducationFeeType()
        {
            AdmissionReasonEducationFees = new List<AdmissionReasonEducationFee>();
        }
    }
}
