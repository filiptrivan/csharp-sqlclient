using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace PowershellProcesses
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var a = GenerateKeyPair();

            //DateTime d1 = new DateTime(1990, 1, 1, 23, 50, 0);
            //DateTime d2 = new DateTime(1990, 1, 1, 00, 10, 0);
            //Console.WriteLine(GetMinuteDifference(d1, d2));

            //DateTime d3 = new DateTime(1990, 1, 1, 23, 50, 0);
            //DateTime d4 = new DateTime(1990, 1, 2, 00, 10, 0);
            //Console.WriteLine(GetMinuteDifference(d3, d4));

            //DateTime d5 = new DateTime(1990, 1, 1, 00, 20, 0);
            //DateTime d6 = new DateTime(1990, 1, 2, 00, 10, 0);
            //Console.WriteLine(GetMinuteDifference(d5, d6));

            //string frontendPath = @$"C:\Users\user\Documents\Projects\Test13\test-13\Angular";

            //Console.WriteLine("\nNpm install...");
            //bool isWin = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            //string npmCmd = isWin ? "cmd.exe" : "/bin/bash";
            //string npmArgs = isWin ? "/c npm install" : "-c \"npm install\"";
            //if (!await RunCommand(npmCmd, npmArgs, frontendPath))
            //    return;
        }

        public static (string publicKey, string privateKey) GenerateKeyPair()
        {
            using (var ecdsa = ECDsa.Create(ECCurve.NamedCurves.nistP256))
            {
                var privateKeyPem = Convert.ToBase64String(ecdsa.ExportECPrivateKey());
                var publicKeyPem = Convert.ToBase64String(ecdsa.ExportSubjectPublicKeyInfo());
                return (publicKeyPem, privateKeyPem);
            }
        }


        private static decimal GetMinuteDifference(DateTime d1, DateTime d2)
        {
            double difference = Math.Abs((d1.TimeOfDay - d2.TimeOfDay).TotalMinutes); // FT: eg. 23:50 - 00:10 => 1420
            double shortest = Math.Min(difference, 1440 - difference); // FT: eg. Math.Min(1420, 20) => 20
            return (decimal)shortest;
        }

        private static async Task<bool> RunCommand(string fileName, string arguments, string workingDirectory)
        {
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = arguments,
                    WorkingDirectory = workingDirectory,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = false
                },
                EnableRaisingEvents = true
            };

            process.OutputDataReceived += (sender, e) => { if (e.Data != null) Console.WriteLine(e.Data); };
            process.ErrorDataReceived += (sender, e) => { if (e.Data != null) Console.Error.WriteLine(e.Data); };

            process.Start();

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            await process.WaitForExitAsync();

            return process.ExitCode == 0;
        }

        private static void OpenFile(string fileName, string arguments, string workingDirectory)
        {
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = arguments,
                    WorkingDirectory = workingDirectory,
                    UseShellExecute = true,
                    CreateNoWindow = false
                },
            };

            process.Start();
        }
    }
}