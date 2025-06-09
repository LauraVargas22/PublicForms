using Domain.Entities;
using Infrastructure.Data;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OptionQuestionsRepository : GenericRepository<OptionQuestions>, IOptionQuestionsRepository
    {
        protected readonly PublicDbContext _context;
        public OptionQuestionsRepository(PublicDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<OptionQuestions> GetByIdAsync(int id)
        {
            return await _context.OptionQuestions
                .FirstOrDefaultAsync(oq => oq.Id == id) ?? throw new KeyNotFoundException($"Option Questions with id {id} was not found");
        }
    }
}