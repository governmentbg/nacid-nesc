using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Enums;

namespace StudentCard.Data.Rdpzsd.Students.Parts.Base
{
    public abstract class Part<TPartInfo> : EntityVersion
        where TPartInfo : PartInfo
    {
        public TPartInfo PartInfo { get; set; }

        public PartState State { get; set; }
    }
}
