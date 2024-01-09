using System.ComponentModel.DataAnnotations.Schema;

namespace BuilderAPI;

[ComplexType]
public class Computadora : IModel
{
        public int Id { get; set; }
        public int MemoriaRam { get; set; }
        public int Almacenamiento { get; set; }
        public int NucleosProcesador { get; set;}
        public int PuertosUsb { get; set;}

        public IEnumerable<Componente> Componentes { get; set; } = new List<Componente>();
}