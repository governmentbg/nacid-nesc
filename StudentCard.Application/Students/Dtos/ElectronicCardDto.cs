using StudentCard.Data.Rdpzsd.Students.Parts;
using System;

namespace StudentCard.Application.Students.Dtos
{
    public class ElectronicCardDto
    {
        public string Uan { get; set; }

        public string FullName { get; set; }

        public string FullNameAlt { get; set; }

        public string QrCodeImageBg { get; set; }

        public string QrCodeImageEn { get; set; }

        public DateTime BirthDate { get; set; }

        public string FormatedBirthDate { get; set; }

        public bool HasActiveSpecialities { get; set; }

        public bool HasActiveDoctorals { get; set; }
    }
}
