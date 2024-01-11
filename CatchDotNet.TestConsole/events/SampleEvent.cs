using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CatchDotNet.TestConsole.events
{
    public class SampleEvent
    {
        // iki tür event tanımlama 
        /*
         event keyword delegate ile kullanılır.
        önüne delegate türü alır.

         */
        public delegate void ProcessStartHandler(EventArgs e);
        public event  EventHandler ProcessCompleted;
        public event ProcessStartHandler ProcessStarted;


        public void Process()
        {
            OnProcessStarted(EventArgs.Empty);
            Console.WriteLine("Process working...");

            OnProcessCompleted(EventArgs.Empty);

        }

        public virtual void OnProcessStarted(EventArgs e)
        {
           
            ProcessStarted?.Invoke(e);
        }

        public virtual void OnProcessCompleted(EventArgs e)
        {
          
            ProcessCompleted.Invoke(this, e);
        }
        


    }
}
