using centralProjectApi.Application.DTOs;
using centralProjectApi.Application.Interfaces;
using centralProjectApi.Domain.Entities;
using centralProjectApi.Infrastructure.Data;
using centralProjectApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace centralProjectApi.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> ValidateCredentials(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAsync(email, password);
            return user != null;
        }

        public async Task Register(UserRegisterDto userDto)
        {
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
    }
}
