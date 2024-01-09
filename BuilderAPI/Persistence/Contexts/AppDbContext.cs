using Microsoft.EntityFrameworkCore;

namespace BuilderAPI;

public class AppDbContext : DbContext
{
    public DbSet<Computadora> Computadoras { get; set; }
    public DbSet<Componente> Componentes { get; set; }
    public DbSet<ComputadoraComponente> ComputadoraComponentes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    
        new ComputadoraEntityTypeConfiguration().Configure(builder.Entity<Computadora>());
        new ComponenteEntityTypeConfiguration().Configure(builder.Entity<Componente>());
    }
}
