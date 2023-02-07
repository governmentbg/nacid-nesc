using System;

namespace StudentCard.Application.Users.Dtos
{
    public class UserActivationDto
    {
        public string Token { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
