using StudentCard.Application.Students.Dtos.PersonLotDtos.BaseDtos;
using StudentCard.Data.Rdpzsd.Enums;
using System;

namespace StudentCard.Application.Students.Dtos.PersonLotDtos.PersonDoctoralDtos
{
    public class DoctoralSemesterDto : BaseSemesterDto
    {
        public DateTime ProtocolDate { get; set; }
        public string ProtocolNumber { get; set; }
        public YearType YearType { get; set; }
    }
}
