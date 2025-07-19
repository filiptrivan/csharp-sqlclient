using System.Net.Sockets;
using System.Net;
using System.Text.Json;
using System.Text;

namespace _02_07_2025_server
{
    internal static class Program
    {
        public static List<User> Users { get; set; } = new List<User>
        {
            new User
            {
                Email = "ft",
                Password = "ft",
                Name = "Filip",
                Surname = "Todorovic",
                Id = "1",
                HasLoggedIn = true
            },
            new User
            {
                Email = "at",
                Password = "at",
                Name = "Aleksa",
                Surname = "Trivan",
                Id = "2",
                HasLoggedIn = false
            }
        };

        public static List<SrpskaRec> SrpskeReci { get; set; } = new List<SrpskaRec>
        {
            new SrpskaRec
            {
                Id = "1",
                Value = "Pas",
            },
            new SrpskaRec
            {
                Id = "2",
                Value = "Macka",
            }
        };

        public static List<EngleskaRec> EngleskeReci { get; set; } = new List<EngleskaRec>
        {
            new EngleskaRec {
                Value = "Dog",
                SrpskaRec = SrpskeReci.FirstOrDefault(x => x.Id == "1")
            },
            new EngleskaRec {
                Value = "Hound",
                SrpskaRec = SrpskeReci.FirstOrDefault(x => x.Id == "1")
            },
            new EngleskaRec {
                Value = "Cat",
                SrpskaRec = SrpskeReci.FirstOrDefault(x => x.Id == "2")
            },
            new EngleskaRec {
                Value = "Kitten",
                SrpskaRec = SrpskeReci.FirstOrDefault(x => x.Id == "2")
            }
        };

        public static Form1 FormInstance { get; set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new Thread(() =>
            {
                InitServer();
            }).Start();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            FormInstance = new Form1();
            Application.Run(FormInstance);
        }

        private static void InitServer()
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, 4300);
            server.Bind(endPoint);
            server.Listen(10);

            while (true)
            {
                Socket client = server.Accept();
                string res = "null";
                byte[] buffer = new byte[3024];
                int received = client.Receive(buffer);

                if (received != 0)
                {
                    Request request = JsonSerializer.Deserialize<Request>(Encoding.UTF8.GetString(buffer, 0, received));

                    if (request.MethodName == "GetSrpskeReci")
                    {
                        res = JsonSerializer.Serialize(GetSrpskeReci());
                    }
                    if (request.MethodName == "Login")
                    {
                        res = Login(request.Data);
                    }
                    if (request.MethodName == "GetEngleskeReci")
                    {
                        res = JsonSerializer.Serialize(GetEngleskeReci(request.Data));
                    }

                    client.Send(Encoding.UTF8.GetBytes(res));
                }
            }
        }

        public static List<SrpskaRec> GetSrpskeReci()
        {
            List<SrpskaRec> srpskeReci = SrpskeReci
                .Select(s => new SrpskaRec
                {
                    Id = s.Id,
                    Value = s.Value,
                    EngleskeReci = EngleskeReci.Where(en => en.SrpskaRec.Id == s.Id).ToList()
                })
                .ToList();

            return srpskeReci;
        }

        public static List<EngleskaRec> GetEngleskeReci(string query)
        {
            return SrpskeReci
                .Where(x => x.Value == query)
                .SelectMany(s => s.EngleskeReci)
                .ToList();
        }

        public static string Login(string loginString)
        {
            User login = JsonSerializer.Deserialize<User>(loginString);

            User user = Users.FirstOrDefault(x => x.Email == login.Email && x.Password == login.Password);

            if (user == null)
            {
                return "false";
            }

            user.HasLoggedIn = true;
            FormInstance.LoadUserTable();
            return "true";
        }

        public static List<User> GetUsers()
        {
            return Users;
        }
    }
}