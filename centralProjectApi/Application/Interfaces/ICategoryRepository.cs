using centralProjectApi.Domain.Entities;

namespace centralProjectApi.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategoriesByUserIdAsync(Guid userId);
        Task AddCategoryAsync(Category category);
        Task<Category?> GetCategoryByIdAsync(int categoryId);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int categoryId);
    }
}
