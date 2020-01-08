using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        public string attributes {
            get => _directoryInfo.Attributes.ToString();
            set {
                if (!Enum.TryParse(value, out FileAttributes result)) {
                    _directoryInfo.Attributes = result;
                }
                throw new ScriptRuntimeException("Failed to parse FileAttributes.");
            }
        }
        public DateTime creationTime => _directoryInfo.CreationTime;
        public DateTime creationTimeUtc => _directoryInfo.CreationTimeUtc;
        public DateTime lastAccessTime => _directoryInfo.LastAccessTime;
        public DateTime lastAccessTimeUtc => _directoryInfo.LastAccessTimeUtc;
        public DateTime lastWriteTime => _directoryInfo.LastWriteTime;
        public DateTime lastWriteTimeUtc => _directoryInfo.LastWriteTimeUtc;

        public void create() => _directoryInfo.Create();
        public LuaDirectoryInfo createSubdirectory(string path) => new LuaDirectoryInfo(_directoryInfo.CreateSubdirectory(path));
        public void delete() => _directoryInfo.Delete();
        public void moveTo(string destFileName) => _directoryInfo.MoveTo(destFileName);

        public List<LuaDirectoryInfo> enumerateDirectories() => _directoryInfo.EnumerateDirectories().Select(directoryInfo => new LuaDirectoryInfo(directoryInfo)).ToList();
        public List<LuaDirectoryInfo> enumerateDirectories(string searchPattern) => _directoryInfo.EnumerateDirectories(searchPattern).Select(directoryInfo => new LuaDirectoryInfo(directoryInfo)).ToList();
        public List<LuaDirectoryInfo> enumerateDirectories(string searchPattern, string searchOption) {
            if (!Enum.TryParse(searchOption, out SearchOption result)) {
                return _directoryInfo.EnumerateDirectories(searchPattern, result).Select(directoryInfo => new LuaDirectoryInfo(directoryInfo)).ToList();
            }
            throw new ScriptRuntimeException("Failed to parse SearchOption.");
        }

        public List<LuaFileSystemInfo> enumerateFileSystemInfos() => _directoryInfo.EnumerateFileSystemInfos().Select(fileSystemInfo => new LuaFileSystemInfo(fileSystemInfo)).ToList();
        public List<LuaFileSystemInfo> enumerateFileSystemInfos(string searchPattern) => _directoryInfo.EnumerateFileSystemInfos(searchPattern).Select(fileSystemInfo => new LuaFileSystemInfo(fileSystemInfo)).ToList();
        public List<LuaFileSystemInfo> enumerateFileSystemInfos(string searchPattern, string searchOption) {
            if (!Enum.TryParse(searchOption, out SearchOption result)) {
                return _directoryInfo.EnumerateFileSystemInfos(searchPattern, result).Select(fileSystemInfo => new LuaFileSystemInfo(fileSystemInfo)).ToList();
            }
            throw new ScriptRuntimeException("Failed to parse SearchOption.");
        }

        public List<LuaFileInfo> enumerateFiles() => _directoryInfo.EnumerateFiles().Select(fileInfo => new LuaFileInfo(fileInfo)).ToList();
        public List<LuaFileInfo> enumerateFiles(string searchPattern) => _directoryInfo.EnumerateFiles(searchPattern).Select(fileInfo => new LuaFileInfo(fileInfo)).ToList();
        public List<LuaFileInfo> enumerateFiles(string searchPattern, string searchOption) {
            if (!Enum.TryParse(searchOption, out SearchOption result)) {
                return _directoryInfo.EnumerateFiles(searchPattern, result).Select(fileInfo => new LuaFileInfo(fileInfo)).ToList();
            }
            throw new ScriptRuntimeException("Failed to parse SearchOption.");
        }

        public List<LuaDirectoryInfo> getDirectories() => _directoryInfo.GetDirectories().Select(directoryInfo => new LuaDirectoryInfo(directoryInfo)).ToList();
        public List<LuaDirectoryInfo> getDirectories(string searchPattern) => _directoryInfo.GetDirectories(searchPattern).Select(directoryInfo => new LuaDirectoryInfo(directoryInfo)).ToList();
        public List<LuaDirectoryInfo> getDirectories(string searchPattern, string searchOption) {
            if (!Enum.TryParse(searchOption, out SearchOption result)) {
                return _directoryInfo.GetDirectories(searchPattern, result).Select(directoryInfo => new LuaDirectoryInfo(directoryInfo)).ToList();
            }
            throw new ScriptRuntimeException("Failed to parse SearchOption.");
        }

        public void getFileSystemInfos(string destFileName) => _directoryInfo.GetFileSystemInfos();

        public List<LuaFileInfo> getFiles() => _directoryInfo.GetFiles().Select(fileInfo => new LuaFileInfo(fileInfo)).ToList();
        public List<LuaFileInfo> getFiles(string searchPattern) => _directoryInfo.GetFiles(searchPattern).Select(fileInfo => new LuaFileInfo(fileInfo)).ToList();
        public List<LuaFileInfo> getFiles(string searchPattern, string searchOption) {
            if (!Enum.TryParse(searchOption, out SearchOption result)) {
                return _directoryInfo.GetFiles(searchPattern, result).Select(fileInfo => new LuaFileInfo(fileInfo)).ToList();
            }
            throw new ScriptRuntimeException("Failed to parse SearchOption.");
        }
    }
}
