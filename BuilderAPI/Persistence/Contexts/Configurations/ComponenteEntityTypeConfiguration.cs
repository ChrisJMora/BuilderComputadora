using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuilderAPI;

public class ComponenteEntityTypeConfiguration : IEntityTypeConfiguration<Componente>
{
    public void Configure(EntityTypeBuilder<Componente> builder)
    {
        builder.ToTable("Componentes");
        builder.HasKey(x => x.Id);

        builder.HasData(new ListaComponentes().Componentes);
    }
}
