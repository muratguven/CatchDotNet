namespace CatchDotNet.Core.Events.LocalEvents
{

    public delegate Task AppEventHandler<T>(T instance) where T:ILocalEvent; 
    public class LocalEventBus<T> : ILocalEventBus<T> where T : ILocalEvent
    {
        public event AppEventHandler<T> LocalEventHandler;
        

        public Task PublishAsync(T data)
        {
           return OnEvent(data);
        }

        public virtual Task OnEvent(T data) 
        {
            LocalEventHandler?.Invoke(data);
            return Task.CompletedTask;
        }
    }
}
