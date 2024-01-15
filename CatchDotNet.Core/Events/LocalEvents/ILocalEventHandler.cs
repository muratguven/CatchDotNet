namespace CatchDotNet.Core.Events.LocalEvents
{
    public interface ILocalEventHandler<T>
    {
        Task HandleEventAsync(T eventData); 

    }
}
