using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MemberRols : BaseEntity
    {
        public int MemberId { get; set; }
        public Member Member { get; set; } = new Member(); 
        public int RolId { get; set; } 
        public Rol Rol { get; set; } = new Rol();
    }
}