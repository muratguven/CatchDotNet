namespace CatchDotNet.TestConsole.events
{
    public interface ILocalEventHandler<T>
    {
        Task HandleEventAsync(T eventData); 

    }
}
