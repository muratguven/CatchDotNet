using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchDotNet.TestConsole.events
{
    public class TestSecondEventHandler : ILocalEventHandler<TestSecondEvent>
    {
        public Task HandleEventAsync(TestSecondEvent eventData)
        {
           Console.WriteLine($"Test Second: {eventData.Message}");
           return Task.CompletedTask;
        }
    }
}
