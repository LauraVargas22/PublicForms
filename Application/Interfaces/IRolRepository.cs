using Domain.Entities;

namespace Application.Interfaces
{
    public interface IRolRepository : IGenericRepository<Rol>
    {
        void Attach(Rol rol);
    }
}