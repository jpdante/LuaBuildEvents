using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using LuaBuildEvents.Internal.Lua.IO;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.Internal.Lua.Sys {
    public class LuaProcess {
        [MoonSharpVisible(false)]
        private readonly Process _process;

        [MoonSharpVisible(false)] 
        private LuaProcessStartInfo _startinfo;

        [MoonSharpVisible(false)]
        public Process GetProcess() => _process;

        public LuaProcess(string path) {
            _process = new Process();
            startInfo = new LuaProcessStartInfo(_process.StartInfo) {
                file_name = path
            };
            _process.OutputDataReceived += ProcessOnOutputDataReceived;
            _process.ErrorDataReceived += ProcessOnErrorDataReceived;
            _process.Exited += ProcessOnExited;
            _process.Disposed += ProcessOnDisposed;
            UserData.RegisterType<EventArgs>();
            UserData.RegisterType<DataReceivedEventArgs>();
        }

        public LuaProcess(LuaProcessStartInfo processStartInfo) {
            _process = new Process();
            startInfo = processStartInfo;
            _process.OutputDataReceived += ProcessOnOutputDataReceived;
            _process.ErrorDataReceived += ProcessOnErrorDataReceived;
            _process.Exited += ProcessOnExited;
            _process.Disposed += ProcessOnDisposed;
            UserData.RegisterType<EventArgs>();
            UserData.RegisterType<DataReceivedEventArgs>();
        }

        public static LuaProcess New(string path) => new LuaProcess(path);
        public static LuaProcess New(LuaProcessStartInfo processStartInfo) => new LuaProcess(processStartInfo);

        public event EventHandler onOutputDataReceived;
        public event EventHandler onErrorDataReceived;
        public event EventHandler onExited;
        public event EventHandler onDisposed;

        public LuaProcessStartInfo startInfo {
            get => _startinfo;
            set {
                _process.StartInfo = value.GetProcessStartInfo();
                _startinfo = value;
            }
        }

        public int sessionID => _process.SessionId;
        public string machineName => _process.MachineName;
        public string mainWindowTitle => _process.MainWindowTitle;
        public string processName => _process.ProcessName;
        public int basePriority => _process.BasePriority;
        public int exitCode => _process.ExitCode;
        public DateTime exitTime => _process.ExitTime;
        public int handleCount => _process.HandleCount;
        public bool hasExited => _process.HasExited;
        public int id => _process.Id;
        public long nonpagedSystemMemorySize64 => _process.NonpagedSystemMemorySize64;
        public long pagedMemorySize64 => _process.PagedMemorySize64;
        public long pagedSystemMemorySize64 => _process.PagedSystemMemorySize64;
        public long peakPagedMemorySize64 => _process.PeakPagedMemorySize64;
        public long peakVirtualMemorySize64 => _process.PeakVirtualMemorySize64;
        public long peakWorkingSet64 => _process.PeakWorkingSet64;
        public long privateMemorySize64 => _process.PrivateMemorySize64;
        public TimeSpan privilegedProcessorTime => _process.PrivilegedProcessorTime;
        public LuaStreamReader standardError => new LuaStreamReader(_process.StandardError);
        public LuaStreamWriter standardInput => new LuaStreamWriter(_process.StandardInput);
        public LuaStreamReader standardOutput => new LuaStreamReader(_process.StandardOutput);
        public DateTime startTime => _process.StartTime;
        public TimeSpan totalProcessorTime => _process.TotalProcessorTime;
        public TimeSpan userProcessorTime => _process.UserProcessorTime;
        public bool responding => _process.Responding;
        public long virtualMemorySize64 => _process.VirtualMemorySize64;
        public long workingSet64 => _process.WorkingSet64;

        public bool enableRaisingEvents {
            get => _process.EnableRaisingEvents;
            set => _process.EnableRaisingEvents = value;
        }

        public bool priorityBoostEnabled {
            get => _process.PriorityBoostEnabled;
            set => _process.PriorityBoostEnabled = value;
        }

        public string priorityClass {
            get => _process.PriorityClass.ToString();
            set {
                if (!Enum.TryParse(value, out ProcessPriorityClass result)) {
                    _process.PriorityClass = result;
                }
                throw new ScriptRuntimeException("Failed to parse ProcessPriorityClass.");
            }
        }

        public void beginErrorReadLine() => _process.BeginErrorReadLine();
        public void beginOutputReadLine() => _process.BeginOutputReadLine();
        public void cancelErrorRead() => _process.CancelErrorRead();
        public void cancelOutputRead() => _process.CancelOutputRead();
        public bool closeMainWindow() => _process.CloseMainWindow();
        public void waitForExit() => _process.WaitForExit();
        public bool waitForExit(int milliseconds) => _process.WaitForExit(milliseconds);
        public bool waitForInputIdle() => _process.WaitForInputIdle();
        public bool waitForInputIdle(int milliseconds) => _process.WaitForInputIdle(milliseconds);
        public void close() => _process.Close();
        public void kill() => _process.Kill();
        public void kill(bool entireProcessTree) => _process.Kill(entireProcessTree);
        public void refresh() => _process.Refresh();
        public bool start() => _process.Start();
        public void dispose() => _process.Dispose();

        [MoonSharpVisible(false)]
        private void ProcessOnOutputDataReceived(object sender, DataReceivedEventArgs e) { onOutputDataReceived?.Invoke(this, e); }

        [MoonSharpVisible(false)]
        private void ProcessOnErrorDataReceived(object sender, DataReceivedEventArgs e) { onErrorDataReceived?.Invoke(this, e); }

        [MoonSharpVisible(false)]
        private void ProcessOnExited(object sender, EventArgs e) { onExited?.Invoke(this, e); }

        [MoonSharpVisible(false)]
        private void ProcessOnDisposed(object sender, EventArgs e) { onDisposed?.Invoke(this, e); }
    }
}
