using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BuilderAPI;

public interface IComputadoraRepository
{
    Task<IEnumerable<Computadora>> ListAsync();
    Task<Computadora?> FindByIdAsync(int id);
    Task<EntityEntry> AddAsync(Computadora computadora);    
}
