using System.Net.Sockets;
using System.Net;
using System.Text.Json;
using System.Text;

namespace _13._07._2025_server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Loopback, 8000);
            server.Bind(ip);
            server.Listen(10);

            new Thread(() =>
            {
                while (true)
                {
                    Socket client = server.Accept();

                    new Thread(() =>
                    {
                        while (true)
                        {
                            var b = new byte[3024];
                            int received = client.Receive(b);

                            if (received != 0)
                            {
                                string result = Encoding.UTF8.GetString(b, 0, received);
                                Request req = JsonSerializer.Deserialize<Request>(result);

                                if (req.Method == "Login")
                                {
                                    Request loginres = new Request
                                    {
                                        Data = Login(JsonSerializer.Deserialize<Nastavnik>(req.Data)),
                                        Method = req.Method,
                                    };
                                    client.Send(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(loginres)));
                                }
                                if (req.Method == "GetPredmetsForNastavnik")
                                {
                                    Request loginres = new Request
                                    {
                                        Data = JsonSerializer.Serialize(GetPredmetsForNastavnik(req.Data)),
                                        Method = req.Method,
                                    };
                                    client.Send(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(loginres)));
                                }
                                if (req.Method == "GetNastavniksForPredmet")
                                {
                                    Request loginres = new Request
                                    {
                                        Data = JsonSerializer.Serialize(GetNastavniksForPredmet(long.Parse(req.Data))),
                                        Method = req.Method,
                                    };
                                    client.Send(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(loginres)));
                                }
                                if (req.Method == "IzmeniAngazovanje")
                                {
                                    Request loginres = new Request
                                    {
                                        Data = IzmeniAngazovanje(JsonSerializer.Deserialize<NastavnikPredmet>(req.Data)),
                                        Method = req.Method,
                                    };
                                    client.Send(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(loginres)));
                                }
                            }
                        }
                    }).Start();
                }
            }).Start();
        }

        private static List<Predmet> GetPredmetsForNastavnik(string nastavnikName)
        {
            BrokerBazePodataka b = new BrokerBazePodataka();

            Nastavnik nastavnik = b.GetNastavniks().Where(x => x.Name == nastavnikName).FirstOrDefault();

            List<NastavnikPredmet> nastavnikPredmets = b.GetNastavnikPredmets()
                .Where(x => x.NastavnikId == nastavnik.Id)
                .ToList();

            List<Predmet> predmets = new();

            foreach (var item in nastavnikPredmets)
            {
                predmets.Add(new Predmet
                {
                    Id = item.NastavnikId,
                    Name = b.GetPredmets().Where(x => x.Id == item.PredmetId).Select(x => x.Name).FirstOrDefault(),
                });
            }

            return predmets;
        }

        private static List<Nastavnik> GetNastavniksForPredmet(long predmetId)
        {
            BrokerBazePodataka b = new BrokerBazePodataka();

            Predmet predmet = b.GetPredmets().Where(x => x.Id == predmetId).FirstOrDefault();

            List<NastavnikPredmet> nastavnikPredmets = b.GetNastavnikPredmets()
                .Where(x => x.PredmetId == predmet.Id)
                .ToList();

            List<Nastavnik> predmets = new();

            foreach (var item in nastavnikPredmets)
            {
                predmets.Add(new Nastavnik
                {
                    Id = item.PredmetId,
                    Name = b.GetNastavniks().Where(x => x.Id == item.NastavnikId).Select(x => x.Name).FirstOrDefault(),
                    TipAngazovanja = b.GetTipAngazovanjas().Where(x => x.Id == item.TipAngazovanjaId).Select(x => x.Name).FirstOrDefault(),
                });
            }

            return predmets;
        }

        public static string Login(Nastavnik login)
        {
            Nastavnik n = new BrokerBazePodataka().GetNastavniks()
                .FirstOrDefault(x => x.Name == login.Name && x.Password == login.Password);

            if (n == null)
            {
                return "Pogresni kredencijali";
            }
            else
            {
                return "Uspesna prijava";
            }
        }

        public static string IzmeniAngazovanje(NastavnikPredmet nastavnikPredmet)
        {
            var b = new BrokerBazePodataka();
            return b.UpdateAngazovanja(nastavnikPredmet);
        }
    }
}
