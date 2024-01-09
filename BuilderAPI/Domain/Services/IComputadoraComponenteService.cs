namespace BuilderAPI;

public interface IComputadoraComponenteService
{
    IEnumerable<ComputadoraComponente> InitComputadoraComponente(Computadora computadora);
    Task<IEnumerable<ComputadoraComponente>> ListComputadoraComponenteAsync(int idComputadora);
    Task<ComputadoraComponente> FindComputadoraComponenteAsync(int id);
    Task<ComputadoraComponente> AddComputadoraComponenteAsync(ComputadoraComponente nuevoCmputadoraComponente);
    Task AddRangeComputadoraComponenteAsync(IEnumerable<ComputadoraComponente> computadoraComponentes);
}
