using System;
using System.Collections.Generic;
using System.Text;
using MoonSharp.Interpreter.Interop;
using Renci.SshNet;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.SSH {
    public class LuaAuthenticationMethod {

        [MoonSharpVisible(false)]
        protected AuthenticationMethod AuthenticationMethod;

        [MoonSharpVisible(false)]
        public AuthenticationMethod GetAuthenticationMethod() => AuthenticationMethod;

        public LuaAuthenticationMethod(AuthenticationMethod authenticationMethod) {
            AuthenticationMethod = authenticationMethod;
        }

        public LuaAuthenticationMethod() { }

    }
}
