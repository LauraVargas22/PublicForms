using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class OptionsResponseRepository : GenericRepository<OptionsResponse>, IOptionsResponseRepository
    {
        protected readonly PublicDbContext _context;
        public OptionsResponseRepository(PublicDbContext context) : base(context)
        {
            _context = context;
        }
    }
}