using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LuaBuildEvents.lua.io;
using LuaBuildEvents.lua.system;
using MoonSharp.Interpreter.Interop;
using Renci.SshNet;
using Renci.SshNet.Common;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.SSH {
    public class LuaSshClient {

        [MoonSharpVisible(false)]
        private readonly SshClient _sshClient;

        [MoonSharpVisible(false)]
        public SshClient GetSshClient() => _sshClient;

        public LuaSshClient(ConnectionInfo connectionInfo) {
            _sshClient = new SshClient(connectionInfo);
            _sshClient.HostKeyReceived += SshClientOnHostKeyReceived;
            _sshClient.ErrorOccurred += SshClientOnErrorOccurred;
        }

        public LuaSshClient(string host, int port, string username, params PrivateKeyFile[] keyFiles) {
            _sshClient = new SshClient(host, port, username, keyFiles);
            _sshClient.HostKeyReceived += SshClientOnHostKeyReceived;
            _sshClient.ErrorOccurred += SshClientOnErrorOccurred;
        }

        public LuaSshClient(string host, int port, string username, string password) {
            _sshClient = new SshClient(host, port, username, password);
            _sshClient.HostKeyReceived += SshClientOnHostKeyReceived;
            _sshClient.ErrorOccurred += SshClientOnErrorOccurred;
        }

        public LuaSshClient(string host, string username, params PrivateKeyFile[] keyFiles) {
            _sshClient = new SshClient(host, username, keyFiles);
            _sshClient.HostKeyReceived += SshClientOnHostKeyReceived;
            _sshClient.ErrorOccurred += SshClientOnErrorOccurred;
        }

        public LuaSshClient(string host, string username, string password) {
            _sshClient = new SshClient(host, username, password);
            _sshClient.HostKeyReceived += SshClientOnHostKeyReceived;
            _sshClient.ErrorOccurred += SshClientOnErrorOccurred;
        }

        #region Events

        public event EventHandler onErrorOccurred;
        public event EventHandler onHostKeyReceived;

        private void SshClientOnErrorOccurred(object sender, ExceptionEventArgs e) {
            onErrorOccurred?.Invoke(sender, e);
        }

        private void SshClientOnHostKeyReceived(object sender, HostKeyEventArgs e) {
            onHostKeyReceived?.Invoke(sender, e);
        }

        #endregion

        #region Variables

        public LuaConnectionInfo connectionInfo => new LuaConnectionInfo(_sshClient.ConnectionInfo);

        public bool isConnected => _sshClient.IsConnected;

        public LuaTimeSpan keepAliveInterval {
            get => new LuaTimeSpan(_sshClient.KeepAliveInterval);
            set => _sshClient.KeepAliveInterval = value.GetTimeSpan();
        }

        public LuaForwardedPort[] forwardedPorts => _sshClient.ForwardedPorts.Select(forwardedPort => new LuaForwardedPort(forwardedPort)).ToArray();

        #endregion

        #region Sync

        public void addForwardedPort(LuaForwardedPort luaForwardedPort) => _sshClient.AddForwardedPort(luaForwardedPort.GetForwardedPort());
        public LuaSshCommand createCommand(string commandText) => new LuaSshCommand(_sshClient.CreateCommand(commandText));
        public LuaSshCommand createCommand(string commandText, string encoding) => new LuaSshCommand(_sshClient.CreateCommand(commandText, Encoding.GetEncoding(encoding)));
        // TODO: Implement CreateShellStream and CreateShell
        // public void createShell() => _sshClient.CreateShell()
        // public LuaStream createShellStream(string terminalName, uint columns, uint rows, uint width, uint height, int bufferSize) => new LuaStream(_sshClient.CreateShellStream(terminalName, columns, rows, width, height, bufferSize));
        // public LuaStream createShellStream(string terminalName, uint columns, uint rows, uint width, uint height, int bufferSize, IDictionary<TerminalModes, uint> terminalModeValues) => new LuaStream(_sshClient.CreateShellStream(terminalName, columns, rows, width, height, bufferSize, terminalModeValues));
        public void removeForwardedPort(LuaForwardedPort luaForwardedPort) => _sshClient.RemoveForwardedPort(luaForwardedPort.GetForwardedPort());
        public LuaSshCommand runCommand(string commandText) => new LuaSshCommand(_sshClient.RunCommand(commandText));
        public void connect() => _sshClient.Connect();
        public void disconnect() => _sshClient.Disconnect();
        public void dispose() => _sshClient.Dispose();

        #endregion

    }
}