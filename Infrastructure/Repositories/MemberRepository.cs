using Application.Interfaces; 
using Domain.Entities; 
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        private readonly PublicDbContext _context;
        public MemberRepository(PublicDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Member> GetByUsernameAsync(string username)
        {
            return await _context.Members
                .Include(u => u.MemberRols)
                    .ThenInclude(mr => mr.Rol)
                .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
        }
    }
}