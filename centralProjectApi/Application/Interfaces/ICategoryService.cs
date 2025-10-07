using centralProjectApi.Application.DTOs;
using centralProjectApi.Domain.Entities;

namespace centralProjectApi.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetUserCategoriesAsync();
        Task CreateCategoryAsync(CategoryCreateDto categoryDto);
        Task UpdateCategoryAsync(CategoryUpdateDto categoryDto);
        Task DeleteCategoryAsync(int categoryId);
    }
}
