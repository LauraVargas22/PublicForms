using Domain.Entities;
using Infrastructure.Data;
using Application.Interfaces;

namespace Infrastructure.Repositories
{
    public class SurveysRepository : GenericRepository<Surveys>, ISurveysRepository
    {
        protected readonly PublicDbContext _context;

        public SurveysRepository(PublicDbContext context) : base(context)
        {
            _context = context;
        }
    }
}