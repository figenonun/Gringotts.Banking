namespace Gringotts.Banking.Shared;

public abstract class AsyncEventContainer<T> where T : class
{
    public T Data { get; }

    public AsyncEventContainer(T data)
    {
        Data = data;
    }
}
