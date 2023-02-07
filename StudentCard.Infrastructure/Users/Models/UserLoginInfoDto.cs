namespace StudentCard.Application.Users.Dtos
{
    public class UserLoginInfoDto
    {
        public string Token { get; set; }

        public string Username { get; set; }

        public string Uan { get; set; }

        public string FullName { get; set; }
        public string FullNameAlt { get; set; }
    }
}
