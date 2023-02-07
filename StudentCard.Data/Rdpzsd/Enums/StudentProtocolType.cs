using System.ComponentModel;

namespace StudentCard.Data.Rdpzsd.Enums
{
    [Description("Държавен изпит/защита на дипломна работа")]
    public enum StudentProtocolType
    {
        [Description("Държавен изпит")]
        StateExamination = 1,

        [Description("Защита на дипломна работа")]
        ThesisDefense = 2,

        [Description("Държавен изпит/Защита на дипломна работа")]
        StateExaminationOrThesisDefense = 3
    }
}
