namespace BuilderAPI;

public class ListaComponentes
{
    public List<Componente> Componentes { get; set; } = new List<Componente>();

    public ListaComponentes()
    {
        Componentes.Add(new Componente { Id = 1, Descripcion = "Tarjeta de video" });
        Componentes.Add(new Componente { Id = 2, Descripcion = "Gabinete" });
        Componentes.Add(new Componente { Id = 3, Descripcion = "Monitor" });
        Componentes.Add(new Componente { Id = 4, Descripcion = "Teclado" });
        Componentes.Add(new Componente { Id = 5, Descripcion = "Mouse" });
        Componentes.Add(new Componente { Id = 6, Descripcion = "Parlantes" });
    }
}
