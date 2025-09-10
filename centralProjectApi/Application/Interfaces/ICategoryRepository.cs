using centralProjectApi.Domain.Entities;

namespace centralProjectApi.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task AddCategoryAsync(Category category);
    }
}
