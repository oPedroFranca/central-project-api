using centralProjectApi.Application.DTOs;
using centralProjectApi.Application.Interfaces;
using centralProjectApi.Domain.Entities;

namespace centralProjectApi.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserContextService _userContextService;

        public CategoryService(ICategoryRepository categoryRepository, IUserContextService userContextService)
        {
            _categoryRepository  = categoryRepository;
            _userContextService  = userContextService;
        }

        public async Task CreateCategoryAsync(CategoryCreateDto categoryDto)
        {
            if (string.IsNullOrWhiteSpace(categoryDto.Name))
                throw new ArgumentException("Category name is required");

            var userId = _userContextService.GetCurrentUserId();

            var category = new Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _categoryRepository.AddCategoryAsync(category);
        }
    }
}
