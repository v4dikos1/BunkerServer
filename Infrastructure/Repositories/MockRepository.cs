using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Services;

namespace Infrastructure.Repositories
{
    public class MockRepository : IRepository
    {
        private List<IUser> _userCollection;
        private readonly IPasswordHashService _passwordHashService;

        public MockRepository(IPasswordHashService passwordHashService)
        {
            _userCollection = new ();
            _passwordHashService = passwordHashService;
        }

        public void CreateUser(string nickname, string password)
        {
            _passwordHashService.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            IUser user = new User
            {
                Nickname = nickname,
                Id = Guid.NewGuid(),
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _userCollection.Add(user);
        }

        public bool DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public IUser GetUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public IUser GetUserByNickname(string nickname)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(Guid id, string nickname, string password)
        {
            throw new NotImplementedException();
        }
    }
}
