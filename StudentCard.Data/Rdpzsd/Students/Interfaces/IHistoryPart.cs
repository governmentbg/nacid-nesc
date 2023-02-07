using StudentCard.Data.Rdpzsd.Base;

namespace StudentCard.Data.Rdpzsd.Students.Interfaces
{
    public interface IHistoryPart<TEntity>
        where TEntity : EntityVersion
    {
        int PartId { get; set; }
    }
}
