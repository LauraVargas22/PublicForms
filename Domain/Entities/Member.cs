using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Member : BaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public ICollection<MemberRols> MemberRols { get; set; } = new HashSet<MemberRols>(); 
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();
    }
}