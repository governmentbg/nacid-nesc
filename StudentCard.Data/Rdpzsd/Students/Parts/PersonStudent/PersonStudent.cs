using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Interfaces;
using StudentCard.Data.Rdpzsd.Students.Parts.Base;
using System.Collections.Generic;

namespace StudentCard.Data.Rdpzsd.Students.Parts
{
    public class PersonStudent : BasePersonStudentDoctoral<PersonStudentInfo, PersonStudentSemester>,
       IMultiPart<PersonStudent, PersonLot>
    {
        public string FacultyNumber { get; set; }

        public string Qualification { get; set; }

        [Skip]
        public PersonStudent PePart { get; set; }

        public int LotId { get; set; }
        [Skip]
        public PersonLot Lot { get; set; }

        #region Graduation
        [SkipUpdate]
        public PersonStudentDiploma Diploma { get; set; }
        [SkipUpdate]
        public List<PersonStudentDuplicateDiploma> DuplicateDiplomas { get; set; } = new List<PersonStudentDuplicateDiploma>();
        [SkipUpdate]
        public List<PersonStudentProtocol> Protocols { get; set; } = new List<PersonStudentProtocol>();
        #endregion

        public PersonStudentPeRecognitionDocument PeRecognitionDocument { get; set; }
    }

}
