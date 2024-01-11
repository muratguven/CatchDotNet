namespace CatchDotNet.TestConsole.events
{
    public class TestLocalEventHandler : ILocalEventHandler<TestEvent>
    {
        public Task HandleEventAsync(TestEvent eventData)
        {
            Console.WriteLine($"Message: {eventData.MessageTest}");
            
            return Task.CompletedTask;
        }

    
    }
}
