namespace BunkerServer.ViewModels
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
    }
}
