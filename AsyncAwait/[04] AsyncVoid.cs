using System;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class AsyncVoid
    {
        public static void Main()
        {
            try
            {
                DoSomethingAsync();
            }
            catch (Exception ex) // doesn't work for async void
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public static async void DoSomethingAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            throw new InvalidProgramException("ooppss....");
        }
    }
}
