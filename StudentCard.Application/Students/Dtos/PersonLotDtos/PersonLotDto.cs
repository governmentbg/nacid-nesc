using StudentCard.Application.Students.Dtos.PersonLotDtos.PersonBasicDtos;
using StudentCard.Application.Students.Dtos.PersonLotDtos.PersonDoctoralDtos;
using StudentCard.Application.Students.Dtos.PersonLotDtos.PersonSecondaryDtos;
using StudentCard.Application.Students.Dtos.PersonLotDtos.PersonStudentDtos;
using StudentCard.Data.Rdpzsd.Enums;
using System;
using System.Collections.Generic;

namespace StudentCard.Application.Students.Dtos.PersonLotDtos
{
    public class PersonLotDto
    {
        public string Uan { get; set; }
        public LotState State { get; set; }
        public DateTime CreateDate { get; set; }

        public PersonBasicDto PersonBasicDto { get; set; }
        public PersonSecondaryDto PersonSecondaryDto { get; set; }
        public List<PersonStudentDto> PersonStudentsDto { get; set; } = new List<PersonStudentDto>();
        public List<PersonDoctoralDto> PersonDoctoralsDto { get; set; } = new List<PersonDoctoralDto>();
    }
}
