using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BuilderAPI;

public class ComputadoraRepository : IComputadoraRepository
{
    private readonly AppDbContext _context;

    public ComputadoraRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Computadora>> ListAsync()
    {
        return await _context.Computadoras.ToListAsync();        ;
    }

    public async Task<Computadora?> FindByIdAsync(int id)
    {
        return await _context.Computadoras.FindAsync(id);
    }

    public async Task<EntityEntry> AddAsync(Computadora computadora)
    {
        return await _context.Computadoras.AddAsync(computadora);
    }
}
