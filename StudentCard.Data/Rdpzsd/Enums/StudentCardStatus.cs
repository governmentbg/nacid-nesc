using System.ComponentModel;

namespace StudentCard.Data.Rdpzsd.Enums
{
    public enum StudentCardStatus
    {
        [Description("Не е заявена")]
        Unrequested = 1,

        [Description("Заявена")]
        Requested = 2,

        [Description("Създадена")]
        Created = 3,

        [Description("Не е създадена поради грешка, която се логва в Регистъра на студентската карта")]
        NotCreated = 4,

        [Description("Студентът няма имейл")]
        NoEmail = 5
    }
}
