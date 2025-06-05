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
    }
}