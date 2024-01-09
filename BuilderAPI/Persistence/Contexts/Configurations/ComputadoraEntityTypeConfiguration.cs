using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuilderAPI;

public class ComputadoraEntityTypeConfiguration : IEntityTypeConfiguration<Computadora>
{
    public void Configure(EntityTypeBuilder<Computadora> builder)
    {
        builder.ToTable("Computadoras");
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Componentes).WithMany().UsingEntity<ComputadoraComponente>(
            x => x.HasOne(x => x.Componente).WithMany().HasForeignKey(x => x.IdComponente),
            x => x.HasOne(x => x.Computadora).WithMany().HasForeignKey(x => x.IdComputadora)
        );
    }
}
