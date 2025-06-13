using System.Net.Mail;

namespace MySMTP
{
    internal class Program
    {

        static void Send()
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("murat_b@mail.ru");
            mail.To.Add("ernar30@gmail.com");
            mail.Subject = "Test Email";
            mail.Body = "This is a test email sent from MySMTP application.";
            Attachment attachment = new Attachment(@"D:\Projects\SEP_231_NET\MyFTPClient\bin\Debug\net7.0\123.txt");
            mail.Attachments.Add(attachment);
            using (SmtpClient client = new SmtpClient("smtp.mail.ru", 587))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("murat_b@mail.ru", "");
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                Console.WriteLine("sent");
            }
        }
        static void Main(string[] args)
        {
            Send();
        }
    }
}
