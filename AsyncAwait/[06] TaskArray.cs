using System;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class TaskArray
    {
        public static async Task Main() 
        {
            await ProcessTasksAsync();

            Console.ReadKey();
        }

        public static async Task<int> DelayAndReturnAsync(int value)
        {
            await Task.Delay(TimeSpan.FromSeconds(value));
            return value;
        }

        public static async Task ProcessTasksAsync()
        {
            Task<int> taskA = DelayAndReturnAsync(1);
            Task<int> taskB = DelayAndReturnAsync(2);
            Task<int> taskC = DelayAndReturnAsync(5);

            Task<int>[] tasks = new[] { taskA, taskB, taskC };
            Task[] processingTasks = tasks.Select(async task =>
            {
                var result = await task;
                Console.WriteLine(result);
            }).ToArray();

            await Task.WhenAll(processingTasks);
        }
    }
}
