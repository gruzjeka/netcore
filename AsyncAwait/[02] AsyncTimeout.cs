using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public static class AsyncTimeout
    {
        public static async Task Main()
        {
            await TimeoutAsync(DoSomething, TimeSpan.FromSeconds(1));

            Console.WriteLine("Finished or Timeout is expired.");
            Console.ReadKey();
        }

        public static async Task TimeoutAsync(Action action, TimeSpan timeout)
        {
            using (var cts = new CancellationTokenSource(timeout))
            {
                Task task = Task.Run(() => action());
                Task timeoutTask = Task.Delay(Timeout.InfiniteTimeSpan, cts.Token);

                await Task.WhenAny(task, timeoutTask);
            }
        }

        public static void DoSomething()
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
