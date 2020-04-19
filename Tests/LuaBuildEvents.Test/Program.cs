using System;
using System.Diagnostics;
using System.IO;

namespace LuaBuildEvents.Test {
    public static class Program {
        public static void Main(string[] args) {
            if (args == null || args.Length <= 0) return;
            var startInfo = new ProcessStartInfo {
                FileName = "dotnet.exe",
                Arguments = $@"{args[0]}\LuaBuildEvents\bin\Debug\netcoreapp3.1\LuaBuildEvents.dll {Path.Combine(Environment.CurrentDirectory, @"lua\test_all.lua")}",
                WorkingDirectory = Path.Combine(Environment.CurrentDirectory, @"lua\"),
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            var process = new Process {
                StartInfo = startInfo
            };
            process.OutputDataReceived += ProcessOnOutputDataReceived;
            process.ErrorDataReceived += ProcessOnErrorDataReceived;
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
        }

        private static void ProcessOnErrorDataReceived(object sender, DataReceivedEventArgs e) {
            if (e.Data == null || e.Data.Equals(string.Empty)) {
                return;
            }
            Console.WriteLine(e.Data);
        }

        private static void ProcessOnOutputDataReceived(object sender, DataReceivedEventArgs e) {
            if (e.Data == null || e.Data.Equals(string.Empty)) {
                return;
            }
            Console.WriteLine(e.Data);
        }
    }
}
