using _02_07_2025_server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _02_07_2025_client
{
    public static class Helper
    {
        public static string Request(Request req)
        {
            string reqString = JsonSerializer.Serialize(req);
            string res = "null";

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, 4300);
            client.Connect(endPoint);

            byte[] buffer = new byte[3024];
            client.Send(Encoding.UTF8.GetBytes(reqString));

            int received = client.Receive(buffer);

            if (received != 0)
            {
                res = Encoding.UTF8.GetString(buffer, 0, received);
                return res;
            }

            return res;
        }
    }
}
