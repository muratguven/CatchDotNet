using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchDotNet.TestConsole.events
{
    public class LocalEvents
    {
        public event EventHandler<EventPayload> CreatedHandler;

        public void Publish(EventPayload data)
        {
            OnCreated(data);
        }
        public virtual void OnCreated(EventPayload data)
        {
            CreatedHandler?.Invoke(this, data);
        } 

    }

    public class EventPayload : EventArgs
    {
        public Guid Id { get; set; }
        
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
