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

        public async Task<List<CategoryDto>> GetUserCategoriesAsync()
        {
            var userId = _userContextService.GetCurrentUserId();

            var categories = await _categoryRepository.GetCategoriesByUserIdAsync(userId);

            return categories.Select(category => new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                CreatedAt = category.CreatedAt
            }).ToList();
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

        public async Task UpdateCategoryAsync(CategoryUpdateDto categoryDto)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryDto.Id);
            if (category == null) throw new KeyNotFoundException("Category not found");

            if (!string.IsNullOrWhiteSpace(categoryDto.Name)) category.Name = categoryDto.Name;

            if (categoryDto.Description != null) category.Description = categoryDto.Description;

            category.UpdatedAt = DateTime.UtcNow;

            await _categoryRepository.UpdateCategoryAsync(category);
        }

        public async Task DeleteCategoryAsync(Guid categoryId)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            if (category == null) throw new KeyNotFoundException("Category not found");

            await _categoryRepository.DeleteCategoryAsync(categoryId);
        }
    }
}
