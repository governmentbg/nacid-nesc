using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Enums;
using StudentCard.Data.Rdpzsd.Nomenclatures;
using StudentCard.Data.Rdpzsd.Students.Parts;
using StudentCard.Data.Rdpzsd.Students.Parts.PersonSecondary;
using System;
using System.Collections.Generic;

namespace StudentCard.Data.Rdpzsd.Students
{
    public class PersonLot : EntityVersion
    {
        public string Uan { get; set; }
        public LotState State { get; set; }

        public int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int? CreateInstitutionId { get; set; }
        [Skip]
        public Institution CreateInstitution { get; set; }
        public int? CreateSubordinateId { get; set; }
        [Skip]
        public Institution CreateSubordinate { get; set; }

        public StudentCardStatus? StudentCardStatus { get; set; }

        public PersonBasic PersonBasic { get; set; }
        public PersonSecondary PersonSecondary { get; set; }
        public List<PersonStudent> PersonStudents { get; set; } = new List<PersonStudent>();
        public List<PersonDoctoral> PersonDoctorals { get; set; } = new List<PersonDoctoral>();
    }
}
