namespace StudentCard.Infrastructure.Users.Interfaces
{
    public interface IJWTService
    {
        string CreateToken(int userId, string username);
    }
}
