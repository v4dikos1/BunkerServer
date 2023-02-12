using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure.Services
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer";
        public const string AUDIENCE = "MyAuthClient";
        const string KEY = "auhfuahfauhfau282";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new(Encoding.UTF8.GetBytes(KEY));
    }
}
