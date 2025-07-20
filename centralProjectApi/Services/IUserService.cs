using centralProjectApi.Models;
using centralProjectApi.Models.DTO;

namespace centralProjectApi.Services
{
    public interface IUserService
    {
        bool ValidateCredentials(string email, string password);
        void Register(UserRegisterDto user);
        void Update(int id, User user);
        void Delete(int id);
    }
}