using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BuilderAPI;

public class Componente : IModel
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = null!;
}
