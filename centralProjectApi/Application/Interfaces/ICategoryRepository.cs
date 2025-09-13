using centralProjectApi.Domain.Entities;

namespace centralProjectApi.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategoriesByUserIdAsync(Guid userId);
        Task AddCategoryAsync(Category category);
    }
}
