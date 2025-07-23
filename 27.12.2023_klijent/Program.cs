using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _27._12._2023_klijent
{
    internal static class Program
    {
        public static Socket Client { get; set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            StartClient();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        public static void StartClient()
        {
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Loopback, 8000);
            client.Connect(ip);
            Client = client;
        }

        public static string Request(string data)
        {
            Client.Send(Encoding.UTF8.GetBytes(data));

            byte[] buffer = new byte[3024];
            int received = Client.Receive(buffer);

            if (received != 0)
            {
                string serverResponse = Encoding.UTF8.GetString(buffer, 0, received);
                return serverResponse;
            }

            return null;
        }
    }
}