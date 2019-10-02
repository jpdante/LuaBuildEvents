using System;
using System.Diagnostics;
using System.IO;

namespace LuaBuildEvents.Test {
    public class Program {
        public static void Main(string[] args) {
            var startInfo = new ProcessStartInfo {
                FileName = "LuaBuildEvents.exe",
                Arguments = $"{Path.Combine(Environment.CurrentDirectory, "")} {Path.Combine(args[0], @"LuaBuildEvents.Test\lua\test_all.lua")}",
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
            Console.WriteLine($"[Test] {e.Data}");
        }

        private static void ProcessOnOutputDataReceived(object sender, DataReceivedEventArgs e) {
            Console.WriteLine($"[Test] {e.Data}");
        }
    }
}
