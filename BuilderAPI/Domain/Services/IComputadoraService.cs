namespace BuilderAPI;

public interface IComputadoraService
{
    Task<IEnumerable<Computadora>> ListComputadoraAsync();
    Task<Computadora> FindComputadoraAsync(int id);
    Task<Computadora> AddComputadoraAsync(Computadora nuevaComputadora, IEnumerable<int> componenteIds);
}
