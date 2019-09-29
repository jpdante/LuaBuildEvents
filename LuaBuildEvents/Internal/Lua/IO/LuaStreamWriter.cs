using System.IO;
using System.Text;
using MoonSharp.Interpreter.Interop;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.Internal.Lua.IO {
    public class LuaStreamWriter {
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

        public static LuaStreamWriter create(LuaFileStream fileStream, string encoding, int bufferSize, bool leaveOpen) => new LuaStreamWriter(fileStream.GetFileStream(), encoding, bufferSize, leaveOpen);
        public static LuaStreamWriter create(LuaFileStream fileStream, string encoding, int bufferSize) => new LuaStreamWriter(fileStream.GetFileStream(), encoding, bufferSize);
        public static LuaStreamWriter create(LuaFileStream fileStream, string encoding) => new LuaStreamWriter(fileStream.GetFileStream(), encoding);
        public static LuaStreamWriter create(LuaFileStream fileStream) => new LuaStreamWriter(fileStream.GetFileStream());

        public bool autoflush {
            get => _streamWriter.AutoFlush;
            set => _streamWriter.AutoFlush = value;
        }
        public string encoding => _streamWriter.Encoding.ToString();

        public string newline {
            get => _streamWriter.NewLine;
            set => _streamWriter.NewLine = value;
        }

        public void writeline() => _streamWriter.WriteLine();
        public void writeline(string data) => _streamWriter.WriteLine(data);
        public void write(char value) => _streamWriter.Write(value);
        public void dispose() => _streamWriter.Dispose();
        public void close() => _streamWriter.Close();
    }
}
