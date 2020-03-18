using LuaBuildEvents.lua.io;
using LuaBuildEvents.lua.system;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;
using Renci.SshNet;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.SSH {
    public class LuaSshCommand {

        [MoonSharpVisible(false)]
        private readonly SshCommand _sshCommand;

        [MoonSharpVisible(false)]
        public SshCommand GetSshCommand() => _sshCommand;

        public LuaSshCommand(SshCommand sshCommand) {
            _sshCommand = sshCommand;
        }

        #region Variables

        public string result => _sshCommand.Result;
        public string commandText => _sshCommand.CommandText;
        public LuaTimeSpan commandTimeout {
            get => new LuaTimeSpan(_sshCommand.CommandTimeout);
            set => _sshCommand.CommandTimeout = value.GetTimeSpan();
        }
        public string error => _sshCommand.Error;
        public int exitStatus => _sshCommand.ExitStatus;
        public LuaStream extendedOutputStream => new LuaStream(_sshCommand.ExtendedOutputStream);
        public LuaStream outputStream => new LuaStream(_sshCommand.OutputStream);

        #endregion

        #region Async

        public void beginExecute() => _sshCommand.BeginExecute();
        public void beginExecute(DynValue callBack) => _sshCommand.BeginExecute(
            ar => {
                Program.Script.Call(callBack, new LuaIAsyncResult(ar));
            }
        );
        public void beginExecute(DynValue callBack, DynValue state) => _sshCommand.BeginExecute(
            ar => {
                Program.Script.Call(callBack, new LuaIAsyncResult(ar));
            },
            state
        );
        public void beginExecute(string command, DynValue callBack, DynValue state) => _sshCommand.BeginExecute(
            command,
            ar => {
                Program.Script.Call(callBack, new LuaIAsyncResult(ar));
            },
            state
        );
        public void cancelAsync() => _sshCommand.CancelAsync();
        public string endExecute(LuaIAsyncResult luaIAsyncResult) => _sshCommand.EndExecute(luaIAsyncResult.GetIAsyncResult());

        #endregion

        #region Sync

        public void dispose() => _sshCommand.Dispose();
        public override string ToString() => _sshCommand.ToString();
        public string execute() => _sshCommand.Execute();
        public string execute(string command) => _sshCommand.Execute(command);

        #endregion

    }
}