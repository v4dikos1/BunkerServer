using BunkerServer.ViewModels;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BunkerServer.Controllers
{
    [ApiController]
    [Route("api/user/auth")]
    public class AuthControlles : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHashService _passwordHashService;

        public AuthControlles(IRepository repository, ITokenService tokenService, IPasswordHashService passwordHashService)
        {
            _repository = repository;
            _tokenService = tokenService;
            _passwordHashService = passwordHashService;
        }

        [HttpPost("register")]
        public ActionResult<UserResponseDto> Register(UserRegistrationDto request)
        {
            var user = _repository.CreateUser(request.Nickname, request.Password);

            UserResponseDto response = new UserResponseDto
            {
                Nickname = request.Nickname,
                Password = request.Password,
                Id = user.Id
            };
            
            return Ok(response);
        }

        [HttpPost("login")]
        public ActionResult<string> Login(UserLoginDto request)
        {
            var user = _repository.GetUserByNickname(request.Nickname);
            if (user == null)
            {
                return BadRequest("Пользователь с таким никнеймом не найден!");
            }

            if (!_passwordHashService.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Неверный пароль.");
            }

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Nickname.ToString())
            };

            string token = _tokenService.CreateToken(user, claims);

            return Ok(token);
        }
    }
}
