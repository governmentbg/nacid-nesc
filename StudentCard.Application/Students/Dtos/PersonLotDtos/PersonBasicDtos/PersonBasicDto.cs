using StudentCard.Data.Rdpzsd.Enums;
using StudentCard.Data.Rdpzsd.Students.Parts;
using StudentCard.Infrastructure.Helpers.Dtos;
using System;

namespace StudentCard.Application.Students.Dtos.PersonLotDtos.PersonBasicDtos
{
    public class PersonBasicDto
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string OtherNames { get; set; }

        public string FirstNameAlt { get; set; }
        public string MiddleNameAlt { get; set; }
        public string LastNameAlt { get; set; }
        public string OtherNamesAlt { get; set; }

        public string Uin { get; set; }
        public string ForeignerNumber { get; set; }
        public string IdnNumber { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PostCode { get; set; }

        public GenderType Gender { get; set; }
        public DateTime BirthDate { get; set; }

        public NomenclatureCodeDto BirthCountry { get; set; }
        public NomenclatureCodeDto BirthDistrict { get; set; }
        public NomenclatureCodeDto BirthMunicipality { get; set; }
        public NomenclatureCodeDto BirthSettlement { get; set; }
        public string ForeignerBirthSettlement { get; set; }

        public NomenclatureDto Citizenship { get; set; }
        public NomenclatureDto SecondCitizenship { get; set; }

        public string CitizenshipFull { get; set; }
        public string CitizenshipFullAlt { get; set; }

        public NomenclatureCodeDto ResidenceCountry { get; set; }
        public NomenclatureCodeDto ResidenceDistrict { get; set; }
        public NomenclatureCodeDto ResidenceMunicipality { get; set; }
        public NomenclatureCodeDto ResidenceSettlement { get; set; }
        public string ResidenceAddress { get; set; }

        public string ResidenceSettlementAndPostCode { get; set; }
        public string ResidenceSettlementAndPostCodeAlt { get; set; }

        public PersonImage PersonImage { get; set; }
    }
}
