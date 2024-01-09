using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BuilderAPI;

public class ComponenteAuthenticator
    (IComponenteRepository componenteRepository, IAuthenticator authenticator)
    : IComponenteAuthenticator
{
    public async Task<IEnumerable<Componente>> AuthenticateListAsync()
    {
        return await authenticator.AuthenticateListResponseAsync(
            listFunctionAsync: componenteRepository.ListAsync
        );
    }

    public async Task<Componente> AuthenticateFindByIdAsync(int id)
    {
        return await authenticator.AuthenticateFindResponseAsync(
            findFunctionAsync: () => componenteRepository.FindByIdAsync(id)
        );
    }

    public async Task<EntityEntry> AuthenticateAddAsync(Componente componente)
    {
        return await authenticator.AuthenticateAddResponseAsync(
            model: componente,
            authenticateAction: AuthenticateComponente,
            addFunctionAsync: componenteRepository.AddAsync
        );
    }

    private void AuthenticateComponente(Componente componente)
    {
        // TODO: Autenticar
    }
}   
