namespace BuilderAPI;

public class ComponenteService
    (IComponenteAuthenticator componenteAuthenticator, IUnitOfWork unitOfWork)
    : IComponenteService
{
    public async Task<IEnumerable<Componente>> ListComponentesAsync()
    {
        return await componenteAuthenticator.AuthenticateListAsync();
    }

    public async Task<IEnumerable<Componente>> ListComponentesAsync(IEnumerable<ComputadoraComponente> computadoraComponentes)
    {
        List<Componente> componentes = [];
        foreach(var computadoraComponente in computadoraComponentes)
        {
            var componente = await FindComponenteAsync(computadoraComponente.IdComponente);
            componentes.Add(componente);
        }
        return componentes;
    }

    public async Task<IEnumerable<Componente>> ListComponentesAsync(IEnumerable<int> ids)
    {
        List<Componente> componentes = [];
        foreach(var id in ids)
        {
            var componente = await FindComponenteAsync(id);
            componentes.Add(componente);
        }
        return componentes;
    }

    public async Task<Componente> FindComponenteAsync(int id)
    {
        return await componenteAuthenticator.AuthenticateFindByIdAsync(id);
    }

    public async Task<Componente> AddComponenteAsync(Componente nuevoComponente)
    {
        await componenteAuthenticator.AuthenticateAddAsync(nuevoComponente);
        await unitOfWork.CompleteAsync();
        return nuevoComponente;
    }
}
