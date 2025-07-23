using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using static _27._12._2023_server.BrokerBazePodataka;

namespace _27._12._2023_server
{
    internal static class Program
    {
        public static List<User> LogedInUsers = new List<User>();

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

        public static void StartServer(int numberOfClients)
        {
            int currentNumberOfClients = 0;
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Loopback, 8000);
            server.Bind(ip);
            server.Listen(numberOfClients);

            while (true)
            {
                Socket client = server.Accept();
                currentNumberOfClients++;

                if (currentNumberOfClients > numberOfClients)
                {
                    byte[] maxClients = UnicodeEncoding.UTF8.GetBytes("There is maximum number of clients connected.");
                    client.Send(maxClients);
                }

                new Thread(() =>
                {
                    while (true)
                    {
                        byte[] buffer = new byte[3024];
                        int received = client.Receive(buffer);

                        if (received != 0)
                        {
                            string reqString = UnicodeEncoding.UTF8.GetString(buffer, 0, received);
                            Request req = JsonSerializer.Deserialize<Request>(reqString);

                            if (req.Method == "Login")
                            {
                                client.Send(UnicodeEncoding.UTF8.GetBytes(Login(JsonSerializer.Deserialize<User>(req.Data))));
                            }
                            if (req.Method == "Odjava")
                            {
                                client.Send(UnicodeEncoding.UTF8.GetBytes(Login(JsonSerializer.Deserialize<User>(req.Data))));
                            }
                        }
                    }
                }).Start();
            }
        }

        public static string Login(User login)
        {
            User user = new BrokerBazePodataka().Login(login);
            if (user != null)
            {
                if (LogedInUsers.Any(x => x.username == user.username))
                    return "Vec si se ulogovao sa drugog klijenta.";
                LogedInUsers.Add(user);
            }
            else
            {
                return "null";
            }

            return JsonSerializer.Serialize(user);
        }

        public static string Odjava(User odjava)
        {
            LogedInUsers.RemoveAll(x => x.username == odjava.username);
            return "Uspesno odjavljen.";
        }
    }
}