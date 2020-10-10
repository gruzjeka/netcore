using System;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class SynchronousTaskWrapper
    {
        public static async Task Main()
        {
            try
            {
                await AsyncWrapper(DoSomething);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public static Task AsyncWrapper(Action action)
        {
            try
            {
                action();
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }
        }

        public static void DoSomething()
        {
            throw new Exception("Error ooopppss...");
        }
    }
}
