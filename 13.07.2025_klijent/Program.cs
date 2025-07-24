using _13._07._2025_server;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace _13._07._2025_klijent
{
    internal static class Program
    {
        public static Form1 FormInstance { get; set; }
        public static Nastavnik currentUser { get; set; }
        public static Socket Client { get; set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Loopback, 8000);
            Client.Connect(ip);

            new Thread(() =>
            {
                while (true)
                {
                    var b = new byte[3024];
                    int received = Client.Receive(b);

                    if (received != 0)
                    {
                        string result = Encoding.UTF8.GetString(b, 0, received);
                        Request req = JsonSerializer.Deserialize<Request>(result);

                        if (req.Method == "Login")
                        {
                            if (req.Data == "Uspesna prijava")
                            {
                                MessageBox.Show("uspesna prijava");
                                FormInstance.SetLoginInvisible();

                                currentUser = FormInstance.lastTry;
                                
                                Request(new Request
                                {
                                    Data = FormInstance.lastTry.Name,
                                    Method = "GetPredmetsForNastavnik",
                                });
                            }
                            else
                            {
                                MessageBox.Show("neuspesna prijava");
                            }
                        }

                        if (req.Method == "GetPredmetsForNastavnik")
                        {
                            FormInstance.SetPredmetsTable(JsonSerializer.Deserialize<List<Predmet>>(req.Data));
                        }
                        if (req.Method == "GetNastavniksForPredmet")
                        {
                            FormInstance.SetNastavniksTable(JsonSerializer.Deserialize<List<Nastavnik>>(req.Data));
                        }
                        
                    }
                }
            })
            { IsBackground = true }.Start();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            FormInstance = new Form1();
            Application.Run(FormInstance);
        }

        public static void Request(Request req)
        {
            Client.Send(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(req)));
        }
    }
}