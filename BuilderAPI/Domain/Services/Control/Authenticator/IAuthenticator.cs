using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BuilderAPI;

public interface IAuthenticator
{
    Task<IEnumerable<T>> AuthenticateListResponseAsync<T>
        (Func<Task<IEnumerable<T>>> listFunctionAsync) where T : IModel;
    
    Task<T> AuthenticateFindResponseAsync<T>
        (Func<Task<T?>> findFunctionAsync) where T : IModel;

    Task<EntityEntry> AuthenticateAddResponseAsync<T>
        (T model, Action<T> authenticateAction,
        Func<T,Task<EntityEntry>> addFunctionAsync) where T : IModel;

    Task AuthenticateAddRangeResponseAsync<T>
        (IEnumerable<T> models, Action<IEnumerable<T>> authenticateAction,
        Func<IEnumerable<T>,Task> addRangeActionAsync) where T : IModel;
    
    EntityEntry AuthenticateUpdateResponse<T>
        (T model, Func<T, EntityEntry> updateFunction) where T : IModel;

    EntityEntry AuthenticateRemoveResponse<T>
        (T model, Func<T, EntityEntry> removeFunction) where T : IModel;
}
