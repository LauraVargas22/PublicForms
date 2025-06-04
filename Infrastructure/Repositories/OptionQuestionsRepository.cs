using Domain.Entities;
using Infrastructure.Data;
using Application.Interfaces;

namespace Infrastructure.Repositories
{
    public class OptionQuestionsRepository : GenericRepository<OptionQuestions>, IOptionQuestionsRepository
    {
        protected readonly PublicDbContext _context;
        public OptionQuestionsRepository(PublicDbContext context) : base(context)
        {
            _context = context;
        }
    }
}