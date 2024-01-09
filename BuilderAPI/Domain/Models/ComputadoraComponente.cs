namespace BuilderAPI;

public class ComputadoraComponente : IModel
{
    public int Id { get; set; }
    public int IdComputadora { get; set; }
    public int IdComponente { get; set; }

    public Computadora Computadora { get; set; } = null!;
    public Componente Componente { get; set; } = null!;
}
