using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Zadak_1_Teams_Server_06_03_2025
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SocketHandling();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        public static void SocketHandling()
        {
            new Thread(() =>
            {
                IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Loopback, 1000);
                using Socket server = new Socket(
                    iPEndPoint.AddressFamily,
                    SocketType.Stream,
                    ProtocolType.Tcp
                );

                server.Bind(iPEndPoint);
                server.Listen(100);

                try
                {
                    while (true)
                    {
                        Console.WriteLine("Waiting for a connection...");
                        using Socket client = server.Accept();
                        Console.WriteLine("Connected.");

                        while (true)
                        {
                            byte[] buffer = new byte[2024];
                            int request = client.Receive(buffer, SocketFlags.None);

                            if (request == 0)
                            {
                                Console.WriteLine("Client disconnected.");
                                break;
                            }

                            string json = Encoding.UTF8.GetString(buffer, 0, request);
                            Console.WriteLine(json);

                            byte[] echoBytes = Encoding.UTF8.GetBytes("Tacno");
                            client.Send(echoBytes, SocketFlags.None);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }).Start();

            Console.WriteLine("");
        }

    }
}