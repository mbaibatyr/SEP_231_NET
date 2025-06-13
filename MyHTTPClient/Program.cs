using System.Net;

namespace MyHTTPClient
{
    internal class Program
    {
        static async Task<string> MyHttpClient()
        {
            using (HttpClient client = new HttpClient())
            {
                var result = await client.GetStringAsync("https://www.google.com");
                return result;
            }
        }

        void MyWebClient()
        {
            using (var client = new WebClient())
            {
                var result = client.DownloadData(".pdf");
            }
        }

        static void Main(string[] args)
        {
            var result = MyHttpClient().Result;
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
