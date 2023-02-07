using FileStorageNetCore.Models;
using System;
using System.Collections.Generic;

namespace StudentCard.Application.Portal.Dtos
{
    public class StudentPortalBasicDto
    {
        public string FullName { get; set; }

        public string FullNameAlt { get; set; }

        public string Uan { get; set; }

        public DateTime BirthDate { get; set; }

        public AttachedFile ImgFile { get; set; }

        public List<EducationBasicDto> Universities { get; set; } = new List<EducationBasicDto>();

        public List<EducationBasicDto> Doctorals { get; set; } = new List<EducationBasicDto>();
    }
}
