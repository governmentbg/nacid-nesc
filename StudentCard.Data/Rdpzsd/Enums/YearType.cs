using System.ComponentModel;

namespace StudentCard.Data.Rdpzsd.Enums
{
    [Description("Година на докторска програма")]
    public enum YearType
    {
        [Description("Първа година")]
        FirstYear = 1,

        [Description("Втора година")]
        SecondYear = 2,

        [Description("Трета година")]
        ThirdYear = 3,

        [Description("Четвърта година")]
        FourthYear = 4,

        [Description("Пета година")]
        FifthYear = 5,
    }
}
