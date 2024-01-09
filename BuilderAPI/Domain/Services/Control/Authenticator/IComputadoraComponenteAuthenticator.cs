using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BuilderAPI;

public interface IComputadoraComponenteAuthenticator
{
    Task<IEnumerable<ComputadoraComponente>> AuthenticateListAsync(int idComputadora);
    Task<ComputadoraComponente> AuthenticateFindAsync(int id);
    Task<EntityEntry> AuthenticateAddAsync(ComputadoraComponente computadoraComponente);
    Task AuthenticateAddRangeAsync(IEnumerable<ComputadoraComponente> computadoraComponentes);
}
