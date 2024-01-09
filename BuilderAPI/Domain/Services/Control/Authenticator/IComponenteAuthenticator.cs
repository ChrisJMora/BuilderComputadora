using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BuilderAPI;

public interface IComponenteAuthenticator
{
    Task<IEnumerable<Componente>> AuthenticateListAsync();
    Task<Componente> AuthenticateFindByIdAsync(int id);
    Task<EntityEntry> AuthenticateAddAsync(Componente componente);
}
