using System.ComponentModel;

namespace StudentCard.Data.Rdpzsd.Enums.Nomenclature.Country
{
    public enum CountryUnion
    {
        [Description("Държави членуващи в ЕС и ЕИП")]
        EuAndEea = 1,

        [Description("Държави нечленуващи в ЕС и ЕИП")]
        OtherCountries = 2,
    }
}
