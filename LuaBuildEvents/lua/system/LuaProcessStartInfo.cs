using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.system {
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

        public static LuaProcessStartInfo New() => new LuaProcessStartInfo();
        public static LuaProcessStartInfo New(string filename) => new LuaProcessStartInfo(filename);
        public static LuaProcessStartInfo New(string filename, string arguments) => new LuaProcessStartInfo(filename, arguments);

        public IDictionary<string, string> environment => _processStartInfo.Environment;
        public string[] verbs => _processStartInfo.Verbs;
        public ICollection<string> argumentlist => _processStartInfo.ArgumentList;

        public Dictionary<string, string> environmentVariableTable(string key) => _processStartInfo.EnvironmentVariables.Cast<KeyValuePair<string, string>>().ToDictionary(variable => variable.Key, variable => variable.Value);
        public string getEnvironmentVariable(string key) => _processStartInfo.EnvironmentVariables[key];
        public void setEnvironmentVariable(string key, string value) => _processStartInfo.EnvironmentVariables[key] = value;

        public string fileName {
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

        public string passwordInClearText {
            get => _processStartInfo.PasswordInClearText;
            set => _processStartInfo.PasswordInClearText = value;
        }

        public string userName {
            get => _processStartInfo.UserName;
            set => _processStartInfo.UserName = value;
        }

        public string verb {
            get => _processStartInfo.Verb;
            set => _processStartInfo.Verb = value;
        }

        public string workingDirectory {
            get => _processStartInfo.WorkingDirectory;
            set => _processStartInfo.WorkingDirectory = value;
        }

        public bool createNoWindow {
            get => _processStartInfo.CreateNoWindow;
            set => _processStartInfo.CreateNoWindow = value;
        }


        public bool errorDialog {
            get => _processStartInfo.ErrorDialog;
            set => _processStartInfo.ErrorDialog = value;
        }

        public bool loadUserProfile {
            get => _processStartInfo.LoadUserProfile;
            set => _processStartInfo.LoadUserProfile = value;
        }

        public bool useShellExecute {
            get => _processStartInfo.UseShellExecute;
            set => _processStartInfo.UseShellExecute = value;
        }

        public ProcessWindowStyle windowStyle {
            get => _processStartInfo.WindowStyle;
            set => _processStartInfo.WindowStyle = value;
        }

        public bool redirectStandardInput {
            get => _processStartInfo.RedirectStandardInput;
            set => _processStartInfo.RedirectStandardInput = value;
        }

        public bool redirectStandardOutput {
            get => _processStartInfo.RedirectStandardOutput;
            set => _processStartInfo.RedirectStandardOutput = value;
        }

        public bool redirectStandardError {
            get => _processStartInfo.RedirectStandardError;
            set => _processStartInfo.RedirectStandardError = value;
        }

        public string standardErrorEncoding {
            get => _processStartInfo.StandardErrorEncoding?.ToString();
            set => _processStartInfo.StandardErrorEncoding = Encoding.GetEncoding(value);
        }

        public string standardInputEncoding {
            get => _processStartInfo.StandardInputEncoding?.ToString();
            set => _processStartInfo.StandardInputEncoding = Encoding.GetEncoding(value);
        }

        public string standardOutputEncoding {
            get => _processStartInfo.StandardOutputEncoding?.ToString();
            set => _processStartInfo.StandardOutputEncoding = Encoding.GetEncoding(value);
        }
    }
}
