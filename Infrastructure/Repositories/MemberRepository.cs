using Application.Interfaces; 
using Domain.Entities; 
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserMemberRepository : GenericRepository<UserMember>, IUserMemberRepository
    {
        private readonly PublicDbContext _context;
        public UserMemberRepository(PublicDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserMember> GetByUsernameAsync(string username)
        {
            return await _context.UserMembers
                .Include(u => u.MemberRols)
                    .ThenInclude(mr => mr.Rol)
                .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
        }

        public async Task<UserMember> GetByRefreshTokenAsync(string refreshToken)
        {
            return await _context.UserMembers
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.RefreshTokens.Any(rt => rt.Token == refreshToken));
        }
    }
}