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
    public class LuaPasswordAuthenticationMethod : LuaAuthenticationMethod {

        public LuaPasswordAuthenticationMethod(string username, byte[] password) {
            AuthenticationMethod = new PasswordAuthenticationMethod(username, password);
        }

        public LuaPasswordAuthenticationMethod(string username, string password) {
            AuthenticationMethod = new PasswordAuthenticationMethod(username, password);
            ((PasswordAuthenticationMethod)AuthenticationMethod).PasswordExpired += OnPasswordExpired;
        }

        public static LuaPasswordAuthenticationMethod New(string username, byte[] password) => new LuaPasswordAuthenticationMethod(username, password);
        public static LuaPasswordAuthenticationMethod New(string username, string password) => new LuaPasswordAuthenticationMethod(username, password);

        #region Events

        public event EventHandler onPasswordExpired;

        private void OnPasswordExpired(object sender, AuthenticationPasswordChangeEventArgs e) {
            onPasswordExpired?.Invoke(sender, new LuaAuthenticationPasswordChangeEventArgs(e));
        }

        #endregion

        #region Variables

        public string name => ((PasswordAuthenticationMethod)AuthenticationMethod).Name;

        public string username => ((PasswordAuthenticationMethod)AuthenticationMethod).Username;

        public string[] allowedAuthentications => ((PasswordAuthenticationMethod)AuthenticationMethod).AllowedAuthentications;

        #endregion

    }
}
