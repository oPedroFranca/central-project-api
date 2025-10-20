using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using centralProjectApi.Domain.Entities;

namespace centralProjectApi.Domain.Interfaces
{
    public interface ICardProjectRepository
    {
        Task<IEnumerable<CardProject>> GetListProjectCardsByUserIdAsync(Guid userId);
        Task<IEnumerable<CardProject>> GetListProjectCardsByCategoryIdAsync(Guid categoryId);
    }
}
