using centralProjectApi.Application.DTOs;
using System.Threading.Tasks;

namespace centralProjectApi.Application.Interfaces
{
    public interface ICategoryService
    {
        Task CreateCategoryAsync(CategoryCreateDto categoryDto);
    }
}
