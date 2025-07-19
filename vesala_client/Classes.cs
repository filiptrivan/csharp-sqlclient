using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vesala_server
{
    public class Request
    {
        public string Data { get; set; }
        public string MethodName { get; set; }
    }

    public class Pokusaj
    {
        public string Id { get; set; }
        public int BrojPokusaja { get; set; }
        public int BrojPogodjenih { get; set; }
        public string ZadnjeSlovo { get; set; }
    }
}
