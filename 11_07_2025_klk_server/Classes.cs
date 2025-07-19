using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_07_2025_klk_server
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Predmet> Predmeti { get; set; }

        public override string ToString()
        {
            return Username;
        }
    }

    public class NastavnikPredmet
    {
        public User Nastavnik { get; set; }
        public Predmet Predmet { get; set; }
        public Angazovanje TipAngazovanja { get; set; }
    }

    public class Predmet
    {
        public string Id { get; set; }
        public string Naziv { get; set; }
        public List<User> Nastavnici { get; set; }

        public override string ToString()
        {
            return Naziv;
        }
    }

    public class Angazovanje
    {
        public string Id { get; set; }
        public string Naziv { get; set; }

        public override string ToString()
        {
            return Naziv;
        }
    }

    public class Request
    {
        public string Data { get; set; }
        public string Method { get; set; }
    }
}
