using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BuilderAPI;

public class AuthenticatorService : IAuthenticator
{
    // List async
    public async Task<IEnumerable<T>> AuthenticateListResponseAsync<T>
        (Func<Task<IEnumerable<T>>> listFunctionAsync) where T : IModel
    {
        var entities = await listFunctionAsync();
        if (!entities.Any()) throw new Exception("No entities found");
        return entities;
    }
    // Find async
    public async Task<T> AuthenticateFindResponseAsync<T>
        (Func<Task<T?>> findFunctionAsync) where T : IModel
    {
        var entity = await findFunctionAsync();
        return entity ?? throw new Exception("Entity not found");
    }
    // Add async
    public async Task<EntityEntry> AuthenticateAddResponseAsync<T>
        (T model, Action<T> authenticateAction,
        Func<T, Task<EntityEntry>> addFunctionAsync) where T : IModel
    {
        authenticateAction(model);
        var entry = await addFunctionAsync(model);
        return entry;
    }
    // Add range async
    public async Task AuthenticateAddRangeResponseAsync<T>
        (IEnumerable<T> models, Action<IEnumerable<T>> authenticateAction,
        Func<IEnumerable<T>, Task> addRangeActionAsync) where T : IModel
    {
        if (!models.Any()) throw new Exception("The list of models is empty");
        authenticateAction(models);
        await addRangeActionAsync(models);

    }
    // Update async
    public EntityEntry AuthenticateUpdateResponse<T>
        (T model, Func<T, EntityEntry> updateFunction) where T : IModel
    {
        // TODO - Authenticate
        var entry = updateFunction(model);
        return entry;
    }
    // Remove async
    public EntityEntry AuthenticateRemoveResponse<T>
        (T model, Func<T, EntityEntry> removeFunction) where T : IModel
    {
        // TODO - Authenticate
        var entry = removeFunction(model);
        return entry;
    }
}
