using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BuilderAPI;

public interface IComputadoraComponenteRepository
{
    Task<IEnumerable<ComputadoraComponente>> ListAsync(int idComputadora);
    Task<ComputadoraComponente?> FindByIdAsync(int id);
    Task<EntityEntry> AddAsync(ComputadoraComponente computadoraComponente);
    Task AddRangeAsync(IEnumerable<ComputadoraComponente> computadoraComponentes);
}
