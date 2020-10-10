using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class WhenAny
    {
        public static async Task Main()
        {
            var result = await FirstRespondingUrlAsync(new HttpClient(), "https://www.netflix.com/", "https://www.google.com/");
            
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static async Task<int> FirstRespondingUrlAsync(HttpClient httpClient, string urlA, string urlB)
        {
            Task<byte[]> downloadTaskA = httpClient.GetByteArrayAsync(urlA);
            Task<byte[]> downloadTaskB = httpClient.GetByteArrayAsync(urlB);

            Task<byte[]> completedTask = await Task.WhenAny(downloadTaskA, downloadTaskB);

            byte[] data = await completedTask;
            return data.Length;
        }
    }
}
