using System;

namespace StudentCard.Application.Users.Models
{
    public class RegisterInfoDto
    {
        public bool HasActivePersonStudent { get; set; }
        public bool HasActivePersonDoctoral { get; set; }
        public string Email { get; set; }
        public string UAN { get; set; }
        public int ExternalId { get; set; }
        public DateTime BirthDate { get; set; }
        public string Uin { get; set; }
    }
}
