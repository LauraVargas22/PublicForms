using Application.Interfaces; 
using Domain.Entities; 
using Infrastructure.Data; 

namespace Infrastructure.Repositories
{
    public class RolRepository : GenericRepository<Rol>, IRolRepository
    {
        private readonly PublicDbContext _context;
        public RolRepository(PublicDbContext context) : base(context)
        {
            _context = context;
        }

        public void Attach(Rol rol)
        {
            if (rol == null) throw new ArgumentNullException(nameof(rol));
            _context.Rols.Attach(rol);
        }
    }
}