using StudentCard.Data.Common.Interfaces;
using StudentCard.Data.Users;
using System;

namespace StudentCard.Data.Students
{
    public class Student : IEntity
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string UAN { get; set; }

        public int ExternalId { get; set; }

        public DateTime BirthDate { get; set; }

        public string Uin { get; set; }

        public User User { get; set; }

        public void AddUser(string email)
        {
            this.User = new User(email);
        }
        public void ChangeEmail(string newEmail)
        {
            this.Email = newEmail;
            this.User.Email = newEmail;
            this.User.Username = newEmail;
        }

    }
}
