using System;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class AsyncDelay
    {
        public static async Task Main()
        {
            await Retry(() => { throw new InvalidOperationException(); }, 3);
            await Retry(() => { Console.WriteLine("Success"); }, 3);

            Console.ReadKey();
        }

        public static async Task Retry(Action action, int count)
        {
            TimeSpan nextDelay = TimeSpan.FromSeconds(1);
            for (int i = 0; i < count; i++)
            {
                try
                {
                    action();
                    return;
                }
                catch (Exception)
                {
                    nextDelay += nextDelay;
                    await Task.Delay(nextDelay);
                }
            }
        }
    }
}
