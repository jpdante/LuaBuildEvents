// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

using MoonSharp.Interpreter.Interop;
using Renci.SshNet;

namespace LuaBuildEvents.SSH {
    public class LuaForwardedPort {

        [MoonSharpVisible(false)]
        private readonly ForwardedPort _forwardedPort;

        [MoonSharpVisible(false)]
        public ForwardedPort GetForwardedPort() => _forwardedPort;

        public LuaForwardedPort(ForwardedPort forwardedPort) {
            _forwardedPort = forwardedPort;
        }

    }
}