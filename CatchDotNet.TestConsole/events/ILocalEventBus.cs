namespace CatchDotNet.TestConsole.events
{
    public interface ILocalEventBus<T>
        where T : IEvent
    {
        event AppEventHandler<T> LocalEventHandler;
        Task PublishAsync(T data);
    }
}
