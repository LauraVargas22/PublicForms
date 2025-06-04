using Domain.Entities;
using Infrastructure.Data;
using Application.Interfaces;

namespace Infrastructure.Repositories
{
    public class SubQuestionRepository : GenericRepository<SubQuestions>, ISubQuestionsRepository
    {
        protected readonly PublicDbContext _context;

        public SubQuestionRepository(PublicDbContext context) : base(context)
        {
            _context = context;
        }
    }
}