using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LuaBuildEvents.lua.system;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.io {
    public class LuaFileInfo {
        [MoonSharpVisible(false)] 
        private readonly FileInfo _fileInfo;

        public LuaFileInfo(string fileName) {
            _fileInfo = new FileInfo(fileName);
        }

        public LuaFileInfo(FileInfo fileInfo) {
            _fileInfo = fileInfo;
        }

        public static LuaFileInfo New(string fileName) => new LuaFileInfo(fileName);

        public string directoryName => _fileInfo.DirectoryName;
        public string name => _fileInfo.Name;
        public string fullName => _fileInfo.FullName;
        public string extension => _fileInfo.Extension;
        public LuaDirectoryInfo directory => new LuaDirectoryInfo(_fileInfo.Directory);
        public bool exists => _fileInfo.Exists;
        public bool isReadOnly => _fileInfo.IsReadOnly;
        public long length => _fileInfo.Length;
        public FileAttributes attributes {
            get => _fileInfo.Attributes;
            set => _fileInfo.Attributes = value;
        }
        public LuaDateTime creationTime => new LuaDateTime(_fileInfo.CreationTime);
        public LuaDateTime creationTimeUtc => new LuaDateTime(_fileInfo.CreationTimeUtc);
        public LuaDateTime lastAccessTime => new LuaDateTime(_fileInfo.LastAccessTime);
        public LuaDateTime lastAccessTimeUtc => new LuaDateTime(_fileInfo.LastAccessTimeUtc);
        public LuaDateTime lastWriteTime => new LuaDateTime(_fileInfo.LastWriteTime);
        public LuaDateTime lastWriteTimeUtc => new LuaDateTime(_fileInfo.LastWriteTimeUtc);

        public LuaStreamWriter appendText() => new LuaStreamWriter(_fileInfo.AppendText());
        public LuaFileInfo copyTo(string destFileName) => new LuaFileInfo(_fileInfo.CopyTo(destFileName));
        public LuaFileInfo copyTo(string destFileName, bool overwrite) => new LuaFileInfo(_fileInfo.CopyTo(destFileName, overwrite));
        public LuaFileStream create() => new LuaFileStream(_fileInfo.Create());
        public LuaStreamWriter createText() => new LuaStreamWriter(_fileInfo.CreateText());
        public void decrypt() => _fileInfo.Decrypt();
        public void delete() => _fileInfo.Delete();
        public void encrypt() => _fileInfo.Encrypt();
        public void moveTo(string destFileName) => _fileInfo.MoveTo(destFileName);
        public void moveTo(string destFileName, bool overwrite) => _fileInfo.MoveTo(destFileName, overwrite);
        public LuaFileStream openRead() => new LuaFileStream(_fileInfo.OpenRead());
        public LuaStreamReader openText() => new LuaStreamReader(_fileInfo.OpenText());
        public LuaStreamWriter openWrite() => new LuaStreamWriter(_fileInfo.OpenWrite());
        public LuaFileInfo replace(string destinationFileName, string destinationBackupFileName) => new LuaFileInfo(_fileInfo.Replace(destinationFileName, destinationBackupFileName));
        public LuaFileInfo replace(string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors) => new LuaFileInfo(_fileInfo.Replace(destinationFileName, destinationBackupFileName, ignoreMetadataErrors));
        public LuaFileStream open(FileMode fileMode) => new LuaFileStream(_fileInfo.Open(fileMode));
        public LuaFileStream open(FileMode fileMode, FileAccess fileAccess) => new LuaFileStream(_fileInfo.Open(fileMode, fileAccess));
        public LuaFileStream open(FileMode fileMode, FileAccess fileAccess, FileShare fileShare) => new LuaFileStream(_fileInfo.Open(fileMode, fileAccess, fileShare));
    }
}
