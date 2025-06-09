using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;

public class CategoriesCatalogRepository : GenericRepository<CategoriesCatalog>, ICategoriesCatalogRepository
{
    protected readonly PublicDbContext _context;

    public CategoriesCatalogRepository(PublicDbContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<CategoriesCatalog> GetByIdAsync(int id)
    {
        return await _context.CategoriesCatalog
            .FirstOrDefaultAsync(cc => cc.Id == id) ?? throw new KeyNotFoundException($"Categories Catalog with id {id} was not found");
    }
}