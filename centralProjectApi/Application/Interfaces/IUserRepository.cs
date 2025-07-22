using centralProjectApi.Application.DTOs;
using centralProjectApi.Domain.Entities;

namespace centralProjectApi.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email, string password);
        Task<User> AddUserAsync(User user);
    }
}