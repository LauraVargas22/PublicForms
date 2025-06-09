using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OptionsResponseRepository : GenericRepository<OptionsResponse>, IOptionsResponseRepository
    {
        protected readonly PublicDbContext _context;
        public OptionsResponseRepository(PublicDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<OptionsResponse> GetByIdAsync(int id)
        {
            return await _context.OptionsResponse
                .FirstOrDefaultAsync(c => c.Id == id) ?? throw new KeyNotFoundException($"Options Response with id {id} was not found");
        } 
    }
}