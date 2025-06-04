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
}