using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MoonSharp.Interpreter.Interop;

namespace LuaBuildEvents.lua.reflection {
    public class LuaModule {

        [MoonSharpVisible(false)]
        private readonly Module _module;

        [MoonSharpVisible(false)]
        public Module GetModule() { return _module; }
        
        public LuaModule(Module module) { this._module = module; }

        // TODO: Methods and Variables

    }
}
