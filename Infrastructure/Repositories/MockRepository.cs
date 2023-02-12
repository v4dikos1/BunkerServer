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

        public IUser CreateUser(string nickname, string password)
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

            return user;
        }

        public bool DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public IUser GetUser(Guid id)
        {
            return _userCollection.FirstOrDefault(u => u.Id == id);
        }

        public IUser GetUserByNickname(string nickname)
        {
            return _userCollection.FirstOrDefault(u => u.Nickname == u.Nickname);
        }

        public bool UpdateUser(Guid id, string nickname, string password)
        {
            throw new NotImplementedException();
        }
    }
}
