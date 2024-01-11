namespace CatchDotNet.TestConsole.delegates
{
    public class SampleException
    {

        public void Execute()
        {
            HandleException(MethodThrowException, 3, ex =>
            {
                Console.WriteLine($"Error: {ex.Message} ");
                Thread.Sleep( 1000 );
            });
        }

        public void MethodThrowException()
        {
            throw new Exception("Couldn't connect to web service...... :)");
        }
        public void HandleException(Action action, int tryCount=3, Action<Exception>? onException=null)
        {
            while (tryCount > 0)
            {
                try
                {
                    Console.WriteLine("Working.....");
                    action();

                }
                catch (Exception ex)
                {
                    tryCount--;
                    onException?.Invoke(ex);

                }
            }
    
        }


    }
}
