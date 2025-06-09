using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class QuestionsRepository : GenericRepository<Questions>, IQuestionsRepository
    {
        protected readonly PublicDbContext _context;

        public QuestionsRepository(PublicDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Questions> GetByIdAsync(int id)
        {
            return await _context.Questions
                .FirstOrDefaultAsync(oq => oq.Id == id) ?? throw new KeyNotFoundException($"Questions with id {id} was not found");
        }
    }
}