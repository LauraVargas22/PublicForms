using Domain.Entities;
using Infrastructure.Data;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SurveysRepository : GenericRepository<Surveys>, ISurveysRepository
    {
        protected readonly PublicDbContext _context;

        public SurveysRepository(PublicDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Surveys> GetByIdAsync(int id)
        {
            return await _context.Surveys
                .FirstOrDefaultAsync(oq => oq.Id == id) ?? throw new KeyNotFoundException($"Surveys with id {id} was not found");
        }
    }
}