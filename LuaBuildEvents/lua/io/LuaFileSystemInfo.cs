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
        public FileAttributes attributes {
            get => _fileSystemInfo.Attributes;
            set => _fileSystemInfo.Attributes = value;
        }
        public LuaDateTime creationTime => new LuaDateTime(_fileSystemInfo.CreationTime);
        public LuaDateTime creationTimeUtc => new LuaDateTime(_fileSystemInfo.CreationTimeUtc);
        public LuaDateTime lastAccessTime => new LuaDateTime(_fileSystemInfo.LastAccessTime);
        public LuaDateTime lastAccessTimeUtc => new LuaDateTime(_fileSystemInfo.LastAccessTimeUtc);
        public LuaDateTime lastWriteTime => new LuaDateTime(_fileSystemInfo.LastWriteTime);
        public LuaDateTime lastWriteTimeUtc => new LuaDateTime(_fileSystemInfo.LastWriteTimeUtc);

        public void delete() => _fileSystemInfo.Delete();
        public void refresh() => _fileSystemInfo.Refresh();
    }
}