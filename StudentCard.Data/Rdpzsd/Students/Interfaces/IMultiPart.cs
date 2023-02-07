using StudentCard.Data.Rdpzsd.Base;

namespace StudentCard.Data.Rdpzsd.Interfaces
{
    public interface IMultiPart<TEntity, TLot> : ISinglePart<TEntity, TLot>
        where TLot : EntityVersion
        where TEntity : EntityVersion
    {
        int LotId { get; set; }
    }
}
