using StudentCard.Data.Rdpzsd.Nomenclatures.Base;
using StudentCard.Infrastructure.Helpers.Dtos;

namespace StudentCard.Infrastructure.Helpers.Extensions
{
    public static class NomenclatureCodeExtensions
    {
        public static NomenclatureCodeDto ToNomenclatureCodeDto(this NomenclatureCode rdpzsdNomenclature)
        {
            return rdpzsdNomenclature != null
                ? new NomenclatureCodeDto
                {
                    Name = rdpzsdNomenclature.Name,
                    NameAlt = rdpzsdNomenclature.NameAlt,
                    Alias = rdpzsdNomenclature.Alias,
                    Code = rdpzsdNomenclature.Code
                }
                : null;
        }
    }
}
