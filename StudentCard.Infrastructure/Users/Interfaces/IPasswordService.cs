﻿namespace StudentCard.Infrastructure.Users.Interfaces
{
    public interface IPasswordService
    {
        string GenerateSalt(int bitCount);
        string HashPassword(string password, string salt);
        bool VerifyHashedPassword(string hashedPassword, string providedPassword, string salt);
    }
}
