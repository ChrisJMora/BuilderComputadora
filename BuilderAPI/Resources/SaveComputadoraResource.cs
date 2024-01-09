namespace BuilderAPI;

public class SaveComputadoraResource : ISaveResource
{
    public int MemoriaRam { get; set; }
    public int Almacenamiento { get; set; }
    public int NucleosProcesador { get; set;}
    public int PuertosUsb { get; set;}
    public IEnumerable<int> ComponentesIds { get; set; } = new List<int>();
}
