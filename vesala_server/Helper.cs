using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using vesala_server;

namespace vesala_client
{
    public static class Helper
    {
        public static string Request(Request req)
        {
            string reqString = JsonSerializer.Serialize(req);
            string res = "null";

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Loopback, 4300);
            client.Connect(iPEndPoint);

            client.Send(Encoding.UTF8.GetBytes(reqString));

            byte[] buffer = new byte[3024];
            int received = client.Receive(buffer);

            if (received != 0)
                res = Encoding.UTF8.GetString(buffer, 0, received);

            return res;
        }
    }
}
