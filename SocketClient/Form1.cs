using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        async Task SendToServer()
        {
            await Task.Run(() =>
            {
                byte[] bytes = new byte[1024];
                var ip = Dns.GetHostEntry(tbHost.Text);
                var ad = ip.AddressList[0];
                var ep = new IPEndPoint(ad, int.Parse(tbPort.Text));
                Socket sender = new Socket(ad.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                sender.Connect(ep);
                byte[] msg = Encoding.UTF8.GetBytes(tbMessage.Text);
                int count = sender.Send(msg);
                count = sender.Receive(bytes);
                listBox1.Items.Add("�������� �� ������� " + Encoding.UTF8.GetString(bytes, 0, count));
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendToServer();            
        }
    }
}