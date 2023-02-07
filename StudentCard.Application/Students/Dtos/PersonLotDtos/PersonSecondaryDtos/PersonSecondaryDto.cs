using StudentCard.Infrastructure.Helpers.Dtos;
using System;

namespace StudentCard.Application.Students.Dtos.PersonLotDtos.PersonSecondaryDtos
{
    public class PersonSecondaryDto
    {
        public int GraduationYear { get; set; }
        public NomenclatureDto Country { get; set; }
        public NomenclatureDto School { get; set; }
        public NomenclatureDto SchoolSettlement { get; set; }
        public string ForeignSchoolName { get; set; }
        public string Profession { get; set; }
        public string DiplomaNumber { get; set; }
        public DateTime? DiplomaDate { get; set; }
    }
}
