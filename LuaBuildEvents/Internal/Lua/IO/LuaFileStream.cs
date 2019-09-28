using System;
using System.IO;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.Internal.Lua.IO {
    public class LuaFileStream {
        [MoonSharpVisible(false)]
        public readonly FileStream FileStream;

        public LuaFileStream(string path, string mode, string access, string share) {
            if (Enum.TryParse(mode, out FileMode fileMode) &&
                Enum.TryParse(access, out FileAccess fileAccess) &&
                Enum.TryParse(share, out FileShare fileShare)) {
                FileStream = new FileStream(path, fileMode, fileAccess, fileShare);
            } else throw new ScriptRuntimeException("Failed to parse FileStream arguments.");
        }

        public LuaFileStream(string path, string mode, string access) {
            if (Enum.TryParse(mode, out FileMode fileMode) &&
                Enum.TryParse(access, out FileAccess fileAccess)) {
                FileStream = new FileStream(path, fileMode, fileAccess);
            } else throw new ScriptRuntimeException("Failed to parse FileStream arguments.");
        }

        public LuaFileStream(string path, string mode) {
            if (Enum.TryParse(mode, out FileMode fileMode)) {
                FileStream = new FileStream(path, fileMode);
            } else throw new ScriptRuntimeException("Failed to parse FileStream arguments.");
        }

        public static LuaFileStream create(string path, string mode) => new LuaFileStream(path, mode);
        public static LuaFileStream create(string path, string mode, string access) => new LuaFileStream(path, mode, access);
        public static LuaFileStream create(string path, string mode, string access, string share) => new LuaFileStream(path, mode, access, share);

        public string name => FileStream.Name;
        public bool canread => FileStream.CanRead;
        public bool canseek => FileStream.CanSeek;
        public bool canwrite => FileStream.CanWrite;
        public bool isasync => FileStream.IsAsync;
        public long stream_length => FileStream.Length;
        public long position => FileStream.Position;
        public bool can_timeout => FileStream.CanTimeout;
        public int read_timeout => FileStream.ReadTimeout;
        public int write_timeout => FileStream.WriteTimeout;

        public int read(byte[] buffer, int offset, int buffer_length) => FileStream.Read(buffer, offset, buffer_length);
        public int readbyte() => FileStream.ReadByte();
        public void flush() => FileStream.Flush();
        public long seek(long offset, string origin) {
            if (Enum.TryParse(origin, out SeekOrigin seekOrigin)) {
                return FileStream.Seek(offset, seekOrigin);
            }
            throw new ScriptRuntimeException("Failed to parse arguments.");
        }
        public void setlength(long value) => FileStream.SetLength(value);
        public void write(byte[] buffer, int offset, int buffer_length) => FileStream.Write(buffer, offset, buffer_length);
        public void writebyte(byte value) => FileStream.WriteByte(value);
        public void close() => FileStream.Close();
        public void dispose() => FileStream.Dispose();
    }
}
