using centralProjectApi.Application.DTOs;
using centralProjectApi.Domain.Entities;

namespace centralProjectApi.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> ValidateCredentials(string email, string password);
        Task Register(UserRegisterDto user);
        void Update(int id, User user);
        void Delete(int id);
    }
}