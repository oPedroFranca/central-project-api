using centralProjectApi.Application.DTOs;
using centralProjectApi.Application.Interfaces;
using centralProjectApi.Domain.Entities;
using System.Security.Claims;

namespace centralProjectApi.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoryService(ICategoryRepository categoryRepository, IHttpContextAccessor httpContextAccessor)
        {
            _categoryRepository = categoryRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateCategoryAsync(CategoryCreateDto categoryDto)
        {
            if (string.IsNullOrWhiteSpace(categoryDto.Name))
                throw new ArgumentException("Category name is required");

            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out var userId))
                throw new UnauthorizedAccessException("Invalid or missing user token.");

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
