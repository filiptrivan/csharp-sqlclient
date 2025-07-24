using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace vesala2_server
{
    public class Request
    {
        public string Data { get; set; }
        public string Method { get; set; }
    }

    public class Pokusaj
    {
        public string Slovo { get; set; }
        public int IndexSlova { get; set; }
    }

    public class Klijent
    {
        public int BrPok { get; set; }
        public Socket Soket { get; set; }
        public List<string> VecPokusanaSlova { get; set; } = new();
    }
}
