using centralProjectApi.Application.DTOs;
using centralProjectApi.Application.Interfaces;
using centralProjectApi.Domain.Entities;

namespace centralProjectApi.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CreateCategoryAsync(CategoryCreateDto categoryDto)
        {
            // Aqui futuramente você pode pegar o UserId pelo token JWT
            if (string.IsNullOrWhiteSpace(categoryDto.Name))
                throw new ArgumentException("Category name is required");

            var fakeUserId = Guid.Parse("ce69606b-dfae-4e7f-856b-23a9c1414144");

            var category = new Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                UserId = fakeUserId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _categoryRepository.AddCategoryAsync(category);
        }
    }
}
