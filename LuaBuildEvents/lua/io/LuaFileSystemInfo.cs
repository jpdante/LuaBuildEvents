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
    public class LuaFileSystemInfo {
        [MoonSharpVisible(false)] 
        private readonly FileSystemInfo _fileSystemInfo;

        public LuaFileSystemInfo(FileSystemInfo fileSystemInfo) {
            _fileSystemInfo = fileSystemInfo;
        }

        public string name => _fileSystemInfo.Name;
        public string fullName => _fileSystemInfo.FullName;
        public string extension => _fileSystemInfo.Extension;
        public bool exists => _fileSystemInfo.Exists;
        public string attributes {
            get => _fileSystemInfo.Attributes.ToString();
            set {
                if (!Enum.TryParse(value, out FileAttributes result)) {
                    _fileSystemInfo.Attributes = result;
                }
                throw new ScriptRuntimeException("Failed to parse FileAttributes.");
            }
        }
        public DateTime creationTime => _fileSystemInfo.CreationTime;
        public DateTime creationTimeUtc => _fileSystemInfo.CreationTimeUtc;
        public DateTime lastAccessTime => _fileSystemInfo.LastAccessTime;
        public DateTime lastAccessTimeUtc => _fileSystemInfo.LastAccessTimeUtc;
        public DateTime lastWriteTime => _fileSystemInfo.LastWriteTime;
        public DateTime lastWriteTimeUtc => _fileSystemInfo.LastWriteTimeUtc;

        public void delete() => _fileSystemInfo.Delete();
        public void refresh() => _fileSystemInfo.Refresh();
    }
}