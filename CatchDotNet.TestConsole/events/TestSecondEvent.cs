using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchDotNet.TestConsole.events
{
    public class TestSecondEvent : IEvent
    {
        public string Message {  get; set; }
    }
}
