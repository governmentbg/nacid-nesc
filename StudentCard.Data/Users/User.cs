using StudentCard.Data.Common.Interfaces;
using StudentCard.Data.Users.Enums;
using System;
using System.Text.Json.Serialization;

namespace StudentCard.Data.Users
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        [JsonIgnore]
        public string PasswordSalt { get; set; }

        public UserStatus Status { get; set; }

        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public string NewEmailRequest { get; set; }

        public User(string email)
        {
            //We use email as username
            this.Username = email?.Trim().ToLower();
            this.Email = email?.Trim().ToLower();

            this.CreateDate = DateTime.UtcNow;
            this.Status = UserStatus.Inactive;
        }

        public void Activate(string passwordHash, string passwordSalt)
        {
            this.Password = passwordHash;
            this.PasswordSalt = passwordSalt;

            this.UpdateDate = DateTime.UtcNow;
            this.Status = UserStatus.Active;
        }

        public void ChangePassword(string passwordHash, string passwordSalt)
        {
            this.Password = passwordHash;
            this.PasswordSalt = passwordSalt;

            this.UpdateDate = DateTime.UtcNow;
        }
    }
}
