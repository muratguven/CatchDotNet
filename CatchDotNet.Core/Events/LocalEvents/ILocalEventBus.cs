namespace CatchDotNet.Core.Events.LocalEvents
{
    public interface ILocalEventBus<T>
        where T : ILocalEvent
    {
        event AppEventHandler<T> LocalEventHandler;
        Task PublishAsync(T data);
    }
}
