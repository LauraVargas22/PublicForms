using Domain.Entities;
using Infrastructure.Data;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SumaryOptionsRepository : GenericRepository<SumaryOptions>, ISumaryOptionsRepository
    {
        protected readonly PublicDbContext _context;

        public SumaryOptionsRepository(PublicDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<SumaryOptions> GetByIdAsync(int id)
        {
            return await _context.SumaryOptions
                .FirstOrDefaultAsync(oq => oq.Id == id) ?? throw new KeyNotFoundException($"Sumary Options with id {id} was not found");
        }
    }
}