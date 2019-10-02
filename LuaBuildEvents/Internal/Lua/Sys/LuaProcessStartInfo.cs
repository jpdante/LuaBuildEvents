using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.Internal.Lua.Sys {
    public class LuaProcessStartInfo {
        [MoonSharpVisible(false)]
        private readonly ProcessStartInfo _processStartInfo;

        [MoonSharpVisible(false)]
        public ProcessStartInfo GetProcessStartInfo() => _processStartInfo;

        public LuaProcessStartInfo() {
            _processStartInfo = new ProcessStartInfo();
        }

        public LuaProcessStartInfo(ProcessStartInfo processStartInfo) {
            _processStartInfo = processStartInfo;
        }

        public LuaProcessStartInfo(string filename) {
            _processStartInfo = new ProcessStartInfo(filename);
        }

        public LuaProcessStartInfo(string filename, string arguments) {
            _processStartInfo = new ProcessStartInfo(filename, arguments);
        }

        public static LuaProcessStartInfo create() => new LuaProcessStartInfo();
        public static LuaProcessStartInfo create(string filename) => new LuaProcessStartInfo(filename);
        public static LuaProcessStartInfo create(string filename, string arguments) => new LuaProcessStartInfo(filename, arguments);

        public IDictionary<string, string> environment => _processStartInfo.Environment;
        public string[] verbs => _processStartInfo.Verbs;
        public ICollection<string> argumentlist => _processStartInfo.ArgumentList;

        public Dictionary<string, string> environment_variable_table(string key) => _processStartInfo.EnvironmentVariables.Cast<KeyValuePair<string, string>>().ToDictionary(variable => variable.Key, variable => variable.Value);
        public string get_environment_variable(string key) => _processStartInfo.EnvironmentVariables[key];
        public void set_environment_variable(string key, string value) => _processStartInfo.EnvironmentVariables[key] = value;

        public string file_name {
            get => _processStartInfo.FileName;
            set => _processStartInfo.FileName = value;
        }

        public string arguments {
            get => _processStartInfo.Arguments;
            set => _processStartInfo.Arguments = value;
        }

        public string domain {
            get => _processStartInfo.PasswordInClearText;
            set => _processStartInfo.PasswordInClearText = value;
        }

        public string password_in_clear_text {
            get => _processStartInfo.PasswordInClearText;
            set => _processStartInfo.PasswordInClearText = value;
        }

        public string user_name {
            get => _processStartInfo.UserName;
            set => _processStartInfo.UserName = value;
        }

        public string verb {
            get => _processStartInfo.Verb;
            set => _processStartInfo.Verb = value;
        }

        public string working_directory {
            get => _processStartInfo.WorkingDirectory;
            set => _processStartInfo.WorkingDirectory = value;
        }

        public bool create_no_window {
            get => _processStartInfo.CreateNoWindow;
            set => _processStartInfo.CreateNoWindow = value;
        }


        public bool error_dialog {
            get => _processStartInfo.ErrorDialog;
            set => _processStartInfo.ErrorDialog = value;
        }

        public bool load_user_profile {
            get => _processStartInfo.LoadUserProfile;
            set => _processStartInfo.LoadUserProfile = value;
        }

        public bool use_shell_execute {
            get => _processStartInfo.UseShellExecute;
            set => _processStartInfo.UseShellExecute = value;
        }

        public string window_style {
            get => _processStartInfo.WindowStyle.ToString();
            set {
                if (!Enum.TryParse(value, out ProcessWindowStyle result)) {
                    _processStartInfo.WindowStyle = result;
                }
                throw new ScriptRuntimeException("Failed to parse ProcessWindowStyle.");
            }
        }

        public bool redirect_standard_input {
            get => _processStartInfo.RedirectStandardInput;
            set => _processStartInfo.RedirectStandardInput = value;
        }

        public bool redirect_standard_output {
            get => _processStartInfo.RedirectStandardOutput;
            set => _processStartInfo.RedirectStandardOutput = value;
        }

        public bool redirect_standard_error {
            get => _processStartInfo.RedirectStandardError;
            set => _processStartInfo.RedirectStandardError = value;
        }

        public string standard_error_encoding {
            get => _processStartInfo.StandardErrorEncoding?.ToString();
            set => _processStartInfo.StandardErrorEncoding = Encoding.GetEncoding(value);
        }

        public string standard_input_encoding {
            get => _processStartInfo.StandardInputEncoding?.ToString();
            set => _processStartInfo.StandardInputEncoding = Encoding.GetEncoding(value);
        }

        public string standard_output_encoding {
            get => _processStartInfo.StandardOutputEncoding?.ToString();
            set => _processStartInfo.StandardOutputEncoding = Encoding.GetEncoding(value);
        }
    }
}
