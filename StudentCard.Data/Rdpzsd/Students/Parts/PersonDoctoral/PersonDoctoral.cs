using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Interfaces;
using StudentCard.Data.Rdpzsd.Students.Parts.Base;
using System;

namespace StudentCard.Data.Rdpzsd.Students.Parts
{
    public class PersonDoctoral : BasePersonStudentDoctoral<PersonDoctoralInfo, PersonDoctoralSemester>,
        IMultiPart<PersonDoctoral, PersonLot>
    {
        public DateTime StartDate { get; set; }
        //public DateTime? EndDate { get; set; }

        [Skip]
        public PersonStudent PePart { get; set; }

        public int LotId { get; set; }
        [Skip]
        public PersonLot Lot { get; set; }

        public PersonDoctoralPeRecognitionDocument PeRecognitionDocument { get; set; }
    }
}
