using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BuilderAPI;

public interface IComputadoraAuthenticator
{
    Task<IEnumerable<Computadora>> AuthenticateListAsync();
    Task<Computadora> AuthenticateFindAsync(int id);
    Task<EntityEntry> AuthenticateAddAsync(Computadora computadora);
}
