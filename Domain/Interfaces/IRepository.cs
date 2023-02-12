namespace Domain.Interfaces
{
    public interface IRepository
    {
        IUser GetUser(Guid id);
        IUser CreateUser(string nickname, string password);
        bool DeleteUser(Guid id);
        bool UpdateUser(Guid id, string nickname, string password);

        IUser GetUserByNickname(string nickname);
    }
}
