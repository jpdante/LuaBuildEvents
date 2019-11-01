using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using MoonSharp.Interpreter.Interop;

namespace LuaBuildEvents.Internal.Lua.Net {
    public class LuaEndPoint {
        [MoonSharpVisible(false)]
        public EndPoint EndPoint;

        public LuaEndPoint(EndPoint endPoint) { EndPoint = endPoint; }

        public AddressFamily addressFamily => EndPoint.AddressFamily;
    }
}
