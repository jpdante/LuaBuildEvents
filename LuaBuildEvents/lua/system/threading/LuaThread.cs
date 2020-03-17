using System;
using System.Threading;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.system.threading {
    public class LuaThread {

        [MoonSharpVisible(false)]
        private readonly Thread _thread;

        [MoonSharpVisible(false)]
        public Thread GetThread() => _thread;

        public LuaThread(DynValue method) {
            _thread = new Thread(() => {
                Program.Script.Call(method);
            });
        }

        public LuaThread(DynValue method, params object[] parameters) {
            _thread = new Thread(() => {
                Program.Script.Call(method, parameters);
            });
        }
        
        public static LuaThread New(DynValue method) => new LuaThread(method);
        public static LuaThread New(DynValue method, params object[] parameters) => new LuaThread(method, parameters);

        #region Variables

        public int managedThreadID => _thread.ManagedThreadId;
        public bool isAlive => _thread.IsAlive;
        public bool isBackground => _thread.IsBackground;
        public bool isThreadPoolThread => _thread.IsThreadPoolThread;
        public string name => _thread.Name;
        public string threadState => _thread.ThreadState.ToString();

        public ThreadPriority priority {
            get => _thread.Priority;
            set => _thread.Priority = value;
        }

        #endregion

        #region Sync
        public void abort() => _thread.Abort();
        public void disableComObjectEagerCleanup() => _thread.DisableComObjectEagerCleanup();
        public void interrupt() => _thread.Interrupt();
        public void join() => _thread.Join();
        public bool join(int millisecondsTimeout) => _thread.Join(millisecondsTimeout);
        public void start() => _thread.Start();
        public void start(object parameter) => _thread.Start(parameter);
        #endregion
    }
}
