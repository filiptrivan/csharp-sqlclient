using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27._12._2023_server
{
    public class Request
    {
        public string Data { get; set; }
        public string Method { get; set; }
    }

    public class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int Value { get; set; }
    }
}
