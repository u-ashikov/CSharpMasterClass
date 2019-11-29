using System;
using System.Threading.Tasks;

namespace TasksExceptions
{
    public class Program
    {
        public static async Task Main()
        {
            try
            {
                await Task.Run(GreetTask);

                //await Task.Run(GreetVoid);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType().Name} => {ex.Message}");
            }
        }

        public static async Task GreetTask()
        {
            throw new ArgumentException();
        }

        // No exception will be thrown here, because there is no Task
        public static async void GreetVoid()
        {
            throw new ArgumentException();
        }
    }
}
