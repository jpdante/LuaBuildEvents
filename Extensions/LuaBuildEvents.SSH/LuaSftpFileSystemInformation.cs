using MoonSharp.Interpreter.Interop;
using Renci.SshNet.Sftp;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.SSH {
    public class LuaSftpFileSystemInformation {

        [MoonSharpVisible(false)]
        private readonly SftpFileSytemInformation _sftpFileSystemInformation;

        [MoonSharpVisible(false)]
        public SftpFileSytemInformation GetSftpFileSystemInformation() => _sftpFileSystemInformation;

        public LuaSftpFileSystemInformation(SftpFileSytemInformation sftpFileSystemInformation) {
            _sftpFileSystemInformation = sftpFileSystemInformation;
        }

        #region Variables

        public ulong availableBlocks => _sftpFileSystemInformation.AvailableBlocks;
        public ulong availableNodes => _sftpFileSystemInformation.AvailableNodes;
        public ulong blockSize => _sftpFileSystemInformation.BlockSize;
        public ulong fileSystemBlockSize => _sftpFileSystemInformation.FileSystemBlockSize;
        public ulong freeBlocks => _sftpFileSystemInformation.FreeBlocks;
        public ulong freeNodes => _sftpFileSystemInformation.FreeNodes;
        public bool isReadOnly => _sftpFileSystemInformation.IsReadOnly;
        public ulong maxNameLenght => _sftpFileSystemInformation.MaxNameLenght;
        public ulong sid => _sftpFileSystemInformation.Sid;
        public bool supportsSetUid => _sftpFileSystemInformation.SupportsSetUid;
        public ulong totalBlocks => _sftpFileSystemInformation.TotalBlocks;
        public ulong totalNodes => _sftpFileSystemInformation.TotalNodes;

        #endregion
    }
}