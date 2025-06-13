using FluentFTP;

namespace MyFTPClient
{
    internal class Program
    {
        static string url = "ftp://ftp.dlptest.com/";
        static string user = "dlpuser";
        static string password = "rNrKYTX9g7z3RgJRmxWuGHbeu";
        static void FtpTest()
        {
            FtpClient client = new FtpClient();
            client.Host = url;
            client.Credentials = new System.Net.NetworkCredential(user, password);
            client.Connect();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
