namespace BuilderAPI;

public interface IMapperAuthenticator
{
    TResult MapAndValidateEntity<T, TResult>
        (T resource) where T : ISaveResource where TResult : IModel;

    TResult MapResourceFromEntity<T, TResult>
        (T entity) where T : IModel where TResult : IResource;

    IEnumerable<TResult> MapResourcesFromEntities<T, TResult>
        (IEnumerable<T> entities) where T : IModel where TResult : IResource;
}
