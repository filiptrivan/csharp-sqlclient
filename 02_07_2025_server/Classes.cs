using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_07_2025_server
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool HasLoggedIn { get; set; }
    }

    public class SrpskaRec
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public List<EngleskaRec> EngleskeReci { get; set; } = new();
        public string EngleskiReciCommaSeparated { 
            get 
            { 
                return string.Join(";", EngleskeReci.Select(x => x.Value));
            }
        }

    }

    public class EngleskaRec
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public SrpskaRec SrpskaRec { get; set; }
    }

    public class Request
    {
        public string MethodName { get; set; }
        public string Data { get; set; }    

    }
}
