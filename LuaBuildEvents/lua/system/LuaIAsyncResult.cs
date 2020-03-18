using System;
using MoonSharp.Interpreter.Interop;

namespace LuaBuildEvents.lua.system {
    public class LuaIAsyncResult {

        [MoonSharpVisible(false)]
        private readonly IAsyncResult _iAsyncResult;

        [MoonSharpVisible(false)]
        public IAsyncResult GetIAsyncResult() => _iAsyncResult;

        public LuaIAsyncResult(IAsyncResult iAsyncResult) {
            _iAsyncResult = iAsyncResult;
        }

        public bool completedSynchronously => _iAsyncResult.CompletedSynchronously;
        public bool isCompleted => _iAsyncResult.IsCompleted;

    }
}
