using Microsoft.EntityFrameworkCore;
using StudentCard.Data.Rdpzsd.Students.Interfaces;
using System.Linq;

namespace StudentCard.Data.Rdpzsd.Students.Parts.History
{
    public class PersonBasicHistory : BasePersonBasic<PersonBasicHistoryInfo, PassportCopyHistory, PersonImageHistory>, IHistoryPart<PersonBasicHistory>
    {
        public int PartId { get; set; }

        public IQueryable<PersonBasicHistory> IncludeAll(IQueryable<PersonBasicHistory> query)
        {
            return query
                .Include(e => e.BirthCountry)
                .Include(e => e.BirthDistrict)
                .Include(e => e.BirthMunicipality)
                .Include(e => e.BirthSettlement)
                .Include(e => e.Citizenship)
                .Include(e => e.SecondCitizenship)
                .Include(e => e.ResidenceCountry)
                .Include(e => e.ResidenceDistrict)
                .Include(e => e.ResidenceMunicipality)
                .Include(e => e.ResidenceSettlement)
                .Include(e => e.PersonImage)
                .Include(e => e.PassportCopy);
        }
    }
}
