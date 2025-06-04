using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class QuestionsRepository : GenericRepository<Questions>, IQuestionsRepository
    {
        protected readonly PublicDbContext _context;

        public QuestionsRepository(PublicDbContext context) : base(context)
        {
            _context = context;

        }
    }
}