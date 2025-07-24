
using chat_server;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace chat_client
{
    internal static class Program
    {
        public static Socket Client { get; set; }

        public static Form1 FormInstance { get; set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            StartClient();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            FormInstance = new Form1();
            Application.Run(FormInstance);
        }

        private static void StartClient()
        {
            Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Loopback, 8000);
            Client.Connect(ip);

            Client.Send(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(new Request())));

            new Thread(() =>
            {
                while (true)
                {
                    var buffer = new byte[3024];
                    int received = Client.Receive(buffer);

                    if (received != 0)
                    {
                        string resString = Encoding.UTF8.GetString(buffer, 0, received);
                        
                        Request req = JsonSerializer.Deserialize<Request>(resString);

                        if (req.Method == "Poruka")
                        {
                            if (req.Data != null)
                                MessageBox.Show(req.Data);
                        }
                        if (req.Method == "Login")
                        {
                            MessageBox.Show(req.Data);
                        }
                        if (req.Method == "GetUsers")
                        {
                            if (req.Data != null)
                                FormInstance.SetUsers(JsonSerializer.Deserialize<List<User>>(req.Data));
                        }
                    }
                }
            }).Start();
        }

        public static void Request(Request req)
        {
            Client.Send(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(req)));
        }
    }
}