using System;
using System.IO;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.io {
    public class LuaFileStream : LuaStream {
        [MoonSharpVisible(false)]
        private readonly FileStream _fileStream;

        [MoonSharpVisible(false)]
        public FileStream GetFileStream() => _fileStream;

        public LuaFileStream(string path, FileMode fileMode, FileAccess fileAccess, FileShare fileShare) {
            _fileStream = new FileStream(path, fileMode, fileAccess, fileShare);
            this.SetStream(_fileStream);
        }

        public LuaFileStream(string path, FileMode fileMode, FileAccess fileAccess) {
            _fileStream = new FileStream(path, fileMode, fileAccess);
            this.SetStream(_fileStream);
        }

        public LuaFileStream(string path, FileMode fileMode) {
            _fileStream = new FileStream(path, fileMode);
            this.SetStream(_fileStream);
        }

        public LuaFileStream(FileStream fileStream) {
            _fileStream = fileStream;
            this.SetStream(_fileStream);
        }

        public static LuaFileStream New(string path, FileMode fileMode) => new LuaFileStream(path, fileMode);
        public static LuaFileStream New(string path, FileMode fileMode, FileAccess fileAccess) => new LuaFileStream(path, fileMode, fileAccess);
        public static LuaFileStream New(string path, FileMode fileMode, FileAccess fileAccess, FileShare fileShare) => new LuaFileStream(path, fileMode, fileAccess, fileShare);

        public string name => _fileStream.Name;
        public bool isAsync => _fileStream.IsAsync;
    }
}
