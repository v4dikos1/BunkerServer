using Domain.Interfaces;

namespace Domain.Models
{
    public class User : IUser
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; } = String.Empty;
        public byte[] PasswordSalt { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
    }
}
