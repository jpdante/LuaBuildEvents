using System;
using System.IO;
using System.Linq;
using System.Text;
using LuaBuildEvents.lua.io;
using LuaBuildEvents.lua.system;
using MoonSharp.Interpreter;
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

        #region Async

        public LuaIAsyncResult beginDownloadFile(string path, LuaStream luaStream) => new LuaIAsyncResult(_sftpClient.BeginDownloadFile(path, luaStream.GetStream()));
        public LuaIAsyncResult beginDownloadFile(string path, LuaStream luaStream, DynValue asyncCallBack) => new LuaIAsyncResult(_sftpClient.BeginDownloadFile(path, luaStream.GetStream(), ar => {
            Program.Script.Call(asyncCallBack, new LuaIAsyncResult(ar));
        }));
        public LuaIAsyncResult beginDownloadFile(string path, LuaStream luaStream, DynValue asyncCallBack, DynValue state, DynValue downloadCallback) {
            if (downloadCallback == null) {
                return new LuaIAsyncResult(_sftpClient.BeginDownloadFile(
                    path,
                    luaStream.GetStream(),
                    ar => { Program.Script.Call(asyncCallBack, new LuaIAsyncResult(ar)); },
                    state
                ));
            }
            return new LuaIAsyncResult(_sftpClient.BeginDownloadFile(
                path,
                luaStream.GetStream(),
                ar => { Program.Script.Call(asyncCallBack, new LuaIAsyncResult(ar)); },
                state,
                obj => { Program.Script.Call(downloadCallback, obj); }
            ));
        }
        public LuaIAsyncResult beginListDirectory(string path, DynValue asyncCallBack, DynValue state, DynValue listCallback) {
            if (listCallback == null) {
                return new LuaIAsyncResult(_sftpClient.BeginListDirectory(
                    path, ar => { Program.Script.Call(asyncCallBack, new LuaIAsyncResult(ar)); },
                    state
                ));
            }
            return new LuaIAsyncResult(_sftpClient.BeginListDirectory(
                path, ar => { Program.Script.Call(asyncCallBack, new LuaIAsyncResult(ar)); },
                state,
                i => { Program.Script.Call(listCallback, i); }
            ));
        }
        public LuaIAsyncResult beginSynchronizeDirectories(string sourcePath, string destinationPath, string searchPattern, DynValue asyncCallBack, DynValue state) => new LuaIAsyncResult(_sftpClient.BeginSynchronizeDirectories(
                sourcePath,
                destinationPath,
                searchPattern,
                ar => { Program.Script.Call(asyncCallBack, new LuaIAsyncResult(ar)); },
                state
        ));
        public LuaIAsyncResult beginUploadFile(LuaStream luaStream, string path) => new LuaIAsyncResult(_sftpClient.BeginUploadFile(luaStream.GetStream(), path));
        public LuaIAsyncResult beginUploadFile(LuaStream luaStream, string path, DynValue asyncCallBack) => new LuaIAsyncResult(_sftpClient.BeginUploadFile(
            luaStream.GetStream(),
            path, 
            ar => { Program.Script.Call(asyncCallBack, new LuaIAsyncResult(ar)); }
        ));
        public LuaIAsyncResult beginUploadFile(LuaStream luaStream, string path, DynValue asyncCallBack, DynValue state, DynValue uploadCallback) {
            if (uploadCallback == null) {
                return new LuaIAsyncResult(_sftpClient.BeginUploadFile(
                    luaStream.GetStream(),
                    path,
                    ar => {
                        Program.Script.Call(asyncCallBack, new LuaIAsyncResult(ar));
                    },
                    state
                ));
            }
            return new LuaIAsyncResult(_sftpClient.BeginUploadFile(
                luaStream.GetStream(),
                path,
                ar => { Program.Script.Call(asyncCallBack, new LuaIAsyncResult(ar)); },
                state,
                obj => { Program.Script.Call(uploadCallback, obj); }
            ));
        }
        public LuaIAsyncResult beginUploadFile(LuaStream luaStream, string path, bool canOverride, DynValue asyncCallBack, DynValue state, DynValue uploadCallback) {
            if (uploadCallback == null) {
                return new LuaIAsyncResult(_sftpClient.BeginUploadFile(
                    luaStream.GetStream(),
                    path,
                    canOverride,
                    ar => {
                        Program.Script.Call(asyncCallBack, new LuaIAsyncResult(ar));
                    },
                    state
                ));
            }
            return new LuaIAsyncResult(_sftpClient.BeginUploadFile(
                luaStream.GetStream(),
                path,
                canOverride,
                ar => { Program.Script.Call(asyncCallBack, new LuaIAsyncResult(ar)); },
                state,
                obj => { Program.Script.Call(uploadCallback, obj); }
            ));
        }

        public void endDownloadFile(LuaIAsyncResult luaIAsyncResult) => _sftpClient.EndDownloadFile(luaIAsyncResult.GetIAsyncResult());
        public void endListDirectory(LuaIAsyncResult luaIAsyncResult) => _sftpClient.EndListDirectory(luaIAsyncResult.GetIAsyncResult());
        public void endSynchronizeDirectories(LuaIAsyncResult luaIAsyncResult) => _sftpClient.EndSynchronizeDirectories(luaIAsyncResult.GetIAsyncResult());
        public void endUploadFile(LuaIAsyncResult luaIAsyncResult) => _sftpClient.EndUploadFile(luaIAsyncResult.GetIAsyncResult());

        #endregion

        #region Sync

        public void downloadFile(string path, LuaStream luaStream, DynValue downloadCallback) {
            if (downloadCallback == null) {
                _sftpClient.DownloadFile(path, luaStream.GetStream());
            }
            _sftpClient.DownloadFile(path, luaStream.GetStream(), obj => { Program.Script.Call(downloadCallback, obj); });
        }
        public void appendAllLines(string path, string[] lines) => _sftpClient.AppendAllLines(path, lines);
        public void appendAllLines(string path, string[] lines, string encoding) => _sftpClient.AppendAllLines(path, lines, Encoding.GetEncoding(encoding));
        public void appendAllText(string path, string contents) => _sftpClient.AppendAllText(path, contents);
        public void appendAllText(string path, string contents, string encoding) => _sftpClient.AppendAllText(path, contents, Encoding.GetEncoding(encoding));
        public LuaStreamWriter appendText(string path) => new LuaStreamWriter(_sftpClient.AppendText(path));
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
        public bool exists(string path) => _sftpClient.Exists(path);
        public LuaSftpFile get(string path) => new LuaSftpFile(_sftpClient.Get(path));
        public LuaSftpFileAttributes getAttributes(string path) => new LuaSftpFileAttributes(_sftpClient.GetAttributes(path));
        public LuaDateTime getLastAccessTime(string path) => new LuaDateTime(_sftpClient.GetLastAccessTime(path));
        public LuaDateTime getLastAccessTimeUtc(string path) => new LuaDateTime(_sftpClient.GetLastAccessTimeUtc(path));
        public LuaDateTime getLastWriteTime(string path) => new LuaDateTime(_sftpClient.GetLastWriteTime(path));
        public LuaDateTime getLastWriteTimeUtc(string path) => new LuaDateTime(_sftpClient.GetLastWriteTimeUtc(path));
        public LuaSftpFileSystemInformation getStatus(string path) => new LuaSftpFileSystemInformation(_sftpClient.GetStatus(path));
        public LuaSftpFile[] listDirectory(string path, DynValue listCallback) =>
            listCallback == null ? _sftpClient.ListDirectory(path).Select(sftpFile => new LuaSftpFile(sftpFile)).ToArray() : _sftpClient.ListDirectory(path, obj => { Program.Script.Call(listCallback, obj); }).Select(sftpFile => new LuaSftpFile(sftpFile)).ToArray();
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
        public void setAttributes(string path, LuaSftpFileAttributes luaSftpFileAttributes) => _sftpClient.SetAttributes(path, luaSftpFileAttributes.GetSftpFileAttributes());
        public void symbolicLink(string path, string linkPath) => _sftpClient.SymbolicLink(path, linkPath);
        public LuaFileInfo[] synchronizeDirectories(string sourcePath, string destinationPath, string searchPattern) => 
            _sftpClient.SynchronizeDirectories(sourcePath, destinationPath, searchPattern).Select(fileInfo => new LuaFileInfo(fileInfo)).ToArray();
        public void uploadFile(LuaStream luaStream, string path, DynValue uploadCallback) {
            if (uploadCallback == null) {
                _sftpClient.UploadFile(luaStream.GetStream(), path);
            }
            _sftpClient.UploadFile(luaStream.GetStream(), path, obj => { Program.Script.Call(uploadCallback, obj); });
        }
        public void uploadFile(LuaStream luaStream, string path, bool canOverride, DynValue uploadCallback) {
            if (uploadCallback == null) {
                _sftpClient.UploadFile(luaStream.GetStream(), path, canOverride);
            }
            _sftpClient.UploadFile(luaStream.GetStream(), path, canOverride, obj => { Program.Script.Call(uploadCallback, obj); });
        }
        public void writeAllBytes(string path, byte[] bytes) => _sftpClient.WriteAllBytes(path, bytes);
        public void writeAllLines(string path, string[] lines) => _sftpClient.WriteAllLines(path, lines);
        public void writeAllText(string path, string contents) => _sftpClient.WriteAllText(path, contents);
        public void connect() => _sftpClient.Connect();
        public void disconnect() => _sftpClient.Disconnect();
        public void dispose() => _sftpClient.Dispose();

        #endregion

    }
}