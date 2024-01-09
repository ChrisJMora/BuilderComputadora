using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BuilderAPI;

public interface IComponenteRepository
{
    Task<IEnumerable<Componente>> ListAsync();
    Task<Componente?> FindByIdAsync(int id);
    Task<EntityEntry> AddAsync(Componente componente);
}
