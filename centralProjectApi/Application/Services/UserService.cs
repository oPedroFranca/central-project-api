using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using centralProjectApi.Application.DTOs;
using centralProjectApi.Application.Exceptions;
using centralProjectApi.Application.Interfaces;
using centralProjectApi.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace centralProjectApi.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<bool> ValidateCredentialsAsync(string email, string password)
        {
            var existingUser = await _userRepository.DoesEmailExistAsync(email);

            if (!existingUser)
            {
                throw new InvalidOperationException("User not found.");
            }

            var user = await _userRepository.GetUserByEmailAsync(email, password);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Incorrect password");
            }

            return true;
        }
        public async Task Register(UserRegisterDto userDto)
        {
            var existingUser = await _userRepository.DoesEmailExistAsync(userDto.Email);
            if (existingUser)
            {
                throw new UserAlreadyExistsException("User with this email already exists.");
            }

            var user = new User
            {
                Name = userDto.Name,
                UserName = userDto.UserName,
                Email = userDto.Email,
                Password = userDto.Password
            };

            await _userRepository.AddUserAsync(user);
        }

        public void Update(int id, User user)
        {
            Console.WriteLine($"User with ID {id} updated successfully.");
        }

        public void Delete(int id)
        {
            Console.WriteLine($"User with ID {id} deleted successfully.");
        }

        public string GenerateJwtToken(string email)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
