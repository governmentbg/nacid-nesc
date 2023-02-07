namespace StudentCard.Infrastructure.Interfaces
{
    public interface IUserContext
    {
        int UserId { get; }
        string Username { get; }
        string Role { get; }
    }
}
