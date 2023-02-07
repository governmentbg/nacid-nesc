using System.ComponentModel;

namespace StudentCard.Data.Rdpzsd.Enums
{
    [Description("Положителна или отрициателна атестация")]
    public enum AttestationType
    {
        [Description("Положителна")]
        Positive = 1,

        [Description("Отрицателна")]
        Negative = 2,
    }
}
