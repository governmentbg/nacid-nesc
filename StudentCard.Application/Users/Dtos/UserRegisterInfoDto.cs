using StudentCard.Application.Users.Enums;

namespace StudentCard.Application.Users.Models
{
    public class UserRegisterInfoDto
    {
        public string Email { get; set; }
        public RegisterIdentificationEnum IdentificationType { get; set; }
        public string Identificator { get; set; }
    }
}
