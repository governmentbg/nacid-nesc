using StudentCard.Data.Rdpzsd.Base;

namespace StudentCard.Data.Rdpzsd.Interfaces
{
    public interface ISinglePart<TEntity, TLot>
        where TLot : EntityVersion
        where TEntity : EntityVersion
    {
        TLot Lot { get; set; }
    }
}
