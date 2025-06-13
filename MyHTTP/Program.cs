using System.Net;

namespace MyHTTP
{
    internal class Program
    {
        static Thread ThreadListener;
        static void Start(object prefix)
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(prefix.ToString());
            listener.Start();
            while (true)
            {
                Console.WriteLine("Слушаем...");
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                var sections = request.RawUrl.Split('/');
                string segment = sections[1];
                Console.WriteLine("Получено " + segment);

                HttpListenerResponse response = context.Response;
                string responseString = $"<html><body>Server received {segment}</body></html>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
            }
            //listener.Stop();
        }
        
        static void Main(string[] args)
        {
            ThreadListener = new Thread(new ParameterizedThreadStart(Start));
            ThreadListener.Start("http://localhost:8080/");            
        }
    }
}
