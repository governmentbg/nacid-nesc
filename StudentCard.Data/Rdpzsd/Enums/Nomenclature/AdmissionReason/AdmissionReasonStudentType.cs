using System.ComponentModel;

namespace StudentCard.Data.Rdpzsd.Enums.Nomenclature.AdmissionReason
{
    public enum AdmissionReasonStudentType
    {
        [Description("Основание за прием - студенти")]
        Students = 1,

        [Description("Основание за прием - докторанти")]
        Doctorals = 2,

        [Description("Основание за прием - студенти и докторанти")]
        StudentsAndDoctorals = 3,
    }
}
