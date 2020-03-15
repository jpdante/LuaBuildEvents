using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Text;
using FluentFTP;
using FluentFTP.Rules;
using LuaBuildEvents.lua.io;
using LuaBuildEvents.lua.net;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.FTP.fluentftp {
    public class LuaFtpClient {

        [MoonSharpVisible(false)]
        private readonly FtpClient _ftpClient;

        [MoonSharpVisible(false)]
        public FtpClient GetFtpClient() => _ftpClient;

        public LuaFtpClient() {
            _ftpClient = new FtpClient();
        }

        public LuaFtpClient(string host) {
            _ftpClient = new FtpClient(host);
        }

        public LuaFtpClient(string host, NetworkCredential networkCredential) {
            _ftpClient = new FtpClient();
        }

        public LuaFtpClient(string host, int port, string username, string password) {
            _ftpClient = new FtpClient();
        }

        public LuaFtpClient(string host, string username, string password) {
            _ftpClient = new FtpClient();
        }

        public static LuaFtpClient New() => new LuaFtpClient();
        public static LuaFtpClient New(string host) => new LuaFtpClient(host);
        public static LuaFtpClient New(string host, LuaNetworkCredential networkCredential) => new LuaFtpClient(host, networkCredential.GetNetworkCredential());
        public static LuaFtpClient New(string host, int port, string username, string password) => new LuaFtpClient(host, port, username, password);
        public static LuaFtpClient New(string host, string username, string password) => new LuaFtpClient(host, username, password);

        #region Variables

        public bool bulkListing {
            get => _ftpClient.BulkListing;
            set => _ftpClient.BulkListing = value;
        }

        public int bulkListingLength {
            get => _ftpClient.BulkListingLength;
            set => _ftpClient.BulkListingLength = value;
        }

        public List<FtpCapability> capabilities => _ftpClient.Capabilities;

        public bool checkCapabilities {
            get => _ftpClient.CheckCapabilities;
            set => _ftpClient.CheckCapabilities = value;
        }


        // TODO
        // public  bulkListing => _ftpClient.ClientCertificates;

        public int connectTimeout {
            get => _ftpClient.ConnectTimeout;
            set => _ftpClient.ConnectTimeout = value;
        }

        public string connectionType => _ftpClient.ConnectionType;

        public LuaNetworkCredential credentials {
            get => new LuaNetworkCredential(_ftpClient.Credentials);
            set => _ftpClient.Credentials = value.GetNetworkCredential();
        }

        public int dataConnectionConnectTimeout {
            get => _ftpClient.DataConnectionConnectTimeout;
            set => _ftpClient.DataConnectionConnectTimeout = value;
        }

        public bool dataConnectionEncryption {
            get => _ftpClient.DataConnectionEncryption;
            set => _ftpClient.DataConnectionEncryption = value;
        }

        public int dataConnectionReadTimeout {
            get => _ftpClient.DataConnectionReadTimeout;
            set => _ftpClient.DataConnectionReadTimeout = value;
        }

        public FtpDataConnectionType DataConnectionType {
            get => _ftpClient.DataConnectionType;
            set => _ftpClient.DataConnectionType = value;
        }

        public FtpDataType downloadDataType {
            get => _ftpClient.DownloadDataType;
            set => _ftpClient.DownloadDataType = value;
        }

        public uint downloadRateLimit {
            get => _ftpClient.DownloadRateLimit;
            set => _ftpClient.DownloadRateLimit = value;
        }

        public bool enableThreadSafeDataConnections {
            get => _ftpClient.EnableThreadSafeDataConnections;
            set => _ftpClient.EnableThreadSafeDataConnections = value;
        }

        public string encoding {
            get => _ftpClient.Encoding?.ToString();
            set => _ftpClient.Encoding = Encoding.GetEncoding(value);
        }

        public FtpEncryptionMode encryptionMode {
            get => _ftpClient.EncryptionMode;
            set => _ftpClient.EncryptionMode = value;
        }

        public FtpHashAlgorithm hashAlgorithms => _ftpClient.HashAlgorithms;

        public string host {
            get => _ftpClient.Host;
            set => _ftpClient.Host = value;
        }

        public FtpIpVersion internetProtocolVersions {
            get => _ftpClient.InternetProtocolVersions;
            set => _ftpClient.InternetProtocolVersions = value;
        }

        public bool isConnected => _ftpClient.IsConnected;

        public bool isDisposed => _ftpClient.IsDisposed;

        public FtpReply lastReply => _ftpClient.LastReply;

        public int maximumDereferenceCount {
            get => _ftpClient.MaximumDereferenceCount;
            set => _ftpClient.MaximumDereferenceCount = value;
        }

        public int noopInterval {
            get => _ftpClient.NoopInterval;
            set => _ftpClient.NoopInterval = value;
        }

        public int port {
            get => _ftpClient.Port;
            set => _ftpClient.Port = value;
        }

        public int readTimeout {
            get => _ftpClient.ReadTimeout;
            set => _ftpClient.ReadTimeout = value;
        }

        public bool recursiveList {
            get => _ftpClient.RecursiveList;
            set => _ftpClient.RecursiveList = value;
        }

        public int retryAttempts {
            get => _ftpClient.RetryAttempts;
            set => _ftpClient.RetryAttempts = value;
        }

        public bool sendHost {
            get => _ftpClient.SendHost;
            set => _ftpClient.SendHost = value;
        }

        public string sendHostDomain {
            get => _ftpClient.SendHostDomain;
            set => _ftpClient.SendHostDomain = value;
        }

        public FtpOperatingSystem serverOS => _ftpClient.ServerOS;

        public FtpServer serverType => _ftpClient.ServerType;

        public bool socketKeepAlive {
            get => _ftpClient.SocketKeepAlive;
            set => _ftpClient.SocketKeepAlive = value;
        }

        public int socketPollInterval {
            get => _ftpClient.SocketPollInterval;
            set => _ftpClient.SocketPollInterval = value;
        }

        public FtpsBuffering sslBuffering {
            get => _ftpClient.SslBuffering;
            set => _ftpClient.SslBuffering = value;
        }

        public SslProtocols sslProtocols {
            get => _ftpClient.SslProtocols;
            set => _ftpClient.SslProtocols = value;
        }

        public bool staleDataCheck {
            get => _ftpClient.StaleDataCheck;
            set => _ftpClient.StaleDataCheck = value;
        }

        public string systemType => _ftpClient.SystemType;

        public DateTimeStyles timeConversion {
            get => _ftpClient.TimeConversion;
            set => _ftpClient.TimeConversion = value;
        }

        public double timeOffset {
            get => _ftpClient.TimeOffset;
            set => _ftpClient.TimeOffset = value;
        }

        public int transferChunkSize {
            get => _ftpClient.TransferChunkSize;
            set => _ftpClient.TransferChunkSize = value;
        }

        public bool ungracefullDisconnection {
            get => _ftpClient.UngracefullDisconnection;
            set => _ftpClient.UngracefullDisconnection = value;
        }

        public FtpDataType uploadDataType {
            get => _ftpClient.UploadDataType;
            set => _ftpClient.UploadDataType = value;
        }

        public uint uploadRateLimit {
            get => _ftpClient.UploadRateLimit;
            set => _ftpClient.UploadRateLimit = value;
        }

        public bool validateAnyCertificate {
            get => _ftpClient.ValidateAnyCertificate;
            set => _ftpClient.ValidateAnyCertificate = value;
        }

        public bool validateCertificateRevocation {
            get => _ftpClient.ValidateCertificateRevocation;
            set => _ftpClient.ValidateCertificateRevocation = value;
        }
        #endregion

        #region Sync

        public FtpProfile autoConnect() => _ftpClient.AutoConnect();
        public List<FtpProfile> autoDetect() => _ftpClient.AutoDetect();
        public List<FtpProfile> autoDetect(bool firstOnly) => _ftpClient.AutoDetect(firstOnly);
        public void autoDispose() => _ftpClient.AutoDispose();
        public void chmod(string path, FtpPermission owner, FtpPermission group, FtpPermission other) => _ftpClient.Chmod(path, owner, group, other);
        public void chmod(string path, int permissions) => _ftpClient.Chmod(path, permissions);
        public FtpCompareResult compareFile(string localPath, string remotePath) => _ftpClient.CompareFile(localPath, remotePath);
        public FtpCompareResult compareFile(string localPath, string remotePath, FtpCompareOption ftpCompareOption) => _ftpClient.CompareFile(localPath, remotePath, ftpCompareOption);
        public void connect() => _ftpClient.Connect();
        public bool createDirectory(string path) => _ftpClient.CreateDirectory(path);
        public bool createDirectory(string path, bool force) => _ftpClient.CreateDirectory(path, force);
        public void deleteDirectory(string path) => _ftpClient.DeleteDirectory(path);
        public void deleteDirectory(string path, FtpListOption ftpListOption) => _ftpClient.DeleteDirectory(path, ftpListOption);
        public void deleteFile(string path) => _ftpClient.DeleteFile(path);
        public FtpListItem dereferenceLink(FtpListItem item) => _ftpClient.DereferenceLink(item);
        public FtpListItem dereferenceLink(FtpListItem item, int recMax) => _ftpClient.DereferenceLink(item, recMax);
        public void directoryExists(string path) => _ftpClient.DirectoryExists(path);
        public void disableUTF8() => _ftpClient.DisableUTF8();
        public void disconnect() => _ftpClient.Disconnect();
        public void dispose() => _ftpClient.Dispose();
        public bool download(LuaStream stream, string remotePath, DynValue function) {
            if (function == null) {
                return _ftpClient.Download(stream.GetStream(), remotePath);
            }
            return _ftpClient.Download(stream.GetStream(), remotePath, progress: (FtpProgress) => {
                Program.Script.Call(function, FtpProgress);
            });
        }
        public bool download(LuaStream stream, string remotePath, long restartPosition, DynValue function) {
            if (function == null) {
                return _ftpClient.Download(stream.GetStream(), remotePath, restartPosition);
            }
            return _ftpClient.Download(stream.GetStream(), remotePath, restartPosition, (FtpProgress) => {
                Program.Script.Call(function, FtpProgress);
            });
        }
        public byte[] download(string remotePath, long restartPosition, DynValue function) {
            if (function == null) {
                _ftpClient.Download(out byte[] data, remotePath, restartPosition);
                return data;
            }
            _ftpClient.Download(out byte[] data2, remotePath, restartPosition, (FtpProgress) => {
                Program.Script.Call(function, FtpProgress);
            });
            return data2;
        }
        public byte[] download(string remotePath, DynValue function) {
            if (function == null) {
                _ftpClient.Download(out byte[] data, remotePath);
                return data;
            }
            _ftpClient.Download(out byte[] data2, remotePath, progress: (FtpProgress) => {
                Program.Script.Call(function, FtpProgress);
            });
            return data2;
        }
        public List<FtpResult> downloadDirectory(string localFolder, string remoteFolder, DynValue function) {
            if (function == null) {
                return _ftpClient.DownloadDirectory(localFolder, remoteFolder);
            }
            return _ftpClient.DownloadDirectory(localFolder, remoteFolder, progress: (FtpProgress) => {
                Program.Script.Call(function, FtpProgress);
            });
        }
        public List<FtpResult> downloadDirectory(string localFolder, string remoteFolder, FtpFolderSyncMode ftpFolderSyncMode, FtpLocalExists ftpLocalExists, FtpVerify ftpVerify, FtpRule[] rules, DynValue function) {
            if (function == null) {
                return _ftpClient.DownloadDirectory(localFolder, remoteFolder, ftpFolderSyncMode, ftpLocalExists, ftpVerify, rules.ToList());
            }
            return _ftpClient.DownloadDirectory(localFolder, remoteFolder, ftpFolderSyncMode, ftpLocalExists, ftpVerify, rules.ToList(), (FtpProgress) => {
                Program.Script.Call(function, FtpProgress);
            });
        }
        public FtpStatus downloadFile(string localFolder, string remoteFolder, DynValue function) {
            if (function == null) {
                return _ftpClient.DownloadFile(localFolder, remoteFolder);
            }
            return _ftpClient.DownloadFile(localFolder, remoteFolder, progress: (FtpProgress) => {
                Program.Script.Call(function, FtpProgress);
            });
        }
        public FtpStatus downloadFile(string localFolder, string remoteFolder, FtpLocalExists ftpLocalExists, FtpVerify ftpVerify, DynValue function) {
            if (function == null) {
                return _ftpClient.DownloadFile(localFolder, remoteFolder, ftpLocalExists, ftpVerify);
            }
            return _ftpClient.DownloadFile(localFolder, remoteFolder, ftpLocalExists, ftpVerify, (FtpProgress) => {
                Program.Script.Call(function, FtpProgress);
            });
        }
        public int downloadFiles(string localFolder, string[] remotePaths, DynValue function) {
            if (function == null) {
                return _ftpClient.DownloadFiles(localFolder, remotePaths);
            }
            return _ftpClient.DownloadFiles(localFolder, remotePaths, progress: (FtpProgress) => {
                Program.Script.Call(function, FtpProgress);
            });
        }
        public int downloadFiles(string localFolder, string[] remotePaths, FtpLocalExists ftpLocalExists, FtpVerify ftpVerify, FtpError ftpError, DynValue function) {
            if (function == null) {
                return _ftpClient.DownloadFiles(localFolder, remotePaths, ftpLocalExists, ftpVerify, ftpError);
            }
            return _ftpClient.DownloadFiles(localFolder, remotePaths, ftpLocalExists, ftpVerify, ftpError, (FtpProgress) => {
                Program.Script.Call(function, FtpProgress);
            });
        }
        public FtpReply execute(string command) => _ftpClient.Execute(command);
        public bool fileExists(string path) => _ftpClient.FileExists(path);
        public FtpHash getChecksum(string path) => _ftpClient.GetChecksum(path);
        public int getChmod(string path) => _ftpClient.GetChmod(path);
        public FtpListItem getFilePermissions(string path) => _ftpClient.GetFilePermissions(path);
        public long getFileSize(string path) => _ftpClient.GetFileSize(path);
        public FtpHash getHash(string path) => _ftpClient.GetHash(path);
        public FtpHashAlgorithm getHashAlgorithm() => _ftpClient.GetHashAlgorithm();
        public FtpListItem[] getListing() => _ftpClient.GetListing();
        public string getMD5(string path) => _ftpClient.GetMD5(path);
        public DateTime getModifiedTime(string path) => _ftpClient.GetModifiedTime(path);
        public DateTime getModifiedTime(string path, FtpDate ftpDate) => _ftpClient.GetModifiedTime(path, ftpDate);
        public string[] getNameListing() => _ftpClient.GetNameListing();
        public string[] getNameListing(string path) => _ftpClient.GetNameListing(path);
        public FtpListItem getObjectInfo(string path) => _ftpClient.GetObjectInfo(path);
        public FtpListItem getObjectInfo(string path, bool dataModified) => _ftpClient.GetObjectInfo(path, dataModified);
        public FtpReply getReply() => _ftpClient.GetReply();
        public string getWorkingDirectory() => _ftpClient.GetWorkingDirectory();
        public string getXCRC(string path) => _ftpClient.GetXCRC(path);
        public string getXMD5(string path) => _ftpClient.GetXMD5(path);
        public string getXSHA1(string path) => _ftpClient.GetXSHA1(path);
        public string getXSHA256(string path) => _ftpClient.GetXSHA256(path);
        public string getXSHA512(string path) => _ftpClient.GetXSHA512(path);
        public bool hasFeature(FtpCapability capability) => _ftpClient.HasFeature(capability);
        public bool isProxy() => _ftpClient.IsProxy();
        public void logFunc(string function) => _ftpClient.LogFunc(function);
        public void logLine(FtpTraceLevel traceLevel, string message) => _ftpClient.LogLine(traceLevel, message);
        public void logStatus(FtpTraceLevel traceLevel, string message) => _ftpClient.LogStatus(traceLevel, message);
        public bool moveDirectory(string path, string dest) => _ftpClient.MoveDirectory(path, dest);
        public bool moveDirectory(string path, string dest, FtpRemoteExists ftpRemoteExists) => _ftpClient.MoveDirectory(path, dest, ftpRemoteExists);
        public bool moveFile(string path, string dest) => _ftpClient.MoveFile(path, dest);
        public bool moveFile(string path, string dest, FtpRemoteExists ftpRemoteExists) => _ftpClient.MoveFile(path, dest, ftpRemoteExists);
        public bool noop() => _ftpClient.Noop();
        public LuaStream openAppend(string path) => new LuaStream(_ftpClient.OpenAppend(path));
        public LuaStream openAppend(string path, FtpDataType ftpDataType) => new LuaStream(_ftpClient.OpenAppend(path, ftpDataType));
        public LuaStream openAppend(string path, FtpDataType ftpDataType, bool checkIfFileExists) => new LuaStream(_ftpClient.OpenAppend(path, ftpDataType, checkIfFileExists));
        public LuaStream openRead(string path) => new LuaStream(_ftpClient.OpenRead(path));
        public LuaStream openRead(string path, FtpDataType ftpDataType) => new LuaStream(_ftpClient.OpenRead(path, ftpDataType));
        public LuaStream openRead(string path, FtpDataType ftpDataType, bool checkIfFileExists) => new LuaStream(_ftpClient.OpenRead(path, ftpDataType, checkIfFileExists));
        public LuaStream openRead(string path, FtpDataType ftpDataType, long restart) => new LuaStream(_ftpClient.OpenRead(path, ftpDataType, restart));
        public LuaStream openRead(string path, FtpDataType ftpDataType, long restart, bool checkIfFileExists) => new LuaStream(_ftpClient.OpenRead(path, ftpDataType, restart, checkIfFileExists));
        public LuaStream openRead(string path, long restart, bool checkIfFileExists) => new LuaStream(_ftpClient.OpenRead(path, restart, checkIfFileExists));
        public LuaStream openWrite(string path) => new LuaStream(_ftpClient.OpenWrite(path));
        public LuaStream openWrite(string path, FtpDataType ftpDataType) => new LuaStream(_ftpClient.OpenWrite(path, ftpDataType));
        public LuaStream openWrite(string path, FtpDataType ftpDataType, bool checkIfFileExists) => new LuaStream(_ftpClient.OpenWrite(path, ftpDataType, checkIfFileExists));
        public void rename(string path, string dest) => _ftpClient.Rename(path, dest);
        public void setFilePermissions(string path, int permissions) => _ftpClient.SetFilePermissions(path, permissions);
        public void setFilePermissions(string path, FtpPermission owner, FtpPermission group, FtpPermission other) => _ftpClient.SetFilePermissions(path, owner, group, other);
        public void setHashAlgorithm(FtpHashAlgorithm ftpHashAlgorithm) => _ftpClient.SetHashAlgorithm(ftpHashAlgorithm);
        public void setModifiedTime(string path, DateTime date) => _ftpClient.SetModifiedTime(path, date);
        public void setModifiedTime(string path, DateTime date, FtpDate ftpDate) => _ftpClient.SetModifiedTime(path, date, ftpDate);
        public void setWorkingDirectory(string path) => _ftpClient.SetWorkingDirectory(path);
        public List<FtpResult> transferDirectory(string sourceFolder, LuaFtpClient remoteClient, string remoteFolder, DynValue function) {
            if (function == null) {
                return _ftpClient.TransferDirectory(sourceFolder, remoteClient.GetFtpClient(), remoteFolder);
            }
            return _ftpClient.TransferDirectory(sourceFolder, remoteClient.GetFtpClient(), remoteFolder, progress: (FtpProgress) => {
                Program.Script.Call(function, FtpProgress);
            });
        }
        public List<FtpResult> transferDirectory(string sourceFolder, LuaFtpClient remoteClient, string remoteFolder, FtpFolderSyncMode ftpFolderSyncMode, FtpRemoteExists ftpRemoteExists, FtpVerify ftpVerify, FtpRule[] rules, DynValue function) {
            if (function == null) {
                return _ftpClient.TransferDirectory(sourceFolder, remoteClient.GetFtpClient(), remoteFolder, ftpFolderSyncMode, ftpRemoteExists, ftpVerify, rules.ToList());
            }
            return _ftpClient.TransferDirectory(sourceFolder, remoteClient.GetFtpClient(), remoteFolder, ftpFolderSyncMode, ftpRemoteExists, ftpVerify, rules.ToList(), (FtpProgress) => {
                Program.Script.Call(function, FtpProgress);
            });
        }
        public FtpStatus transferFile(string sourceFolder, LuaFtpClient remoteClient, string remotePath, DynValue function) {
            if (function == null) {
                return _ftpClient.TransferFile(sourceFolder, remoteClient.GetFtpClient(), remotePath);
            }
            return _ftpClient.TransferFile(sourceFolder, remoteClient.GetFtpClient(), remotePath, progress: (FtpProgress) => {
                Program.Script.Call(function, FtpProgress);
            });
        }
        public FtpStatus transferFile(string sourceFolder, LuaFtpClient remoteClient, string remotePath, bool createRemoteDir, FtpRemoteExists ftpRemoteExists, FtpVerify ftpVerify, DynValue function) {
            if (function == null) {
                return _ftpClient.TransferFile(sourceFolder, remoteClient.GetFtpClient(), remotePath, createRemoteDir, ftpRemoteExists, ftpVerify);
            }
            return _ftpClient.TransferFile(sourceFolder, remoteClient.GetFtpClient(), remotePath, createRemoteDir, ftpRemoteExists, ftpVerify, (FtpProgress) => {
                Program.Script.Call(function, FtpProgress);
            });
        }
        public bool transferFileFXPInternal(string sourceFolder, LuaFtpClient remoteClient, string remotePath, bool createRemoteDir, FtpRemoteExists ftpRemoteExists, DynValue function) {
            if (function == null) {
                return false;
            }
            return _ftpClient.TransferFileFXPInternal(sourceFolder, remoteClient.GetFtpClient(), remotePath, createRemoteDir, ftpRemoteExists, (FtpProgress) => {
                Program.Script.Call(function, FtpProgress);
            }, null);
        }
        public FtpStatus upload(LuaStream stream, string remotePath, DynValue function) {
            if (function == null) {
                return _ftpClient.Upload(stream.GetStream(), remotePath);
            }
            return _ftpClient.Upload(stream.GetStream(), remotePath, progress: (FtpProgress) => {
                Program.Script.Call(function, FtpProgress);
            });
        }
        public FtpStatus upload(LuaStream stream, string remotePath, FtpRemoteExists ftpRemoteExists, bool createRemoteDir, DynValue function) {
            if (function == null) {
                return _ftpClient.Upload(stream.GetStream(), remotePath, ftpRemoteExists, createRemoteDir);
            }
            return _ftpClient.Upload(stream.GetStream(), remotePath, ftpRemoteExists, createRemoteDir, (FtpProgress) => {
                Program.Script.Call(function, FtpProgress);
            });
        }
        public FtpStatus upload(byte[] data, string remotePath, DynValue function) {
            if (function == null) {
                return _ftpClient.Upload(data, remotePath);
            }
            return _ftpClient.Upload(data, remotePath, progress: (FtpProgress) => {
                Program.Script.Call(function, FtpProgress);
            });
        }
        public FtpStatus upload(byte[] data, string remotePath, FtpRemoteExists ftpRemoteExists, bool createRemoteDir, DynValue function) {
            if (function == null) {
                return _ftpClient.Upload(data, remotePath, ftpRemoteExists, createRemoteDir);
            }
            return _ftpClient.Upload(data, remotePath, ftpRemoteExists, createRemoteDir, (FtpProgress) => {
                Program.Script.Call(function, FtpProgress);
            });
        }
        public List<FtpResult> uploadDirectory(string localFolder, string remoteFolder, DynValue function) {
            if (function == null) {
                return _ftpClient.UploadDirectory(localFolder, remoteFolder);
            }
            return _ftpClient.UploadDirectory(localFolder, remoteFolder, progress: (FtpProgress) => {
                Program.Script.Call(function, FtpProgress);
            });
        }
        public List<FtpResult> uploadDirectory(string localFolder, string remoteFolder, FtpFolderSyncMode ftpFolderSyncMode, FtpRemoteExists ftpRemoteExists, FtpVerify ftpVerify, FtpRule[] rules, DynValue function) {
            if (function == null) {
                return _ftpClient.UploadDirectory(localFolder, remoteFolder, ftpFolderSyncMode, ftpRemoteExists, ftpVerify, rules.ToList());
            }
            return _ftpClient.UploadDirectory(localFolder, remoteFolder, ftpFolderSyncMode, ftpRemoteExists, ftpVerify, rules.ToList(), (FtpProgress) => {
                Program.Script.Call(function, FtpProgress);
            });
        }
        public FtpStatus uploadFile(string localPath, string remotePath, DynValue function) {
            if (function == null) {
                return _ftpClient.UploadFile(localPath, remotePath);
            }
            return _ftpClient.UploadFile(localPath, remotePath, progress: (FtpProgress) => {
                Program.Script.Call(function, FtpProgress);
            });
        }
        public FtpStatus uploadFile(string localPath, string remotePath, FtpRemoteExists ftpRemoteExists, bool createRemoteDir, FtpVerify ftpVerify, DynValue function) {
            if (function == null) {
                return _ftpClient.UploadFile(localPath, remotePath, ftpRemoteExists, createRemoteDir, ftpVerify);
            }
            return _ftpClient.UploadFile(localPath, remotePath, ftpRemoteExists, createRemoteDir, ftpVerify,(FtpProgress) => {
                Program.Script.Call(function, FtpProgress);
            });
        }
        public int uploadFiles(string[] localPaths, string remoteDir, DynValue function) {
            if (function == null) {
                return _ftpClient.UploadFiles(localPaths, remoteDir);
            }
            return _ftpClient.UploadFiles(localPaths, remoteDir, progress: (FtpProgress) => {
                Program.Script.Call(function, FtpProgress);
            });
        }
        public int uploadFiles(string[] localPaths, string remoteDir, FtpRemoteExists ftpRemoteExists, bool createRemoteDir, FtpVerify ftpVerify, FtpError ftpError, DynValue function) {
            if (function == null) {
                return _ftpClient.UploadFiles(localPaths, remoteDir, ftpRemoteExists, createRemoteDir, ftpVerify, ftpError);
            }
            return _ftpClient.UploadFiles(localPaths, remoteDir, ftpRemoteExists, createRemoteDir, ftpVerify, ftpError,(FtpProgress) => {
                Program.Script.Call(function, FtpProgress);
            });
        }

        #endregion
    }
}
