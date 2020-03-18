using System.Collections.Generic;
using LuaBuildEvents.lua.system;
using MoonSharp.Interpreter.Interop;
using Renci.SshNet.Sftp;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.SSH {
    public class LuaSftpFileAttributes {

        [MoonSharpVisible(false)]
        private readonly SftpFileAttributes _sftpFileAttributes;

        [MoonSharpVisible(false)]
        public SftpFileAttributes GetSftpFileAttributes() => _sftpFileAttributes;

        public LuaSftpFileAttributes(SftpFileAttributes sftpFileAttributes) {
            _sftpFileAttributes = sftpFileAttributes;
        }

        #region Variables

        public IDictionary<string, string> extensions => _sftpFileAttributes.Extensions;
        public bool isDirectory => _sftpFileAttributes.IsDirectory;
        public bool isSocket => _sftpFileAttributes.IsSocket;
        public bool groupCanRead {
            get => _sftpFileAttributes.GroupCanRead;
            set => _sftpFileAttributes.GroupCanRead = value;
        }
        public bool groupCanExecute {
            get => _sftpFileAttributes.GroupCanExecute;
            set => _sftpFileAttributes.GroupCanExecute = value;
        }
        public bool groupCanWrite {
            get => _sftpFileAttributes.GroupCanWrite;
            set => _sftpFileAttributes.GroupCanWrite = value;
        }
        public bool isBlockDevice => _sftpFileAttributes.IsBlockDevice;
        public bool isCharacterDevice => _sftpFileAttributes.IsCharacterDevice;
        public bool isNamedPipe => _sftpFileAttributes.IsNamedPipe;
        public bool isRegularFile => _sftpFileAttributes.IsRegularFile;
        public bool isSymbolicLink => _sftpFileAttributes.IsSymbolicLink;
        public bool othersCanExecute {
            get => _sftpFileAttributes.OthersCanExecute;
            set => _sftpFileAttributes.OthersCanExecute = value;
        }
        public bool othersCanRead {
            get => _sftpFileAttributes.OthersCanRead;
            set => _sftpFileAttributes.OthersCanRead = value;
        }
        public bool othersCanWrite {
            get => _sftpFileAttributes.OthersCanWrite;
            set => _sftpFileAttributes.OthersCanWrite = value;
        }
        public bool ownerCanExecute {
            get => _sftpFileAttributes.OwnerCanExecute;
            set => _sftpFileAttributes.OwnerCanExecute = value;
        }
        public bool ownerCanRead {
            get => _sftpFileAttributes.OwnerCanRead;
            set => _sftpFileAttributes.OwnerCanRead = value;
        }
        public bool ownerCanWrite {
            get => _sftpFileAttributes.OwnerCanWrite;
            set => _sftpFileAttributes.OwnerCanWrite = value;
        }
        public int groupId => _sftpFileAttributes.GroupId;
        public LuaDateTime lastAccessTime {
            get => new LuaDateTime(_sftpFileAttributes.LastAccessTime);
            set => _sftpFileAttributes.LastAccessTime = value.GetDateTime();
        }
        public LuaDateTime lastWriteTime {
            get => new LuaDateTime(_sftpFileAttributes.LastWriteTime);
            set => _sftpFileAttributes.LastWriteTime = value.GetDateTime();
        }
        public long size => _sftpFileAttributes.Size;
        public int userId {
            get => _sftpFileAttributes.UserId;
            set => _sftpFileAttributes.UserId = value;
        }

        #endregion

        #region Sync

        public void setPermissions(short mode) => _sftpFileAttributes.SetPermissions(mode);
        public byte[] getBytes() => _sftpFileAttributes.GetBytes();
        public override string ToString() => _sftpFileAttributes.ToString();

        #endregion

    }
}