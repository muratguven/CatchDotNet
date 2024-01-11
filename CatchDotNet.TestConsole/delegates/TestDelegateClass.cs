using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CatchDotNet.TestConsole.delegates
{
    public class TestDelegateClass
    {

        public delegate Task<string> TestDelegate(string message);
        public delegate void MyMultiDelegate(string message);
        public delegate void MyDelegate(string message);

        delegate void BasicDelegate();


        public Task<string> GetMessage(string message)
        {
            var result = $"Hello {message} ! I am a delegate method";
            Task.Delay(1000) ;
            return Task.FromResult(result);
        }

        public async Task Execute(string message)
        {
            var testDelegate = new TestDelegate(GetMessage);
            var result =await testDelegate.Invoke(message);
            Console.WriteLine(result);

            // Func kullanımı

            Console.WriteLine(testDelegate.Method);
            Console.WriteLine(testDelegate.Target);

            // My Delegate -- delegate tanımlama şekilleri
            

            var myDelegate = new MyDelegate(Method1);
            myDelegate("Deneme");

            MyDelegate delegate2 = (string msg)=> { Console.WriteLine($"Basic delegate {msg} "); };
            delegate2("Merhaba");

            BasicDelegate basic = delegate { Console.WriteLine("Parametresiz delegate"); };
            basic.Invoke();

            Func<string, string> testFunc = (string msg) => { return $"{msg} func kullanımı"; };
            Console.WriteLine(testFunc("Fuuuuuuuunc"));

            Action<string> testAction = (string msg) => { Console.WriteLine($"{msg} action kullanımı"); };
            testAction("ACTIOOOOON");
        }


        public void ExecuteMultiDelegates()
        {
            MyMultiDelegate multiDelegate = null;

            // Delegate'e birinci metodu ekleyerek atama
            multiDelegate += Method1;

            // Delegate'e ikinci metodu ekleyerek atama
            multiDelegate += Method2;

            // Delegate'e üçüncü metodu ekleyerek atama
            multiDelegate += Method3;

            // Delegate'i kullanarak birden fazla metodu çağırma
            multiDelegate("Hello, Multicast Delegates!");

            // Delegate'ten bir metodu çıkararak
            multiDelegate -= Method2;

            // Güncellenmiş delegate'i kullanarak metotları çağırma
            multiDelegate("Updated Message!");
        }

        public  void Method1(string message)
        {
            Console.WriteLine($"Method 1: {message}");
        }

        // Delegate tarafından temsil edilecek ikinci metot
        public void Method2(string message)
        {
            Console.WriteLine($"Method 2: {message}");
        }

        // Delegate tarafından temsil edilecek üçüncü metot
        public void Method3(string message)
        {
            Console.WriteLine($"Method 3: {message}");
        }

       
    }
}
