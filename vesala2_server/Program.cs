using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace vesala2_server
{
    internal static class Program
    {
        public static List<string> Reci = new List<string>
        {
            "petao",
            "macka",
            "pseto",
            "rakun",
            "helio"
        };
        public static List<Klijent> Clients = new List<Klijent>();
        public static Form1 FormInstance;

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
            FormInstance.SetRecZaPogadjanje(Reci[new Random().Next(0, 5)]);
            Application.Run(FormInstance);
        }

        public static void StartServer()
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Loopback, 8000);
            server.Bind(ip);
            server.Listen(2);

            while (true)
            {
                Socket client = server.Accept();
                Klijent klijent = new Klijent
                {
                    Soket = client,
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
                            string res = "null";

                            if (req.Method == "Pogodi")
                            {
                                res = Pogodi(JsonSerializer.Deserialize<Pokusaj>(req.Data), klijent);
                            }

                            client.Send(Encoding.UTF8.GetBytes(res));
                        }
                    }
                }).Start();
            }
        }

        private static string Pogodi(Pokusaj pokusaj, Klijent client)
        {
            string res = "null";

            Klijent guessClient = Clients.FirstOrDefault(x => x == client);
            guessClient.BrPok++;
            if (guessClient == Clients[0])
            {
                FormInstance.prviKorBrPok++;
            }
            else
            {
                FormInstance.drugiKorBrPok++;
            }

            if (
                FormInstance.recZaPogadjanje.Contains(pokusaj.Slovo) && 
                guessClient.VecPokusanaSlova.Any(x => x == pokusaj.Slovo) == false
            )
            {
                if (guessClient == Clients[0])
                {
                    FormInstance.prviKorBrPokUsp++;
                }
                else
                {
                    FormInstance.drugiKorBrPokUsp++;
                }

                pokusaj.IndexSlova = FormInstance.recZaPogadjanje.IndexOf(pokusaj.Slovo);
                res = JsonSerializer.Serialize(pokusaj);
            }

            guessClient.VecPokusanaSlova.Add(pokusaj.Slovo);
            FormInstance.SetPrviKorisnik($"Prvi korisnik: {FormInstance.prviKorBrPok}/{FormInstance.prviKorBrPokUsp}");
            FormInstance.SetDrugiKorisnik($"Drugi korisnik: {FormInstance.drugiKorBrPok}/{FormInstance.drugiKorBrPokUsp}");

            return res;
        }
    }
}