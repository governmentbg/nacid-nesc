using System.ComponentModel;

namespace StudentCard.Application.Users.Enums
{
    [Description("Вид на идентификация за регистрация")]
    public enum RegisterIdentificationEnum
    {
        [Description("ЕГН")]
        UIN = 1,

        [Description("ЛНЧ")]
        ForeignerNumber = 2,

        [Description("Идентификационен номер")]
        IDN = 3,

        [Description("ЕАН")]
        UAN = 4
    }
}
