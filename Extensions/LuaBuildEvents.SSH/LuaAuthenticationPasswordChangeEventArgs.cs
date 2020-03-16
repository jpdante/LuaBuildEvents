using System;
using System.Collections.Generic;
using System.Text;
using MoonSharp.Interpreter.Interop;
using Renci.SshNet;
using Renci.SshNet.Common;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.SSH {
    public class LuaAuthenticationPasswordChangeEventArgs : EventArgs {

        [MoonSharpVisible(false)]
        private readonly AuthenticationPasswordChangeEventArgs _authenticationPasswordChangeEventArgs;

        [MoonSharpVisible(false)]
        public AuthenticationPasswordChangeEventArgs GetAuthenticationPasswordChangeEventArgs() => _authenticationPasswordChangeEventArgs;

        public LuaAuthenticationPasswordChangeEventArgs(AuthenticationPasswordChangeEventArgs authenticationPasswordChangeEventArgs) {
            _authenticationPasswordChangeEventArgs = authenticationPasswordChangeEventArgs;
        }

        public string username => _authenticationPasswordChangeEventArgs.Username;

        public byte[] newPassword {
            get => _authenticationPasswordChangeEventArgs.NewPassword;
            set => _authenticationPasswordChangeEventArgs.NewPassword = value;
        }

        public void setNewPassword(string password) {
            _authenticationPasswordChangeEventArgs.NewPassword = Encoding.UTF8.GetBytes(password);
        }

    }
}
