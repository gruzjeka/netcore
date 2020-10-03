using System;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class ExceptionHandling
    {
        public static async Task Main(string[] args)
        {
            Task task = DoSomethingAsync();

            try
            {
                await task;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Waiting ...");
            Console.ReadKey();
        }

        public static Task DoSomethingAsync()
        {
            return Task.Run(() => 
            {
                throw new InvalidOperationException("oopss...");
            });
        }
    }
}
