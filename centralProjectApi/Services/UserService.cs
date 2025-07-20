using centralProjectApi.Data;
using centralProjectApi.Models;
using centralProjectApi.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace centralProjectApi.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public bool ValidateCredentials(string email, string password)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Email == email && u.Password == password);

            return user != null;
        }

        public void Register(UserRegisterDto userDto)
        {
            var user = new User
            {
                Name = userDto.Name,
                UserName = userDto.UserName,
                Email = userDto.Email,
                Password = userDto.Password
            };

            _context.Users.Add(user);
            _context.SaveChanges();
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
