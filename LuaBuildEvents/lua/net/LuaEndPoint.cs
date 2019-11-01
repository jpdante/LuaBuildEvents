using System.Net;
using System.Net.Sockets;
using MoonSharp.Interpreter.Interop;

namespace LuaBuildEvents.lua.net {
    public class LuaEndPoint {
        [MoonSharpVisible(false)]
        public EndPoint EndPoint;

        public LuaEndPoint(EndPoint endPoint) { EndPoint = endPoint; }

        public AddressFamily addressFamily => EndPoint.AddressFamily;
    }
}
