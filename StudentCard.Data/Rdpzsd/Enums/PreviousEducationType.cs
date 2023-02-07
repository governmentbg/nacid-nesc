using System.ComponentModel;

namespace StudentCard.Data.Rdpzsd.Enums
{
    [Description("Вид на предходното образование")]
    public enum PreviousEducationType
    {
        [Description("Средно образование")]
        Secondary = 1,

        [Description("Висше образование")]
        HighSchool = 2
    }
}
