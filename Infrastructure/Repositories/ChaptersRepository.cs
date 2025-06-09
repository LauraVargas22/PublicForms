using System.Linq;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ChaptersRepository : GenericRepository<Chapters>, IChaptersRepository
{
    protected readonly PublicDbContext _context;

    public ChaptersRepository(PublicDbContext context) : base(context)
    {
        _context = context;

    } 

    public override async Task<Chapters> GetByIdAsync(int id)
    {
        return await _context.Chapters
            .FirstOrDefaultAsync(c => c.Id == id) ?? throw new KeyNotFoundException($"Chapters with id {id} was not found");
    } 
}
