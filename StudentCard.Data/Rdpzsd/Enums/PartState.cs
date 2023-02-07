using System.ComponentModel;

namespace StudentCard.Data.Rdpzsd.Enums
{
    [Description("Статус на партовете")]
    public enum PartState
    {
        [Description("Актуално състояние")]
        Actual = 1,

        [Description("Изтрит")]
        Erased = 2
    }
}
