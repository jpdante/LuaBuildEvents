using System;
using System.Collections.Generic;
using System.Text;
using MoonSharp.Interpreter.Interop;

namespace LuaBuildEvents.lua.reflection {
    public class LuaType {

        [MoonSharpVisible(false)]
        private readonly Type _type;

        [MoonSharpVisible(false)]
        public Type GetVarType() { return _type; }

        public LuaType(Type type) {
            this._type = type;
        }

        // TODO: Methods and Variables

    }
}
