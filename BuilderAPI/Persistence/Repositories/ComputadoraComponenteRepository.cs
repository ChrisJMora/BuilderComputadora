using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BuilderAPI;

public class ComputadoraComponenteRepository : IComputadoraComponenteRepository
{
    private readonly AppDbContext _context;

    public ComputadoraComponenteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ComputadoraComponente>> ListAsync(int idComputadora)
    {
        return await _context.ComputadoraComponentes.Where(e => e.IdComputadora == idComputadora).ToListAsync();        ;
    }

    public async Task<ComputadoraComponente?> FindByIdAsync(int id)
    {
        return await _context.ComputadoraComponentes.FindAsync(id);
    }

    public async Task<EntityEntry> AddAsync(ComputadoraComponente computadoraComponente)
    {
        return await _context.ComputadoraComponentes.AddAsync(computadoraComponente);
    }

    public async Task AddRangeAsync(IEnumerable<ComputadoraComponente> computadoraComponentes)
    {
        await _context.ComputadoraComponentes.AddRangeAsync(computadoraComponentes);
    }
}
