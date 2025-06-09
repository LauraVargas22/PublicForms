using System.Linq;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CategoryOptionsRepository : GenericRepository<CategoryOptions>, ICategoryOptionsRepository
    {
        protected readonly PublicDbContext _context;

        public CategoryOptionsRepository(PublicDbContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<CategoryOptions> GetByIdAsync(int id)
        {
            return await _context.CategoryOptions
                .FirstOrDefaultAsync(co => co.Id == id) ?? throw new KeyNotFoundException($"CategoryOptions with id {id} was not found");
        }
    }

}