using System.Net.Sockets;
using System.Net;
using System.Text.Json;
using System.Text;
using vesala_server;

namespace vesala_client
{
    internal static class Program
    {
        public static Form1 FormInstance { get; set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            FormInstance = new Form1();

            Application.Run(FormInstance);
        }
    }
}