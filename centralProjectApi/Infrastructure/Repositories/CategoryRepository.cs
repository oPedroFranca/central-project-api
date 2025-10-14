using centralProjectApi.Application.Interfaces;
using centralProjectApi.Domain.Entities;
using centralProjectApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace centralProjectApi.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetCategoriesByUserIdAsync(Guid userId)
        {
            return await _context.Categories
                .Where(category => category.UserId == userId)
                .OrderByDescending(category => category.CreatedAt)
                .ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(Guid categoryId)
        {
            return await _context.Categories.FindAsync(categoryId);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            var existingCategory = await _context.Categories.FindAsync(category.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;
                existingCategory.UpdatedAt = category.UpdatedAt;
                // Não altera o UserId!
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCategoryAsync(Guid categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}
