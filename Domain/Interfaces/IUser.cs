namespace Domain.Interfaces
{
    public interface IUser
    {
     Guid Id { get; set; }
     string Nickname { get; set; }
     byte[] PasswordSalt { get; set; }
     byte[] PasswordHash { get; set; }
    }
}
