using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using vesala_server;

namespace vesala_server
{
    internal static class Program
    {
        public static Form1 FormInstance { get; set; }
        public static event Action<Pokusaj> OnPokusaj;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new Thread(() =>
            {
                StartServer();
            }).Start();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            FormInstance = new Form1();
            Application.Run(FormInstance);
        }

        public static void StartServer()
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Loopback, 4300);
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

                    if (request.MethodName == "Pokusaj")
                    {
                        Pokusaj pokusaj = JsonSerializer.Deserialize<Pokusaj>(request.Data);
                        res = FormInstance.Pokusaj(pokusaj.ZadnjeSlovo, pokusaj.Id);
                    }

                    client.Send(Encoding.UTF8.GetBytes(res));
                }
            }
        }
    }
}