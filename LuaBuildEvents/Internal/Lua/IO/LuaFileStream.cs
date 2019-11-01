using System;
using System.IO;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.Internal.Lua.IO {
    public class LuaFileStream : LuaStream {
        [MoonSharpVisible(false)]
        private readonly FileStream _fileStream;

        [MoonSharpVisible(false)]
        public FileStream GetFileStream() => _fileStream;

        public LuaFileStream(string path, string mode, string access, string share) {
            if (Enum.TryParse(mode, out FileMode fileMode) &&
                Enum.TryParse(access, out FileAccess fileAccess) &&
                Enum.TryParse(share, out FileShare fileShare)) {
                _fileStream = new FileStream(path, fileMode, fileAccess, fileShare);
            } else {
                throw new ScriptRuntimeException("Failed to parse FileStream arguments.");
            }
            this.SetStream(_fileStream);
        }

        public LuaFileStream(string path, string mode, string access) {
            if (Enum.TryParse(mode, out FileMode fileMode) &&
                Enum.TryParse(access, out FileAccess fileAccess)) {
                _fileStream = new FileStream(path, fileMode, fileAccess);
            } else {
                throw new ScriptRuntimeException("Failed to parse FileStream arguments.");
            }
            this.SetStream(_fileStream);
        }

        public LuaFileStream(string path, string mode) {
            if (Enum.TryParse(mode, out FileMode fileMode)) {
                _fileStream = new FileStream(path, fileMode);
            } else {
                throw new ScriptRuntimeException("Failed to parse FileStream arguments.");
            }
            this.SetStream(_fileStream);
        }

        public static LuaFileStream New(string path, string mode) => new LuaFileStream(path, mode);
        public static LuaFileStream New(string path, string mode, string access) => new LuaFileStream(path, mode, access);
        public static LuaFileStream New(string path, string mode, string access, string share) => new LuaFileStream(path, mode, access, share);

        public string name => _fileStream.Name;
        public bool isAsync => _fileStream.IsAsync;
    }
}
