using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BuilderAPI;

public class ComputadoraComponenteAuthenticator
    (IComputadoraComponenteRepository computadoraComponenteRepository, IAuthenticator authenticator)
    : IComputadoraComponenteAuthenticator
{
    public async Task<IEnumerable<ComputadoraComponente>> AuthenticateListAsync(int idComputadora)
    {
        return await authenticator.AuthenticateListResponseAsync(
            listFunctionAsync: async () => await computadoraComponenteRepository.ListAsync(idComputadora)
        );
    }

    public async Task<ComputadoraComponente> AuthenticateFindAsync(int id)
    {
        return await authenticator.AuthenticateFindResponseAsync(
            findFunctionAsync: async () => await computadoraComponenteRepository.FindByIdAsync(id)
        );
    }

    public async Task<EntityEntry> AuthenticateAddAsync(ComputadoraComponente computadoraComponente)
    {
        return await authenticator.AuthenticateAddResponseAsync(
            model: computadoraComponente,
            authenticateAction: AuthenticateComputadoraComponente,
            addFunctionAsync: computadoraComponenteRepository.AddAsync
        );
    }

    public async Task AuthenticateAddRangeAsync(IEnumerable<ComputadoraComponente> computadoraComponentes)
    {
        await authenticator.AuthenticateAddRangeResponseAsync(
            models: computadoraComponentes,
            authenticateAction: AuthenticateComputadoraComponentes,
            addRangeActionAsync: computadoraComponenteRepository.AddRangeAsync
        );
    }

    private void AuthenticateComputadoraComponentes(IEnumerable<ComputadoraComponente> computadoraComponentes)
    {
        foreach(var computadoraComponente in computadoraComponentes)
        {
            AuthenticateComputadoraComponente(computadoraComponente);
        }
    }
    private void AuthenticateComputadoraComponente(ComputadoraComponente computadoraComponente)
    {
        //TODO: Authenticate
    }
}