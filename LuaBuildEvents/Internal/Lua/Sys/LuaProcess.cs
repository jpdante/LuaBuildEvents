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
            start_info = new LuaProcessStartInfo(_process.StartInfo) {
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
            start_info = processStartInfo;
            _process.OutputDataReceived += ProcessOnOutputDataReceived;
            _process.ErrorDataReceived += ProcessOnErrorDataReceived;
            _process.Exited += ProcessOnExited;
            _process.Disposed += ProcessOnDisposed;
            UserData.RegisterType<EventArgs>();
            UserData.RegisterType<DataReceivedEventArgs>();
        }

        public static LuaProcess create(string path) => new LuaProcess(path);
        public static LuaProcess create(LuaProcessStartInfo processStartInfo) => new LuaProcess(processStartInfo);

        public event EventHandler on_output_data_received;
        public event EventHandler on_error_data_received;
        public event EventHandler on_exited;
        public event EventHandler on_disposed;

        public LuaProcessStartInfo start_info {
            get => _startinfo;
            set {
                _process.StartInfo = value.GetProcessStartInfo();
                _startinfo = value;
            }
        }

        public int session_id => _process.SessionId;
        public string machine_name => _process.MachineName;
        public string main_window_title => _process.MainWindowTitle;
        public string process_name => _process.ProcessName;
        public int base_priority => _process.BasePriority;
        public int exit_code => _process.ExitCode;
        public DateTime exit_time => _process.ExitTime;
        public int handle_count => _process.HandleCount;
        public bool has_exited => _process.HasExited;
        public int id => _process.Id;
        public long nonpaged_system_memory_size64 => _process.NonpagedSystemMemorySize64;
        public long paged_memory_size64 => _process.PagedMemorySize64;
        public long paged_system_memory_size64 => _process.PagedSystemMemorySize64;
        public long peak_paged_memory_size64 => _process.PeakPagedMemorySize64;
        public long peak_virtual_memory_size64 => _process.PeakVirtualMemorySize64;
        public long peak_working_set64 => _process.PeakWorkingSet64;
        public long private_memory_size64 => _process.PrivateMemorySize64;
        public TimeSpan privileged_processor_time => _process.PrivilegedProcessorTime;
        public LuaStreamReader standarderror => new LuaStreamReader(_process.StandardError);
        public LuaStreamWriter standardinput => new LuaStreamWriter(_process.StandardInput);
        public LuaStreamReader standardoutput => new LuaStreamReader(_process.StandardOutput);
        public DateTime start_time => _process.StartTime;
        public TimeSpan total_processor_time => _process.TotalProcessorTime;
        public TimeSpan user_processor_time => _process.UserProcessorTime;
        public bool responding => _process.Responding;
        public long virtual_memory_size64 => _process.VirtualMemorySize64;
        public long working_set64 => _process.WorkingSet64;

        public bool enable_raising_events {
            get => _process.EnableRaisingEvents;
            set => _process.EnableRaisingEvents = value;
        }

        public bool priority_boost_enabled {
            get => _process.PriorityBoostEnabled;
            set => _process.PriorityBoostEnabled = value;
        }

        public string priorityclass {
            get => _process.PriorityClass.ToString();
            set {
                if (!Enum.TryParse(value, out ProcessPriorityClass result)) {
                    _process.PriorityClass = result;
                }
                throw new ScriptRuntimeException("Failed to parse ProcessPriorityClass.");
            }
        }

        public void begin_error_read_line() => _process.BeginErrorReadLine();
        public void begin_output_read_line() => _process.BeginOutputReadLine();
        public void cancel_error_read() => _process.CancelErrorRead();
        public void cancel_output_read() => _process.CancelOutputRead();
        public bool close_main_window() => _process.CloseMainWindow();
        public void wait_for_exit() => _process.WaitForExit();
        public bool wait_for_exit(int milliseconds) => _process.WaitForExit(milliseconds);
        public bool wait_for_input_idle() => _process.WaitForInputIdle();
        public bool wait_for_input_idle(int milliseconds) => _process.WaitForInputIdle(milliseconds);
        public void close() => _process.Close();
        public void kill() => _process.Kill();
        public void kill(bool entireProcessTree) => _process.Kill(entireProcessTree);
        public void refresh() => _process.Refresh();
        public bool start() => _process.Start();
        public void dispose() => _process.Dispose();

        [MoonSharpVisible(false)]
        private void ProcessOnOutputDataReceived(object sender, DataReceivedEventArgs e) { on_output_data_received?.Invoke(this, e); }

        [MoonSharpVisible(false)]
        private void ProcessOnErrorDataReceived(object sender, DataReceivedEventArgs e) { on_error_data_received?.Invoke(this, e); }

        [MoonSharpVisible(false)]
        private void ProcessOnExited(object sender, EventArgs e) { on_exited?.Invoke(this, e); }

        [MoonSharpVisible(false)]
        private void ProcessOnDisposed(object sender, EventArgs e) { on_disposed?.Invoke(this, e); }
    }
}
