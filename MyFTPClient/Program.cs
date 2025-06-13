using FluentFTP;
using Renci.SshNet;

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
            //client.UploadFile("123.txt", "")
            var result = client.DownloadFile("123.jpg", "/10.101.1.2_20250613-12024731_IVA.jpg");
            //foreach (var item in client.GetListing("/"))
            //{
            //    Console.WriteLine(item.FullName);
            //}
        }


        static void SFtpTest()
        {
            string host = "test.rebex.net";
            int port = 22;
            string user = "demo";
            string password = "password";
            using (var client = new SftpClient(host, port, user, password))
            {
                client.Connect();
                var files = client.ListDirectory("/");
                //foreach (var item in files)
                //{
                //    Console.WriteLine(item.FullName);
                //}                
                client.Disconnect();
            }

        }
        static void Main(string[] args)
        {
            SFtpTest();
        }
    }
}
