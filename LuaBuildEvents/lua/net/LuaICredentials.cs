using System.Net;
using System.Reflection.Metadata.Ecma335;
using MoonSharp.Interpreter.Interop;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.net {
    public class LuaICredentials {
        [MoonSharpVisible(false)]
        private ICredentials _credentials;

        [MoonSharpVisible(false)]
        public ICredentials GetCredentials() => _credentials;

        [MoonSharpVisible(false)]
        public void SetCredentials(ICredentials credentials) { _credentials = credentials; }

        public LuaICredentials() { }

        public LuaICredentials(ICredentials credentials) { _credentials = credentials; }
    }
}