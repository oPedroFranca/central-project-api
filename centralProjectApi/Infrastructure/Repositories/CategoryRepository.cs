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
    }
}
