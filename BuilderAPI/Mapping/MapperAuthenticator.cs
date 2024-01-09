using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace BuilderAPI;

public class MapperAuthenticator
    (IMapper mapper) 
    : Controller, IMapperAuthenticator
{
    public TResult MapAndValidateEntity<T, TResult>
        (T resource) where T : ISaveResource where TResult : IModel
    {
        ValidateModelState();
        return mapper.Map<T, TResult>(resource);
    }

    public TResult MapResourceFromEntity<T, TResult>
        (T entity) where T : IModel where TResult : IResource
    {
        return mapper.Map<T, TResult>(entity);
    }

    public IEnumerable<TResult> MapResourcesFromEntities<T, TResult>
        (IEnumerable<T> entities) where T : IModel where TResult : IResource
    {
        return mapper.Map<IEnumerable<T>, IEnumerable<TResult>>(entities);
    }

    private void ValidateModelState()
    {
        if (!ModelState.IsValid)
            throw new Exception(ModelState.GetErrorMessages().ToString());
    }

}
