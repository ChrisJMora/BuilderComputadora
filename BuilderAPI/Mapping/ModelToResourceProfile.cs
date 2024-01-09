using AutoMapper;

namespace BuilderAPI;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Componente, ComponenteResource>();
        CreateMap<Computadora, ComputadoraResource>();
    }
}
