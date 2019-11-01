using System;
using System.IO;
using System.Text;
using MoonSharp.Interpreter.Interop;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.io {
    public class LuaStreamWriter : IDisposable, LuaBridgeScript {
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

        public static LuaStreamWriter New(LuaStream stream, string encoding, int bufferSize, bool leaveOpen) => new LuaStreamWriter(stream.GetStream(), encoding, bufferSize, leaveOpen);
        public static LuaStreamWriter New(LuaStream stream, string encoding, int bufferSize) => new LuaStreamWriter(stream.GetStream(), encoding, bufferSize);
        public static LuaStreamWriter New(LuaStream stream, string encoding) => new LuaStreamWriter(stream.GetStream(), encoding);
        public static LuaStreamWriter New(LuaStream stream) => new LuaStreamWriter(stream.GetStream());

        public bool autoFlush {
            get => _streamWriter.AutoFlush;
            set => _streamWriter.AutoFlush = value;
        }

        public string encoding => _streamWriter.Encoding.ToString();

        public string newLine {
            get => _streamWriter.NewLine;
            set => _streamWriter.NewLine = value;
        }

        public void writeLine() => _streamWriter.WriteLine();

        public void writeLine(string data) => _streamWriter.WriteLine(data);

        public void write(char value) => _streamWriter.Write(value);

        public void dispose() => Dispose();

        public void close() => _streamWriter.Close();

        public void Dispose() {
            _streamWriter?.Dispose();
        }
    }
}
