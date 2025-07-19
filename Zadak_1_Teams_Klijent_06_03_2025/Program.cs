using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace Zadak_1_Teams_Klijent_06_03_2025
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        public static T Request<T>(string request)
        {
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Loopback, 1000);

            using Socket client = new Socket(
                iPEndPoint.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp
            );

            client.Connect(iPEndPoint);

            T result = default;

            try
            {
                while (true)
                {
                    string json = JsonSerializer.Serialize(request);
                    byte[] data = Encoding.UTF8.GetBytes(json);
                    client.Send(data);

                    byte[] buffer = new byte[2000];
                    int received = client.Receive(buffer, SocketFlags.None);

                    if (received > 0)
                    {
                        string response = Encoding.UTF8.GetString(buffer, 0, received);
                        result = JsonSerializer.Deserialize<T>(response);

                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Socket error during Receive: {ex.Message}");
            }
            finally
            {
                try
                {
                    client.Shutdown(SocketShutdown.Both);
                }
                catch (Exception) {}
            }

            return result;
        }
    }
}