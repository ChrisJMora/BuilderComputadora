namespace BuilderAPI;

public class ComputadoraService
    (IComputadoraAuthenticator computadoraAuthenticator, IComponenteService componenteService,
     IComputadoraComponenteService computadoraComponenteService, IUnitOfWork unitOfWork)
    : IComputadoraService
{
    public async Task<IEnumerable<Computadora>> ListComputadoraAsync()
    {
        var computadoras = await computadoraAuthenticator.AuthenticateListAsync();
        foreach(var computadora in computadoras)
        {
            var computadoraComponentes = await computadoraComponenteService.ListComputadoraComponenteAsync(computadora.Id);
            computadora.Componentes = await componenteService.ListComponentesAsync(computadoraComponentes);
        }
        return computadoras;
    }

    public async Task<Computadora> FindComputadoraAsync(int id)
    {
        var computadora = await computadoraAuthenticator.AuthenticateFindAsync(id);
        var computadoraComponentes = await computadoraComponenteService.ListComputadoraComponenteAsync(computadora.Id);
        computadora.Componentes = await componenteService.ListComponentesAsync(computadoraComponentes);
        return computadora;
    }

    public async Task<Computadora> AddComputadoraAsync(Computadora nuevaComputadora, IEnumerable<int> componenteIds)
    {
        nuevaComputadora.Componentes = await componenteService.ListComponentesAsync(componenteIds);

        // Agrega la nueva computadora
        await computadoraAuthenticator.AuthenticateAddAsync(nuevaComputadora);
        // Guarda los cambios
        await unitOfWork.CompleteAsync();

        // // Agrega las relaciones entre computadora y sus componentes
        // var computadoraComponentes = computadoraComponenteService
        //         .InitComputadoraComponente(nuevaComputadora);
        // await computadoraComponenteService.AddRangeComputadoraComponenteAsync(computadoraComponentes);
        // // Guarda los cambios
        // await unitOfWork.CompleteAsync();

        return nuevaComputadora;
    }
}
