using System;
using System.IO;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.io {
    public class LuaStream : IDisposable {

        [MoonSharpVisible(false)]
        protected Stream _stream;

        [MoonSharpVisible(false)]
        public Stream GetStream() => _stream;
        [MoonSharpVisible(false)]
        public void SetStream(Stream stream) { _stream = stream; }

        public bool canRead => _stream.CanRead;
        public bool canSeek => _stream.CanSeek;
        public bool canWrite => _stream.CanWrite;
        public bool canTimeout => _stream.CanTimeout;

        public long position {
            get => _stream.Position;
            set => _stream.Position = value;
        }
        public int readTimeout {
            get => _stream.ReadTimeout;
            set => _stream.ReadTimeout = value;
        }
        public int writeTimeout {
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
        public int readByte() => _stream.ReadByte();

        public void write(byte[] buffer, int offset, int buffer_length) => _stream.Write(buffer, offset, buffer_length);
        public void writeByte(byte value) => _stream.WriteByte(value);

        public long getLength() => _stream.Length;
        public void setLength(long value) => _stream.SetLength(value);

        public void close() => _stream.Close();

        public void dispose() => Dispose();

        [MoonSharpVisible(false)]
        public void Dispose() {
            _stream?.Dispose();
        }
    }
}
