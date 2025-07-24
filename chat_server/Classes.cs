using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace chat_server
{
    public class AdminUser
    {
        public string email { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
    }
    public class User
    {
        public string email { get; set; }
        public string password { get; set; }
        public bool isLoggedIn { get; set; }
    }

    public class Poruka
    {
        public string Za { get; set; }
        public string poruka { get; set; }
    }

    public class Klijent
    {
        public string email{ get; set; }
        public Socket socket { get; set; }
    }

    public class Request
    {
        public string Data { get; set; }
        public string Method { get; set; }
    }
}
