using System.ComponentModel.Design;

namespace BuilderAPI;

public interface IComponenteService
{
    Task<IEnumerable<Componente>> ListComponentesAsync();
    Task<IEnumerable<Componente>> ListComponentesAsync(IEnumerable<ComputadoraComponente> computadoraComponentes);
    Task<IEnumerable<Componente>> ListComponentesAsync(IEnumerable<int> ids);
    Task<Componente> FindComponenteAsync(int id);
    Task<Componente> AddComponenteAsync(Componente nuevoComponente);
}
