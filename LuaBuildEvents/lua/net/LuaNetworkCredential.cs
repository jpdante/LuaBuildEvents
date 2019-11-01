using System;
using System.Net;
using System.Security;
using LuaBuildEvents.lua.security;
using LuaBuildEvents.lua.system;
using MoonSharp.Interpreter.Interop;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.net {
    public class LuaNetworkCredential : LuaICredentials {
        [MoonSharpVisible(false)]
        private readonly NetworkCredential _networkCredential;

        [MoonSharpVisible(false)]
        public NetworkCredential GetNetworkCredential() { return _networkCredential; }

        public LuaNetworkCredential() {
            _networkCredential = new NetworkCredential();
            SetCredentials(_networkCredential);
        }

        public LuaNetworkCredential(string username, LuaSecureString password) {
            _networkCredential = new NetworkCredential(username, password.GetSecureString());
            SetCredentials(_networkCredential);
        }

        public LuaNetworkCredential(string username, LuaSecureString password, string domain) {
            _networkCredential = new NetworkCredential(username, password.GetSecureString(), domain);
            SetCredentials(_networkCredential);
        }

        public LuaNetworkCredential(string username, string password) {
            _networkCredential = new NetworkCredential(username, password);
            SetCredentials(_networkCredential);
        }

        public LuaNetworkCredential(string username, string password, string domain) {
            _networkCredential = new NetworkCredential(username, password, domain);
            SetCredentials(_networkCredential);
        }

        public LuaNetworkCredential(NetworkCredential networkCredential) {
            _networkCredential = networkCredential;
            SetCredentials(_networkCredential);
        }

        public static LuaNetworkCredential New(string username, LuaSecureString password) => new LuaNetworkCredential(username, password);
        public static LuaNetworkCredential New(string username, LuaSecureString password, string domain) => new LuaNetworkCredential(username, password, domain);
        public static LuaNetworkCredential New(string username, string password) => new LuaNetworkCredential(username, password);
        public static LuaNetworkCredential New(string username, string password, string domain) => new LuaNetworkCredential(username, password, domain);

        public string UserName {
            get => _networkCredential.UserName;
            set => _networkCredential.UserName = value;
        }

        public string Password {
            get => _networkCredential.Password;
            set => _networkCredential.Password = value;
        }

        public string Domain {
            get => _networkCredential.Domain;
            set => _networkCredential.Domain = value;
        }

        public LuaSecureString SecurePassword {
            get => new LuaSecureString(_networkCredential.SecurePassword);
            set => _networkCredential.SecurePassword = value.GetSecureString();
        }

        public NetworkCredential getCredential(string host, int port, string authenticationType) => _networkCredential.GetCredential(host, port, authenticationType);
        public NetworkCredential getCredential(LuaUri uri, string authenticationType) => _networkCredential.GetCredential(uri.GetUri(), authenticationType);
    }
}