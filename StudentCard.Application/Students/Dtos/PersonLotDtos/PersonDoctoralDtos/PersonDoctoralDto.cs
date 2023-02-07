using StudentCard.Application.Students.Dtos.PersonLotDtos.BaseDtos;
using StudentCard.Data.Rdpzsd.Parts.Base;
using System;
using System.Collections.Generic;

namespace StudentCard.Application.Students.Dtos.PersonLotDtos.PersonDoctoralDtos
{
    public class PersonDoctoralDto : BaseStudentDoctoralDto
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public RdpzsdAttachedFile PeRecognitionDocument { get; set; }

        public List<DoctoralSemesterDto> Semesters { get; set; } = new List<DoctoralSemesterDto>();
    }
}
