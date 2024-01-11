using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchDotNet.TestConsole.events
{
    public class TestEvent:IEvent
    {
        public string MessageTest { get; set; }
    }
}
