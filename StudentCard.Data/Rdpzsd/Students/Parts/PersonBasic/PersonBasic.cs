using Microsoft.EntityFrameworkCore;
using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Interfaces;
using System.Linq;

namespace StudentCard.Data.Rdpzsd.Students.Parts
{
    public class PersonBasic : BasePersonBasic<PersonBasicInfo, PassportCopy, PersonImage>,
        ISinglePart<PersonBasic, PersonLot>
    {
        [Skip]
        public PersonLot Lot { get; set; }

        public IQueryable<PersonBasic> IncludeAll(IQueryable<PersonBasic> query)
        {
            return query
                .Include(e => e.BirthCountry)
                .Include(e => e.BirthDistrict)
                .Include(e => e.BirthMunicipality)
                .Include(e => e.BirthSettlement.District)
                .Include(e => e.BirthSettlement.Municipality)
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
