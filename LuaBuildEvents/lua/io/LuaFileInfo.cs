using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
        public string attributes {
            get => _fileInfo.Attributes.ToString();
            set {
                if (!Enum.TryParse(value, out FileAttributes result)) {
                    _fileInfo.Attributes = result;
                }
                throw new ScriptRuntimeException("Failed to parse FileAttributes.");
            }
        }
        public DateTime creationTime => _fileInfo.CreationTime;
        public DateTime creationTimeUtc => _fileInfo.CreationTimeUtc;
        public DateTime lastAccessTime => _fileInfo.LastAccessTime;
        public DateTime lastAccessTimeUtc => _fileInfo.LastAccessTimeUtc;
        public DateTime lastWriteTime => _fileInfo.LastWriteTime;
        public DateTime lastWriteTimeUtc => _fileInfo.LastWriteTimeUtc;

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
        public LuaFileStream open(string mode) {
            if (Enum.TryParse(mode, out FileMode fileMode)) {
                return new LuaFileStream(_fileInfo.Open(fileMode));
            } else {
                throw new ScriptRuntimeException("Failed to parse FileStream arguments.");
            }
        }
        public LuaFileStream open(string mode, string access) {
            if (Enum.TryParse(mode, out FileMode fileMode) &&
                Enum.TryParse(access, out FileAccess fileAccess)) {
                return new LuaFileStream(_fileInfo.Open(fileMode, fileAccess));
            } else {
                throw new ScriptRuntimeException("Failed to parse FileStream arguments.");
            }
        }
        public LuaFileStream open(string mode, string access, string share) {
            if (Enum.TryParse(mode, out FileMode fileMode) &&
                Enum.TryParse(access, out FileAccess fileAccess) &&
                Enum.TryParse(share, out FileShare fileShare)) {
                return new LuaFileStream(_fileInfo.Open(fileMode, fileAccess, fileShare));
            } else {
                throw new ScriptRuntimeException("Failed to parse FileStream arguments.");
            }
        }
    }
}
