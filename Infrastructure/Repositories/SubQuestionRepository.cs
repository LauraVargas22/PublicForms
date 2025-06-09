using Domain.Entities;
using Infrastructure.Data;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SubQuestionRepository : GenericRepository<SubQuestions>, ISubQuestionsRepository
    {
        protected readonly PublicDbContext _context;

        public SubQuestionRepository(PublicDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<SubQuestions> GetByIdAsync(int id)
        {
            return await _context.SubQuestions
                .FirstOrDefaultAsync(oq => oq.Id == id) ?? throw new KeyNotFoundException($"SubQuestions with id {id} was not found");
        }
    }
}