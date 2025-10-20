using centralProjectApi.Domain.Entities;
using centralProjectApi.Domain.Interfaces;
using centralProjectApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace centralProjectApi.Infrastructure.Repositories
{
  public class CardProjectRepository : ICardProjectRepository
  {
    private readonly AppDbContext _context;

    public CardProjectRepository(AppDbContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<CardProject>> GetListProjectCardsByUserIdAsync(Guid userId)
    {
      return await _context.CardProjects
          .Include(cp => cp.Category)
          .Include(cp => cp.Participants)
          .Where(cp => cp.Category != null && cp.Category.UserId == userId)
          .ToListAsync();
    }

    public async Task<IEnumerable<CardProject>> GetListProjectCardsByCategoryIdAsync(Guid categoryId)
    {
      return await _context.CardProjects
          .Include(cp => cp.Category)
          .Include(cp => cp.Participants)
          .Where(cp => cp.CategoryId == categoryId)
          .ToListAsync();
    }
  }
}
