using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace _11_07_2025_klk_client
{
    public static class Helper
    {
        public static string Request(string body)
        {
            string data = null;
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var serverAddress = new IPEndPoint(IPAddress.Loopback, 4300);
            socket.Connect(serverAddress);

            while (true)
            {
                socket.Send(Encoding.UTF8.GetBytes(body));
                byte[] byteData = new byte[2048];
                int received = socket.Receive(byteData);

                if (received != 0)
                {
                    data = Encoding.UTF8.GetString(byteData, 0, received);
                    break;
                }
            }

            return data;
        }

    }
}
