using StudentCard.Data.Rdpzsd.Base;

namespace StudentCard.Data.Rdpzsd.Nomenclatures.Others
{
    public class AdmissionReasonEducationFee : EntityVersion
    {
        public int AdmissionReasonId { get; set; }
        [Skip]
        public AdmissionReason AdmissionReason { get; set; }
        public int EducationFeeTypeId { get; set; }
        [Skip]
        public EducationFeeType EducationFeeType { get; set; }
    }
}
