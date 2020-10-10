using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class AsyncEnumerable
    {
        public static async Task Main()
        {
            await ConsumeAsync(ProduceAsync());
            Console.ReadKey();
        }

        public static async Task ConsumeAsync<T>(IAsyncEnumerable<T> asyncEnumerable)
        {
            using var cts = new CancellationTokenSource(0);
            CancellationToken token = cts.Token;

            await foreach (var item in asyncEnumerable.WhereAwait(async (value) =>
            {
                await Task.Delay(10);
                return value != null;
            }).WithCancellation(token).ConfigureAwait(false))
            {
                Console.WriteLine(item);
            }
        }

        public static async IAsyncEnumerable<string> ProduceAsync()
        {
            string result = await new HttpClient().GetStringAsync("https://www.google.com/");
            string[] valuesOnThisPage = result.Split("\n");

            foreach (var value in valuesOnThisPage)
            {
                yield return value;
            }
        }
    }
}
