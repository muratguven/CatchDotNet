// See https://aka.ms/new-console-template for more information

using CatchDotNet.TestConsole.delegates;
using CatchDotNet.TestConsole.events;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;


class Program
{
    public static async Task Main(string[] args)
    {

        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);


        // Dependency injection

        builder.Services.AddTransient(typeof(ILocalEventBus<>), typeof(LocalEventBus<>));
        builder.Services.AddTransient(typeof(ILocalEventHandler<TestEvent>), typeof(TestLocalEventHandler));
        builder.Services.AddTransient<ILocalEventHandler<TestSecondEvent>, TestSecondEventHandler>();


        using IHost host = builder.Build();

        //var services = CreateServices();

        using (IServiceScope scope = host.Services.CreateScope())
        {
            IServiceProvider services = scope.ServiceProvider;
            try
            {

                var localEventBus = services.GetRequiredService<ILocalEventBus<TestEvent>>();
                var secondEventBus = services.GetRequiredService<ILocalEventBus<TestSecondEvent>>();
                
                //Reflection for registering the events
                var assembly = Assembly.GetExecutingAssembly();
                var types = assembly.GetTypes();


                //Get Services
                var handler = services.GetRequiredService<ILocalEventHandler<TestEvent>>();
                var handlerSecond = services.GetRequiredService<ILocalEventHandler<TestSecondEvent>>();
                
                //Register handler
                localEventBus.LocalEventHandler += handler.HandleEventAsync;
                secondEventBus.LocalEventHandler += handlerSecond.HandleEventAsync;

                //Publisher
                await localEventBus.PublishAsync(new TestEvent { MessageTest="Test Event" });
                await secondEventBus.PublishAsync(new TestSecondEvent { Message = "Test Second Event" });
                await secondEventBus.PublishAsync(new TestSecondEvent { Message = "Test Second Event - 2" });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        
        await host.RunAsync();
        


        





        #region Old
        //var testDelegate = new TestDelegateClass();

        //await testDelegate.Execute("Murat");

        ////testDelegate.ExecuteMultiDelegates();

        //var exceptionTest = new SampleException();
        //exceptionTest.Execute();

        //SampleFilter.Execute();

        /// Events
        /// 
        //var events = new SampleEvent();
        //events.ProcessStarted += EventStart;
        //events.ProcessCompleted += EventStop;
        //events.Process();



        //// Local eventbus starter.... :)

        //var localEvent = new LocalEvents();
        ////localEvent.CreatedHandler += CreatedEvent;

        //localEvent.Publish(new EventPayload { Id=Guid.NewGuid(), CreatedDate=DateTime.Now, IsDeleted=false });

        //await host.RunAsync();
        #endregion


    }

 
    

    public static void CreatedEvent(object sender,EventPayload payload)
    {
        Console.WriteLine($"ID:{ payload.Id }, {payload.CreatedDate}");
    }

    public static void EventStart(EventArgs e)
    {
        Console.WriteLine("Process started....");
    }

    public static void EventStop(object sender,EventArgs e) 
    { 
        Console.WriteLine("Process completed!"); 
    }

    //public static ServiceProvider CreateServices()
    //{
    //    var services = new ServiceCollection();
    //    // Add DI
    

    //    return services.BuildServiceProvider();

    //}
}
