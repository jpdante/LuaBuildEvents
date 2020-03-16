using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoonSharp.Interpreter.Interop;
using Renci.SshNet;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.SSH {
    public class LuaConnectionInfo {

        [MoonSharpVisible(false)]
        private readonly ConnectionInfo _connectionInfo;

        [MoonSharpVisible(false)]
        public ConnectionInfo GetConnectionInfo() => _connectionInfo;

        public LuaConnectionInfo(ConnectionInfo connectionInfo) {
            _connectionInfo = connectionInfo;
        }

        public LuaConnectionInfo(string host, int port, string username, ProxyTypes proxyTypes, string proxyHost, int proxyPort, string proxyUsername, string proxyPassword, params AuthenticationMethod[] authenticationMethods) {
            _connectionInfo = new ConnectionInfo(host, port, username, proxyTypes, proxyHost, proxyPort, proxyUsername, proxyPassword, authenticationMethods);
        }

        public LuaConnectionInfo(string host, int port, string username, params AuthenticationMethod[] authenticationMethods) {
            _connectionInfo = new ConnectionInfo(host, port, username, authenticationMethods);
        }

        public LuaConnectionInfo(string host, string username, params AuthenticationMethod[] authenticationMethods) {
            _connectionInfo = new ConnectionInfo(host, username, authenticationMethods);
        }

        public static LuaConnectionInfo New(string host, int port, string username, params LuaAuthenticationMethod[] luaAuthenticationMethods) => new LuaConnectionInfo(host, port, username, luaAuthenticationMethods.Select(authenticationMethod => authenticationMethod.GetAuthenticationMethod()).ToArray());
        public static LuaConnectionInfo New(string host, string username, params LuaAuthenticationMethod[] luaAuthenticationMethods) => new LuaConnectionInfo(host, username, luaAuthenticationMethods.Select(authenticationMethod => authenticationMethod.GetAuthenticationMethod()).ToArray());

        #region Variables

        public bool isAuthenticated => _connectionInfo.IsAuthenticated;

        public string host => _connectionInfo.Host;

        public int port => _connectionInfo.Port;

        public string username => _connectionInfo.Username;

        public ProxyTypes proxyType => _connectionInfo.ProxyType;

        public string proxyHost => _connectionInfo.ProxyHost;

        public int proxyPort => _connectionInfo.ProxyPort;

        public string proxyUsername => _connectionInfo.ProxyUsername;

        public string proxyPassword => _connectionInfo.ProxyPassword;

        public double timeout {
            get => _connectionInfo.Timeout.TotalSeconds;
            set => _connectionInfo.Timeout = TimeSpan.FromSeconds(value);
        }

        public string encoding {
            get => _connectionInfo.Encoding.ToString();
            set => _connectionInfo.Encoding = Encoding.GetEncoding(value);
        }

        public int retryAttempts {
            get => _connectionInfo.RetryAttempts;
            set => _connectionInfo.RetryAttempts = value;
        }

        public int maxSessions {
            get => _connectionInfo.MaxSessions;
            set => _connectionInfo.MaxSessions = value;
        }

        public string currentKeyExchangeAlgorithm => _connectionInfo.CurrentKeyExchangeAlgorithm;

        public string currentServerEncryption => _connectionInfo.CurrentServerEncryption;

        public string currentClientEncryption => _connectionInfo.CurrentClientEncryption;

        public string currentServerHmacAlgorithm => _connectionInfo.CurrentServerHmacAlgorithm;

        public string currentClientHmacAlgorithm => _connectionInfo.CurrentClientHmacAlgorithm;

        public string currentHostKeyAlgorithm => _connectionInfo.CurrentHostKeyAlgorithm;

        public string currentServerCompressionAlgorithm => _connectionInfo.CurrentServerCompressionAlgorithm;

        public string serverVersion => _connectionInfo.ServerVersion;

        public string clientVersion => _connectionInfo.ClientVersion;

        public string currentClientCompressionAlgorithm => _connectionInfo.CurrentClientCompressionAlgorithm;

        #endregion
    }
}
