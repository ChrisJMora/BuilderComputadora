using AutoMapper;

namespace BuilderAPI;

public class ResourceToModelProfle : Profile
{
    public ResourceToModelProfle()
    {
        CreateMap<SaveComputadoraResource, Computadora>();
    }
}
