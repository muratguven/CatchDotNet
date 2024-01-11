using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CatchDotNet.TestConsole.delegates
{
    public static class SampleFilter
    {
        public static void Execute() 
        {
            var filterNumbers = new[] { 1, 2, 3, 4, 5, 6, 7 }.MyFilter(f => f % 2==0);
            var filterCharacters = new[] { "ali", "murat", "ahmet" }.MyFilter(f => f.StartsWith("a"));

            foreach (var item in filterNumbers)
            {
                Console.WriteLine(item);
            }
        }

        public static IEnumerable<T> MyFilter<T>(this IEnumerable<T> items, Func<T,bool> predicate)
        {
            foreach (var item in items)
            {
                if(predicate(item))
                    yield return item;
            }
        }
        
    }
}
