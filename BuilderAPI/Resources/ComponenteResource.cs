namespace BuilderAPI;

public class ComponenteResource : IResource
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = null!;
}
