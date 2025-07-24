using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using vesala2_server;

namespace vesala2_client
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
            new Thread(() =>
            {
                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ip = new IPEndPoint(IPAddress.Loopback, 8000);
                client.Connect(ip);
                Client = client;
            }).Start();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        public static string Request(Request req)
        {
            string reqString = JsonSerializer.Serialize(req);
            Client.Send(Encoding.UTF8.GetBytes(reqString));

            byte[] buffer = new byte[3024];
            int received = Client.Receive(buffer);
            string res = "null";

            if (received != 0)
            {
                res = Encoding.UTF8.GetString(buffer, 0, received);
            }

            return res;
        }
    }
}