using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BuilderAPI;

public class ComponenteRepository : IComponenteRepository
{
    private readonly AppDbContext _context;

    public ComponenteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Componente>> ListAsync()
    {
        return await _context.Componentes.ToListAsync();        ;
    }

    public async Task<Componente?> FindByIdAsync(int id)
    {
        return await _context.Componentes.FindAsync(id);
    }

    public async Task<EntityEntry> AddAsync(Componente componente)
    {
        return await _context.Componentes.AddAsync(componente);
    }
}
