namespace BuilderAPI;

public class ComputadoraComponenteService
    (IComputadoraComponenteAuthenticator computadoraComponenteAuthenticator)
    : IComputadoraComponenteService
{
    public IEnumerable<ComputadoraComponente> InitComputadoraComponente(Computadora computadora)
    {
        var computadoraComponentes = new List<ComputadoraComponente>();
        foreach(var componente in computadora.Componentes)
        {
            var computadoraComponente = new ComputadoraComponente()
            {
                IdComputadora = computadora.Id,
                IdComponente = componente.Id
            };
            computadoraComponentes.Add(computadoraComponente);
        }
        return computadoraComponentes;
    }

    public async Task<IEnumerable<ComputadoraComponente>> ListComputadoraComponenteAsync(int idComputadora)
    {
        return await computadoraComponenteAuthenticator.AuthenticateListAsync(idComputadora);
    }

    public async Task<ComputadoraComponente> FindComputadoraComponenteAsync(int id)
    {
        return await computadoraComponenteAuthenticator.AuthenticateFindAsync(id);
    }

    public async Task<ComputadoraComponente> AddComputadoraComponenteAsync(ComputadoraComponente nuevoCmputadoraComponente)
    {
        await computadoraComponenteAuthenticator.AuthenticateAddAsync(nuevoCmputadoraComponente);
        return nuevoCmputadoraComponente;
    }

    public async Task AddRangeComputadoraComponenteAsync(IEnumerable<ComputadoraComponente> computadoraComponentes)
    {
        await computadoraComponenteAuthenticator.AuthenticateAddRangeAsync(computadoraComponentes);
    }
}
