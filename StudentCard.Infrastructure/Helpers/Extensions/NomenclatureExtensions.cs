using StudentCard.Data.Rdpzsd.Nomenclatures.Base;
using StudentCard.Infrastructure.Helpers.Dtos;

namespace StudentCard.Infrastructure.Helpers.Extensions
{
    public static class NomenclatureExtensions
    {
        public static NomenclatureDto ToNomenclatureDto(this Nomenclature rdpzsdNomenclature)
        {
            return rdpzsdNomenclature != null
                ? new NomenclatureDto
                {
                    Name = rdpzsdNomenclature.Name,
                    NameAlt = rdpzsdNomenclature.NameAlt,
                    Alias = rdpzsdNomenclature.Alias
                }
                : null;
        }
    }
}
