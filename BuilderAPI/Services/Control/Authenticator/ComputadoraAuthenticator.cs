using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BuilderAPI;

public class ComputadoraAuthenticator
    (IComputadoraRepository computadoraRepository, IAuthenticator authenticator)
    : IComputadoraAuthenticator
{
    public async Task<IEnumerable<Computadora>> AuthenticateListAsync()
    {
        return await authenticator.AuthenticateListResponseAsync(
            listFunctionAsync: computadoraRepository.ListAsync
        );
    }

    public async Task<Computadora> AuthenticateFindAsync(int id)
    {
        return await authenticator.AuthenticateFindResponseAsync(
            findFunctionAsync: () => computadoraRepository.FindByIdAsync(id)
        );
    }

    public async Task<EntityEntry> AuthenticateAddAsync(Computadora computadora)
    {
        return await authenticator.AuthenticateAddResponseAsync(
            model: computadora,
            authenticateAction: AuthenticateComputadora,
            addFunctionAsync: computadoraRepository.AddAsync
        );
    }

    private void AuthenticateComputadora(Computadora computadora)
    {
        // TODO: Autenticar
    }
}
