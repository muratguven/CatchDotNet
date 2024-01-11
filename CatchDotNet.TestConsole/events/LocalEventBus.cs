namespace CatchDotNet.TestConsole.events
{

    public delegate Task AppEventHandler<T>(T instance) where T:IEvent; 
    public class LocalEventBus<T> : ILocalEventBus<T> where T : IEvent
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
