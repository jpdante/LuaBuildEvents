using LuaBuildEvents.lua.system;
using MoonSharp.Interpreter.Interop;
using Renci.SshNet.Sftp;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.SSH {
    public class LuaSftpFile {

        [MoonSharpVisible(false)]
        private readonly SftpFile _sftpFile;

        [MoonSharpVisible(false)]
        public SftpFile GetSftpFile() => _sftpFile;

        public LuaSftpFile(SftpFile sftpFile) {
            _sftpFile = sftpFile;
        }

        #region Variables

        public bool isDirectory => _sftpFile.IsDirectory;
        public bool isSocket => _sftpFile.IsSocket;
        public bool groupCanRead {
            get => _sftpFile.GroupCanRead;
            set => _sftpFile.GroupCanRead = value;
        }
        public bool groupCanExecute {
            get => _sftpFile.GroupCanExecute;
            set => _sftpFile.GroupCanExecute = value;
        }
        public bool groupCanWrite {
            get => _sftpFile.GroupCanWrite;
            set => _sftpFile.GroupCanWrite = value;
        }
        public bool isBlockDevice => _sftpFile.IsBlockDevice;
        public bool isCharacterDevice => _sftpFile.IsCharacterDevice;
        public bool isNamedPipe => _sftpFile.IsNamedPipe;
        public bool isRegularFile => _sftpFile.IsRegularFile;
        public bool isSymbolicLink => _sftpFile.IsSymbolicLink;
        public bool othersCanExecute {
            get => _sftpFile.OthersCanExecute;
            set => _sftpFile.OthersCanExecute = value;
        }
        public bool othersCanRead {
            get => _sftpFile.OthersCanRead;
            set => _sftpFile.OthersCanRead = value;
        }
        public bool othersCanWrite {
            get => _sftpFile.OthersCanWrite;
            set => _sftpFile.OthersCanWrite = value;
        }
        public bool ownerCanExecute {
            get => _sftpFile.OwnerCanExecute;
            set => _sftpFile.OwnerCanExecute = value;
        }
        public bool ownerCanRead {
            get => _sftpFile.OwnerCanRead;
            set => _sftpFile.OwnerCanRead = value;
        }
        public bool ownerCanWrite {
            get => _sftpFile.OwnerCanWrite;
            set => _sftpFile.OwnerCanWrite = value;
        }
        public string fullName => _sftpFile.FullName;
        public LuaSftpFileAttributes attributes => new LuaSftpFileAttributes(_sftpFile.Attributes);
        public int groupId {
            get => _sftpFile.GroupId;
            set => _sftpFile.GroupId = value;
        }
        public LuaDateTime lastAccessTime {
            get => new LuaDateTime(_sftpFile.LastAccessTime);
            set => _sftpFile.LastAccessTime = value.GetDateTime();
        }
        public LuaDateTime lastAccessTimeUtc {
            get => new LuaDateTime(_sftpFile.LastAccessTimeUtc);
            set => _sftpFile.LastAccessTimeUtc = value.GetDateTime();
        }
        public LuaDateTime lastWriteTime {
            get => new LuaDateTime(_sftpFile.LastWriteTime);
            set => _sftpFile.LastWriteTime = value.GetDateTime();
        }
        public LuaDateTime lastWriteTimeUtc {
            get => new LuaDateTime(_sftpFile.LastWriteTimeUtc);
            set => _sftpFile.LastWriteTimeUtc = value.GetDateTime();
        }
        public long length => _sftpFile.Length;
        public string name => _sftpFile.Name;
        public int userId {
            get => _sftpFile.UserId;
            set => _sftpFile.UserId = value;
        }

        #endregion

        #region Sync

        public void delete() => _sftpFile.Delete();
        public void moveTo(string destFileName) => _sftpFile.MoveTo(destFileName);
        public void setPermissions(short mode) => _sftpFile.SetPermissions(mode);
        public void updateStatus() => _sftpFile.UpdateStatus();
        public override string ToString() => _sftpFile.ToString();

        #endregion

    }
}
