namespace BuilderAPI;

public class ComputadoraResource : IResource
{
    public int Id {get; set; }
    public int MemoriaRam { get; set; }
    public int Almacenamiento { get; set; }
    public int NucleosProcesador { get; set;}
    public int PuertosUsb { get; set;}
    public IEnumerable<ComponenteResource> Componentes { get; set; } = new List<ComponenteResource>();
}
