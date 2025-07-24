
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace chat_server
{
    internal static class Program
    {
        public static Socket Server { get; set; }
        public static List<Klijent> Clients { get; set; } = new List<Klijent>();
        public static List<User> Users { get; set; } = new List<User>();


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        internal static void StartServer()
        {
            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Loopback, 8000);
            Server.Bind(ip);
            Server.Listen(10);

            while (true)
            {
                Socket client = Server.Accept();
                IPEndPoint remoteEndPoint = (IPEndPoint)client.RemoteEndPoint;
                Klijent klijent = new Klijent
                {
                    socket = client,
                };
                Clients.Add(klijent);

                new Thread(() =>
                {
                    while (true)
                    {
                        byte[] buffer = new byte[3024];
                        int received = client.Receive(buffer);

                        if (received != 0)
                        {
                            string reqString = Encoding.UTF8.GetString(buffer, 0, received);
                            Request req = JsonSerializer.Deserialize<Request>(reqString);
                            var res = new Request { Method = req.Method };

                            if (req.Method == "Login")
                            {
                                res.Data = Login(JsonSerializer.Deserialize<User>(req.Data), klijent);
                                client.Send(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(res)));
                            }
                            if (req.Method == "Poruka")
                            {
                                Poruka(JsonSerializer.Deserialize<Poruka>(req.Data), klijent);
                            }
                            if (req.Method == "GetUsers")
                            {
                                GetUsers();
                            }
                        }
                    }
                }).Start();
            }
        }

        internal static void CloseServer()
        {
            foreach (var client in Clients)
            {
                client.socket.Close();
            }

            Server.Close();
        }

        public static string Login(User login, Klijent klijent)
        {
            User user = Users.FirstOrDefault(x => x.email == login.email && x.password == login.password);
            if (user != null)
            {
                user.isLoggedIn = true;
                klijent.email = login.email;
                return "Uspesna prijava";
            }
            return "greska";
        }

        public static string Poruka(Poruka poruka, Klijent trenutniKlijent)
        {
            if (poruka.Za == null)
            {
                foreach (var client in Clients)
                {
                    if (trenutniKlijent == client)
                        continue;

                    User user = Users.FirstOrDefault(x => x.email == client.email);

                    if (user == null)
                        continue;

                    if (user.isLoggedIn)
                    {
                        client.socket.Send(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(new Request
                        {
                            Data = poruka.poruka,
                            Method = "Poruka",
                        })));
                    }
                }
            }
            else
            {
                Klijent klijent = Clients.FirstOrDefault(x => x.email == poruka.Za);
                User user = Users.FirstOrDefault(x => x.email == klijent.email);

                if (user.isLoggedIn)
                {
                    klijent.socket.Send(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(new Request
                    {
                        Data = poruka.poruka,
                        Method = "Poruka",
                    })));
                }
            }

            return "null";
        }

        public static void GetUsers()
        {
            foreach (var client in Clients)
            {
                client.socket.Send(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(new Request
                {
                    Data = JsonSerializer.Serialize(Users.ToList()),
                    Method = "GetUsers",
                })));
            }
        }
    }
}