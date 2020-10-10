using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class WhenAll
    {
        public static async Task Main()
        {
            string result = await DownloadAllAsync(new HttpClient(), new [] { "https://httpstatuses.com/", "https://www.google.com/", "https://www.facebook.com/" });
            Console.WriteLine(result);

            Console.ReadKey();
        }

        public static async Task<string> DownloadAllAsync(HttpClient httpClient, IEnumerable<string> urls)
        {
            var downloadTasks = urls.Select(url => httpClient.GetStringAsync(url));

            string[] htmlPages = await Task.WhenAll(downloadTasks);

            return string.Concat(htmlPages);
        }
    }
}
