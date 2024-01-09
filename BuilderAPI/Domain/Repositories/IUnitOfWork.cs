namespace BuilderAPI;

public interface IUnitOfWork
{
    Task CompleteAsync();
}
