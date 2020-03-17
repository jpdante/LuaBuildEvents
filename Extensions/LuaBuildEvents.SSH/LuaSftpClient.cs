using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
using LuaBuildEvents.lua.io;
using LuaBuildEvents.lua.system;
using MoonSharp.Interpreter.Interop;
using Renci.SshNet;
using Renci.SshNet.Common;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.SSH {
    public class LuaSftpClient {

        [MoonSharpVisible(false)]
        private readonly SftpClient _sftpClient;

        [MoonSharpVisible(false)]
        public SftpClient GetSftpClient() => _sftpClient;

        public LuaSftpClient(ConnectionInfo connectionInfo) {
            _sftpClient = new SftpClient(connectionInfo);
            _sftpClient.HostKeyReceived += SftpClientOnHostKeyReceived;
            _sftpClient.ErrorOccurred += SftpClientOnErrorOccurred;
        }

        public LuaSftpClient(string host, int port, string username, params PrivateKeyFile[] keyFiles) {
            _sftpClient = new SftpClient(host, port, username, keyFiles);
            _sftpClient.HostKeyReceived += SftpClientOnHostKeyReceived;
            _sftpClient.ErrorOccurred += SftpClientOnErrorOccurred;
        }

        public LuaSftpClient(string host, int port, string username, string password) {
            _sftpClient = new SftpClient(host, port, username, password);
            _sftpClient.HostKeyReceived += SftpClientOnHostKeyReceived;
            _sftpClient.ErrorOccurred += SftpClientOnErrorOccurred;
        }

        public LuaSftpClient(string host, string username, params PrivateKeyFile[] keyFiles) {
            _sftpClient = new SftpClient(host, username, keyFiles);
            _sftpClient.HostKeyReceived += SftpClientOnHostKeyReceived;
            _sftpClient.ErrorOccurred += SftpClientOnErrorOccurred;
        }

        public LuaSftpClient(string host, string username, string password) {
            _sftpClient = new SftpClient(host, username, password);
            _sftpClient.HostKeyReceived += SftpClientOnHostKeyReceived;
            _sftpClient.ErrorOccurred += SftpClientOnErrorOccurred;
        }

        public static SftpClient New(LuaConnectionInfo connectionInfo) => new SftpClient(connectionInfo.GetConnectionInfo());
        public static SftpClient New(string host, int port, string username, params LuaPrivateKeyFile[] luaKeyFiles) => new SftpClient(host, port, username, luaKeyFiles.Select(privateKeyFile => privateKeyFile.GetPrivateKeyFile()).ToArray());
        public static SftpClient New(string host, int port, string username, string password) => new SftpClient(host, port, username, password);
        public static SftpClient New(string host, string username, params LuaPrivateKeyFile[] luaKeyFiles) => new SftpClient(host, username, luaKeyFiles.Select(privateKeyFile => privateKeyFile.GetPrivateKeyFile()).ToArray());
        public static SftpClient New(string host, string username, string password) => new SftpClient(host, username, password);

        #region Events

        public event EventHandler onErrorOccurred;
        public event EventHandler onHostKeyReceived;

        private void SftpClientOnErrorOccurred(object sender, ExceptionEventArgs e) {
            onErrorOccurred?.Invoke(sender, e);
        }

        private void SftpClientOnHostKeyReceived(object sender, HostKeyEventArgs e) {
            onHostKeyReceived?.Invoke(sender, e);
        }

        #endregion

        #region Variables

        public string workingDirectory => _sftpClient.WorkingDirectory;

        public uint bufferSize {
            get => _sftpClient.BufferSize;
            set => _sftpClient.BufferSize = value;
        }

        public LuaTimeSpan operationTimeout {
            get => new LuaTimeSpan(_sftpClient.OperationTimeout);
            set => _sftpClient.OperationTimeout = value.GetTimeSpan();
        }

        public int protocolVersion => _sftpClient.ProtocolVersion;

        public LuaConnectionInfo connectionInfo => new LuaConnectionInfo(_sftpClient.ConnectionInfo);

        public bool isConnected => _sftpClient.IsConnected;

        public LuaTimeSpan keepAliveInterval {
            get => new LuaTimeSpan(_sftpClient.KeepAliveInterval);
            set => _sftpClient.KeepAliveInterval = value.GetTimeSpan();
        }

        #endregion

        #region Sync

        public void downloadFile() => _sftpClient.DownloadFile();
        public void appendAllLines(string path, string[] lines) => _sftpClient.AppendAllLines(path, lines);
        public void appendAllText(string path, string contents) => _sftpClient.AppendAllText(path, contents);
        public LuaStreamWriter appendText(string path) => new LuaStreamWriter(_sftpClient.AppendText(path));
        public void beginDownloadFile() => _sftpClient.BeginDownloadFile();
        public void beginListDirectory() => _sftpClient.BeginListDirectory();
        public void beginSynchronizeDirectories() => _sftpClient.BeginSynchronizeDirectories();
        public void beginUploadFile() => _sftpClient.BeginUploadFile();
        public void changeDirectory(string path) => _sftpClient.ChangeDirectory(path);
        public void changePermissions(string path, short mode) => _sftpClient.ChangePermissions(path, mode);
        public LuaStream create(string path) => new LuaStream(_sftpClient.Create(path));
        public LuaStream create(string path, int buffer) => new LuaStream(_sftpClient.Create(path, buffer));
        public void createDirectory(string path) => _sftpClient.CreateDirectory(path);
        public LuaStreamWriter createText(string path) => new LuaStreamWriter(_sftpClient.CreateText(path));
        public LuaStreamWriter createText(string path, string encoding) => new LuaStreamWriter(_sftpClient.CreateText(path, Encoding.GetEncoding(encoding)));
        public void delete(string path) => _sftpClient.Delete(path);
        public void deleteDirectory(string path) => _sftpClient.DeleteDirectory(path);
        public void deleteFile(string path) => _sftpClient.DeleteFile(path);
        public void endDownloadFile() => _sftpClient.EndDownloadFile();
        public void endListDirectory() => _sftpClient.EndListDirectory();
        public void endSynchronizeDirectories() => _sftpClient.EndSynchronizeDirectories();
        public void endUploadFile() => _sftpClient.EndUploadFile();
        public bool exists(string path) => _sftpClient.Exists(path);
        public void get() => _sftpClient.Get();
        public void getAttributes() => _sftpClient.GetAttributes();
        public void getLastAccessTime() => _sftpClient.GetLastAccessTime();
        public void getLastAccessTimeUtc() => _sftpClient.GetLastAccessTimeUtc();
        public void getLastWriteTime() => _sftpClient.GetLastWriteTime();
        public void getLastWriteTimeUtc() => _sftpClient.GetLastWriteTimeUtc();
        public void getStatus() => _sftpClient.GetStatus();
        public void listDirectory() => _sftpClient.ListDirectory();
        public LuaStream open(string path, FileMode fileMode) => new LuaStream(_sftpClient.Open(path, fileMode));
        public LuaStream openRead(string path) => new LuaStream(_sftpClient.OpenRead(path));
        public LuaStreamReader openText(string path) => new LuaStreamReader(_sftpClient.OpenText(path));
        public LuaStream openWrite(string path) => new LuaStream(_sftpClient.OpenWrite(path));
        public byte[] readAllBytes(string path) => _sftpClient.ReadAllBytes(path);
        public string[] readAllLines(string path) => _sftpClient.ReadAllLines(path);
        public string[] readAllLines(string path, string encoding) => _sftpClient.ReadAllLines(path, Encoding.GetEncoding(encoding));
        public string readAllText(string path) => _sftpClient.ReadAllText(path);
        public string readAllText(string path, string encoding) => _sftpClient.ReadAllText(path, Encoding.GetEncoding(encoding));
        public string[] readLines(string path) => _sftpClient.ReadLines(path).ToArray();
        public void renameFile(string oldPath, string newPath) => _sftpClient.RenameFile(oldPath, newPath);
        public void renameFile(string oldPath, string newPath, bool isPosix) => _sftpClient.RenameFile(oldPath, newPath, isPosix);
        public void setAttributes() => _sftpClient.SetAttributes();
        public void symbolicLink(string path, string linkPath) => _sftpClient.SymbolicLink(path, linkPath);
        public void synchronizeDirectories() => _sftpClient.SynchronizeDirectories();
        public void uploadFile() => _sftpClient.UploadFile();
        public void writeAllBytes(string path, byte[] bytes) => _sftpClient.WriteAllBytes(path, bytes);
        public void writeAllLines(string path, string[] lines) => _sftpClient.WriteAllLines(path, lines);
        public void writeAllText(string path, string contents) => _sftpClient.WriteAllText(path, contents);
        public void connect() => _sftpClient.Connect();
        public void disconnect() => _sftpClient.Disconnect();
        public void dispose() => _sftpClient.Dispose();

        #endregion

    }
}