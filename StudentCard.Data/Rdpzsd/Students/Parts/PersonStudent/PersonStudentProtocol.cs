using StudentCard.Data.Rdpzsd.Base;
using StudentCard.Data.Rdpzsd.Enums;
using System;

namespace StudentCard.Data.Rdpzsd.Students.Parts
{
    public class PersonStudentProtocol : EntityVersion
    {
        public int PartId { get; set; }
        public StudentProtocolType ProtocolType { get; set; } = StudentProtocolType.StateExamination;
        public string ProtocolNumber { get; set; }
        public DateTime ProtocolDate { get; set; }
    }
}
