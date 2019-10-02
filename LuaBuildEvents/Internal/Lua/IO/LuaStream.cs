using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.Internal.Lua.IO {
    public class LuaStream : IDisposable {

        [MoonSharpVisible(false)]
        protected Stream _stream;

        [MoonSharpVisible(false)]
        public Stream GetStream() => _stream;
        [MoonSharpVisible(false)]
        public void SetStream(Stream stream) { _stream = stream; }

        public bool can_read => _stream.CanRead;
        public bool can_seek => _stream.CanSeek;
        public bool can_write => _stream.CanWrite;
        public bool can_timeout => _stream.CanTimeout;

        public long position {
            get => _stream.Position;
            set => _stream.Position = value;
        }
        public int read_timeout {
            get => _stream.ReadTimeout;
            set => _stream.ReadTimeout = value;
        }
        public int write_timeout {
            get => _stream.WriteTimeout;
            set => _stream.WriteTimeout = value;
        }

        public void flush() => _stream.Flush();

        public long seek(long offset, string origin) {
            if (Enum.TryParse(origin, out SeekOrigin seekOrigin)) {
                return _stream.Seek(offset, seekOrigin);
            }
            throw new ScriptRuntimeException("Failed to parse arguments.");
        }

        public int read(byte[] buffer, int offset, int buffer_length) => _stream.Read(buffer, offset, buffer_length);
        public int read_byte() => _stream.ReadByte();

        public void write(byte[] buffer, int offset, int buffer_length) => _stream.Write(buffer, offset, buffer_length);
        public void write_byte(byte value) => _stream.WriteByte(value);

        public long get_length() => _stream.Length;
        public void set_length(long value) => _stream.SetLength(value);

        public void close() => _stream.Close();

        public void dispose() => Dispose();

        [MoonSharpVisible(false)]
        public void Dispose() {
            _stream?.Dispose();
        }
    }
}
