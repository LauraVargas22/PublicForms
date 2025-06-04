using Domain.Entities;
using Infrastructure.Data;
using Application.Interfaces;

namespace Infrastructure.Repositories
{
    public class SumaryOptionsRepository : GenericRepository<SumaryOptions>, ISumaryOptionsRepository
    {
        protected readonly PublicDbContext _context;

        public SumaryOptionsRepository(PublicDbContext context) : base(context)
        {
            _context = context;
        }
    }
}