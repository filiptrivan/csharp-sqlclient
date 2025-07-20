using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace vesala_server
{
    internal static class Program
    {
        public static ConcurrentDictionary<string, Socket> Clients { get; set; } = new();
        public static Form1 FormInstance { get; set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            FormInstance = new Form1();

            new Thread(() =>
            {
                StartServer(4300);
            }).Start();

            Application.Run(FormInstance);
        }

        public static void StartServer(int port)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Loopback, port);
            server.Bind(iPEndPoint);
            server.Listen(10);

            while (true)
            {
                Socket client = server.Accept();

                byte[] buffer = new byte[3024];
                int received = client.Receive(buffer);

                if (received != 0)
                {
                    Request request = JsonSerializer.Deserialize<Request>(Encoding.UTF8.GetString(buffer, 0, received));
                    string res = "null";
                    string clientId = null;

                    if (request.MethodName == "Pokusaj")
                    {
                        Pokusaj pokusaj = JsonSerializer.Deserialize<Pokusaj>(request.Data);
                        res = FormInstance.Pokusaj(pokusaj.ZadnjeSlovo, pokusaj.Id);
                        Clients.AddOrUpdate(pokusaj.Id, client, (key, oldClient) => client);
                        clientId = pokusaj.Id;
                    }

                    client.Send(Encoding.UTF8.GetBytes(res));

                    foreach (Socket otherClient in Clients.Values)
                    {
                        if (otherClient == client)
                            continue;

                        otherClient.Send(Encoding.UTF8.GetBytes($"Zahtev salje client: {clientId}"));
                    }
                }
            }
        }
    }
}