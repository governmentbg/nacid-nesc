using System;

namespace StudentCard.Application.Users.Dtos
{
    public class UserActivationNewEmailAddressDto
    {
        public string Token { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
