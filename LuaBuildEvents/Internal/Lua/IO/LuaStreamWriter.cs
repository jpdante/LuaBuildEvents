using System;
using System.IO;
using System.Text;
using MoonSharp.Interpreter.Interop;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.Internal.Lua.IO {
    public class LuaStreamWriter : IDisposable {
        [MoonSharpVisible(false)]
        private readonly StreamWriter _streamWriter;

        [MoonSharpVisible(false)]
        public StreamWriter GetStreamWriter() => _streamWriter;

        public LuaStreamWriter(Stream stream, string encoding, int bufferSize, bool leaveOpen) {
            _streamWriter = new StreamWriter(stream, Encoding.GetEncoding(encoding), bufferSize, leaveOpen);
        }

        public LuaStreamWriter(Stream stream, string encoding, int bufferSize) {
            _streamWriter = new StreamWriter(stream, Encoding.GetEncoding(encoding), bufferSize);
        }

        public LuaStreamWriter(Stream stream, string encoding) {
            _streamWriter = new StreamWriter(stream, Encoding.GetEncoding(encoding));
        }

        public LuaStreamWriter(Stream stream) {
            _streamWriter = new StreamWriter(stream);
        }

        public LuaStreamWriter(StreamWriter streamWriter) {
            _streamWriter = streamWriter;
        }

        public static LuaStreamWriter create(LuaStream stream, string encoding, int bufferSize, bool leaveOpen) => new LuaStreamWriter(stream.GetStream(), encoding, bufferSize, leaveOpen);
        public static LuaStreamWriter create(LuaStream stream, string encoding, int bufferSize) => new LuaStreamWriter(stream.GetStream(), encoding, bufferSize);
        public static LuaStreamWriter create(LuaStream stream, string encoding) => new LuaStreamWriter(stream.GetStream(), encoding);
        public static LuaStreamWriter create(LuaStream stream) => new LuaStreamWriter(stream.GetStream());

        public bool auto_flush {
            get => _streamWriter.AutoFlush;
            set => _streamWriter.AutoFlush = value;
        }

        public string encoding => _streamWriter.Encoding.ToString();

        public string new_line {
            get => _streamWriter.NewLine;
            set => _streamWriter.NewLine = value;
        }

        public void write_line() => _streamWriter.WriteLine();

        public void write_line(string data) => _streamWriter.WriteLine(data);

        public void write(char value) => _streamWriter.Write(value);

        public void dispose() => Dispose();

        public void close() => _streamWriter.Close();

        public void Dispose() {
            _streamWriter?.Dispose();
        }
    }
}
