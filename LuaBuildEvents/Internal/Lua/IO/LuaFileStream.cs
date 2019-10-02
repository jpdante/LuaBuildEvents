using System;
using System.IO;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.Internal.Lua.IO {
    public class LuaFileStream : IDisposable {
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
        }

        public LuaFileStream(string path, string mode, string access) {
            if (Enum.TryParse(mode, out FileMode fileMode) &&
                Enum.TryParse(access, out FileAccess fileAccess)) {
                _fileStream = new FileStream(path, fileMode, fileAccess);
            } else {
                throw new ScriptRuntimeException("Failed to parse FileStream arguments.");
            }
        }

        public LuaFileStream(string path, string mode) {
            if (Enum.TryParse(mode, out FileMode fileMode)) {
                _fileStream = new FileStream(path, fileMode);
            } else {
                throw new ScriptRuntimeException("Failed to parse FileStream arguments.");
            }
        }

        public static LuaFileStream create(string path, string mode) => new LuaFileStream(path, mode);
        public static LuaFileStream create(string path, string mode, string access) => new LuaFileStream(path, mode, access);
        public static LuaFileStream create(string path, string mode, string access, string share) => new LuaFileStream(path, mode, access, share);

        public string name => _fileStream.Name;
        public bool canread => _fileStream.CanRead;
        public bool canseek => _fileStream.CanSeek;
        public bool canwrite => _fileStream.CanWrite;
        public bool isasync => _fileStream.IsAsync;
        public long stream_length => _fileStream.Length;

        public long position {
            get => _fileStream.Position;
            set => _fileStream.Position = value;
        }
        public bool can_timeout => _fileStream.CanTimeout;
        public int read_timeout {
            get => _fileStream.ReadTimeout;
            set => _fileStream.ReadTimeout = value;
        }
        public int write_timeout {
            get => _fileStream.WriteTimeout;
            set => _fileStream.WriteTimeout = value;
        }

        public int read(byte[] buffer, int offset, int buffer_length) => _fileStream.Read(buffer, offset, buffer_length);
        public int readbyte() => _fileStream.ReadByte();
        public void flush() => _fileStream.Flush();
        public long seek(long offset, string origin) {
            if (Enum.TryParse(origin, out SeekOrigin seekOrigin)) {
                return _fileStream.Seek(offset, seekOrigin);
            }
            throw new ScriptRuntimeException("Failed to parse arguments.");
        }
        public void setlength(long value) => _fileStream.SetLength(value);
        public void write(byte[] buffer, int offset, int buffer_length) => _fileStream.Write(buffer, offset, buffer_length);
        public void writebyte(byte value) => _fileStream.WriteByte(value);
        public void close() => _fileStream.Close();
        public void dispose() => Dispose();

        [MoonSharpVisible(false)]
        public void Dispose() {
            _fileStream?.Dispose();
        }
    }
}
