using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LuaBuildEvents.lua.system;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.io {
    public class LuaDirectoryInfo {
        [MoonSharpVisible(false)]
        private readonly DirectoryInfo _directoryInfo;

        public LuaDirectoryInfo(string path) {
            _directoryInfo = new DirectoryInfo(path);
        }

        public LuaDirectoryInfo(DirectoryInfo directoryInfo) {
            _directoryInfo = directoryInfo;
        }

        public static LuaDirectoryInfo New(string path) => new LuaDirectoryInfo(path);

        public LuaDirectoryInfo parent => new LuaDirectoryInfo(_directoryInfo.Parent);
        public string name => _directoryInfo.Name;
        public string fullName => _directoryInfo.FullName;
        public string extension => _directoryInfo.Extension;
        public LuaDirectoryInfo root => new LuaDirectoryInfo(_directoryInfo.Root);
        public bool exists => _directoryInfo.Exists;
        public FileAttributes attributes {
            get => _directoryInfo.Attributes;
            set => _directoryInfo.Attributes = value;
        }
        public LuaDateTime creationTime => new LuaDateTime(_directoryInfo.CreationTime);
        public LuaDateTime creationTimeUtc => new LuaDateTime(_directoryInfo.CreationTimeUtc);
        public LuaDateTime lastAccessTime => new LuaDateTime(_directoryInfo.LastAccessTime);
        public LuaDateTime lastAccessTimeUtc => new LuaDateTime(_directoryInfo.LastAccessTimeUtc);
        public LuaDateTime lastWriteTime => new LuaDateTime(_directoryInfo.LastWriteTime);
        public LuaDateTime lastWriteTimeUtc => new LuaDateTime(_directoryInfo.LastWriteTimeUtc);

        public void create() => _directoryInfo.Create();
        public LuaDirectoryInfo createSubdirectory(string path) => new LuaDirectoryInfo(_directoryInfo.CreateSubdirectory(path));
        public void delete() => _directoryInfo.Delete();
        public void moveTo(string destFileName) => _directoryInfo.MoveTo(destFileName);

        public List<LuaDirectoryInfo> enumerateDirectories() => _directoryInfo.EnumerateDirectories().Select(directoryInfo => new LuaDirectoryInfo(directoryInfo)).ToList();
        public List<LuaDirectoryInfo> enumerateDirectories(string searchPattern) => _directoryInfo.EnumerateDirectories(searchPattern).Select(directoryInfo => new LuaDirectoryInfo(directoryInfo)).ToList();
        public List<LuaDirectoryInfo> enumerateDirectories(string searchPattern, SearchOption searchOption) => _directoryInfo.EnumerateDirectories(searchPattern, searchOption).Select(directoryInfo => new LuaDirectoryInfo(directoryInfo)).ToList();

        public List<LuaFileSystemInfo> enumerateFileSystemInfos() => _directoryInfo.EnumerateFileSystemInfos().Select(fileSystemInfo => new LuaFileSystemInfo(fileSystemInfo)).ToList();
        public List<LuaFileSystemInfo> enumerateFileSystemInfos(string searchPattern) => _directoryInfo.EnumerateFileSystemInfos(searchPattern).Select(fileSystemInfo => new LuaFileSystemInfo(fileSystemInfo)).ToList();
        public List<LuaFileSystemInfo> enumerateFileSystemInfos(string searchPattern, SearchOption searchOption) => _directoryInfo.EnumerateFileSystemInfos(searchPattern, searchOption).Select(fileSystemInfo => new LuaFileSystemInfo(fileSystemInfo)).ToList();

        public List<LuaFileInfo> enumerateFiles() => _directoryInfo.EnumerateFiles().Select(fileInfo => new LuaFileInfo(fileInfo)).ToList();
        public List<LuaFileInfo> enumerateFiles(string searchPattern) => _directoryInfo.EnumerateFiles(searchPattern).Select(fileInfo => new LuaFileInfo(fileInfo)).ToList();
        public List<LuaFileInfo> enumerateFiles(string searchPattern, SearchOption searchOption) => _directoryInfo.EnumerateFiles(searchPattern, searchOption).Select(fileInfo => new LuaFileInfo(fileInfo)).ToList();

        public List<LuaDirectoryInfo> getDirectories() => _directoryInfo.GetDirectories().Select(directoryInfo => new LuaDirectoryInfo(directoryInfo)).ToList();
        public List<LuaDirectoryInfo> getDirectories(string searchPattern) => _directoryInfo.GetDirectories(searchPattern).Select(directoryInfo => new LuaDirectoryInfo(directoryInfo)).ToList();
        public List<LuaDirectoryInfo> getDirectories(string searchPattern, SearchOption searchOption) => _directoryInfo.GetDirectories(searchPattern, searchOption).Select(directoryInfo => new LuaDirectoryInfo(directoryInfo)).ToList();

        public void getFileSystemInfos(string destFileName) => _directoryInfo.GetFileSystemInfos();

        public List<LuaFileInfo> getFiles() => _directoryInfo.GetFiles().Select(fileInfo => new LuaFileInfo(fileInfo)).ToList();
        public List<LuaFileInfo> getFiles(string searchPattern) => _directoryInfo.GetFiles(searchPattern).Select(fileInfo => new LuaFileInfo(fileInfo)).ToList();
        public List<LuaFileInfo> getFiles(string searchPattern, SearchOption searchOption) => _directoryInfo.GetFiles(searchPattern, searchOption).Select(fileInfo => new LuaFileInfo(fileInfo)).ToList();
    }
}
