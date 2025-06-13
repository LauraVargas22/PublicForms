using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MemberRols : BaseEntity
    {
        public int UserMemberId { get; set; }
        public UserMember UserMembers { get; set; } = new UserMember(); 
        public int RolId { get; set; } 
        public Rol Rol { get; set; } = new Rol();
    }
}