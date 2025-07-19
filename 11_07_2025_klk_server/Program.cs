using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace _11_07_2025_klk_server
{
    internal class Program
    {
        public static List<User> Nastavnici = new List<User>
        {
            new User
            {
                Id = "1",
                Username = "admin",
                Password = "admin",
            },
            new User
            {
                Id = "2",
                Username = "user1",
                Password = "password1",
            }
        };

        public static List<Predmet> Predmeti = new List<Predmet>
        {
            new Predmet { Id = "1", Naziv = "Matematika" },
            new Predmet { Id = "2", Naziv = "Fizika" },
            new Predmet { Id = "3", Naziv = "Hemija" },
            new Predmet { Id = "4", Naziv = "Biologija" }
        };

        public static List<Angazovanje> Angazovanja = new List<Angazovanje>
        {
            new Angazovanje { Id = "1", Naziv = "Predavac" },
            new Angazovanje { Id = "2", Naziv = "Vezbe" },
            new Angazovanje { Id = "3", Naziv = "Lab vezbe" }
        };

        public static List<NastavnikPredmet> NastavniciPredmeti = new List<NastavnikPredmet>
        {
            new NastavnikPredmet 
            {
                Nastavnik = Nastavnici.Where(x => x.Id == "1").FirstOrDefault(),
                Predmet = Predmeti.Where(x => x.Id == "1").FirstOrDefault(),
                TipAngazovanja = Angazovanja.Where(x => x.Id == "1").FirstOrDefault()
            },
            new NastavnikPredmet 
            { 
                Nastavnik = Nastavnici.Where(x => x.Id == "1").FirstOrDefault(), 
                Predmet = Predmeti.Where(x => x.Id == "2").FirstOrDefault(), 
                TipAngazovanja = Angazovanja.Where(x => x.Id == "2").FirstOrDefault()
            },
            new NastavnikPredmet 
            { 
                Nastavnik = Nastavnici.Where(x => x.Id == "1").FirstOrDefault(), 
                Predmet = Predmeti.Where(x => x.Id == "3").FirstOrDefault(), 
                TipAngazovanja = Angazovanja.Where(x => x.Id == "2").FirstOrDefault()
            },
            new NastavnikPredmet 
            { 
                Nastavnik = Nastavnici.Where(x => x.Id == "2").FirstOrDefault(), 
                Predmet = Predmeti.Where(x => x.Id == "2").FirstOrDefault(), 
                TipAngazovanja = Angazovanja.Where(x => x.Id == "1").FirstOrDefault() 
            },
            new NastavnikPredmet 
            { 
                Nastavnik = Nastavnici.Where(x => x.Id == "2").FirstOrDefault(), 
                Predmet = Predmeti.Where(x => x.Id == "3").FirstOrDefault(), 
                TipAngazovanja = Angazovanja.Where(x => x.Id == "1").FirstOrDefault() 
            },
            new NastavnikPredmet 
            { 
                Nastavnik = Nastavnici.Where(x => x.Id == "2").FirstOrDefault(), 
                Predmet = Predmeti.Where(x => x.Id == "4").FirstOrDefault(), 
                TipAngazovanja = Angazovanja.Where(x => x.Id == "3").FirstOrDefault()
            }
        };

        static void Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(new IPEndPoint(IPAddress.Loopback, 4300));
            server.Listen(0);

            while (true)
            {
                while (true)
                {
                    Socket client = server.Accept();
                    byte[] bytes = new byte[2048];
                    int received = client.Receive(bytes);

                    if (received != 0)
                    {
                        string requestString = Encoding.UTF8.GetString(bytes, 0, received);
                        Request request = JsonSerializer.Deserialize<Request>(requestString);
                        string requestData = request.Data;
                        string requestMethod = request.Method;

                        string result = "null";

                        if (requestMethod == "Login")
                        {
                            result = Login(requestData).ToString();
                        }
                        if (requestMethod == "GetPredmetiZaNastavnika")
                        {
                            result = GetPredmetiZaNastavnika(requestData);
                        }
                        if (requestMethod == "GetNastavniciZaPredmet")
                        {
                            result = GetNastavniciZaPredmet(requestData);
                        }
                        if (requestMethod == "GetNastavnici")
                        {
                            result = GetNastavnici();
                        }
                        if (requestMethod == "GetPredmeti")
                        {
                            result = GetPredmeti();
                        }
                        if (requestMethod == "GetAngazovanja")
                        {
                            result = GetAngazovanja();
                        }
                        if (requestMethod == "SaveNastavnikPredmet")
                        {
                            SaveNastavnikPredmet(requestData);
                        }
                        
                        client.Send(Encoding.UTF8.GetBytes(result));
                        break;
                    }
                }
            }
        }

        public static string Login(string data)
        {
            User user = JsonSerializer.Deserialize<User>(data);

            if (Nastavnici.Where(x => x.Username == user.Username && x.Password == user.Password).Any())
            {
                return "True";
            }

            return "False";
        }

        public static string GetPredmetiZaNastavnika(string data)
        {
            string userEmail = data;
            User user = Nastavnici.Where(x => x.Username == userEmail).FirstOrDefault();

            return JsonSerializer.Serialize(NastavniciPredmeti.Where(x => x.Nastavnik.Id == user.Id).ToList());
        }

        public static string GetNastavniciZaPredmet(string data)
        {
            string predmetId = data;

            return JsonSerializer.Serialize(NastavniciPredmeti.Where(x => x.Predmet.Id == predmetId).Select(x => x.Nastavnik).ToList());
        }

        public static string GetNastavnici()
        {
            return JsonSerializer.Serialize(Nastavnici.ToList());
        }

        public static string GetPredmeti()
        {
            return JsonSerializer.Serialize(Predmeti.ToList());
        }

        public static string GetAngazovanja()
        {
            return JsonSerializer.Serialize(Angazovanja.ToList());
        }

        public static void SaveNastavnikPredmet(string data)
        {
            NastavnikPredmet nastavnikPredmet = JsonSerializer.Deserialize<NastavnikPredmet>(data);

            NastavniciPredmeti.Add(nastavnikPredmet);
        }
    }
}
