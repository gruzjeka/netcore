using System;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class WhenAllExpcetions
    {
        public static async Task Main()
        {
            var task1 = ThrowInvalidOperationException();
            var task2 = ThrowNotSupportedException();

            var allTasks = Task.WhenAll(task1, task2);

            try
            {
                await allTasks;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                foreach (var innerException in allTasks.Exception.InnerExceptions)
                {
                    Console.WriteLine(innerException.Message);
                }
            }

            Console.ReadKey();
        }

        public static Task ThrowInvalidOperationException()
        {
            return Task.FromException(new InvalidOperationException("InvalidOperationException"));
        }

        public static Task ThrowNotSupportedException()
        {
            return Task.FromException(new NotSupportedException("NotSupportedException"));
        }
    }
}
