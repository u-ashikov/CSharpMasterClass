using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace StateMachine
{
    public class Program
    {
        public static async Task Main()
        {
            await Greet();
        }

        public static async Task<string> Greet()
        {
            Console.WriteLine("Before First Await");

            var list = new List<int>();

            list.Add(10);

            var httpClient = new HttpClient();

            await httpClient.GetAsync("google.com");

            Console.WriteLine("After First Await");

            Console.WriteLine("Before Second Await");

            await httpClient.GetAsync("google.com");

            Console.WriteLine("After Second Await");

            return "Ended at last!";
        }
    }
}
