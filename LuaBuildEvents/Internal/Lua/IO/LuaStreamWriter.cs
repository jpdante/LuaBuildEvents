using System.IO;
using System.Text;
using MoonSharp.Interpreter.Interop;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.Internal.Lua.IO {
    public class LuaStreamWriter {
        [MoonSharpVisible(false)]
        public readonly StreamWriter StreamWriter;

        public LuaStreamWriter(Stream stream, string encoding, int bufferSize, bool leaveOpen) {
            StreamWriter = new StreamWriter(stream, Encoding.GetEncoding(encoding), bufferSize, leaveOpen);
        }

        public LuaStreamWriter(Stream stream, string encoding, int bufferSize) {
            StreamWriter = new StreamWriter(stream, Encoding.GetEncoding(encoding), bufferSize);
        }

        public LuaStreamWriter(Stream stream, string encoding) {
            StreamWriter = new StreamWriter(stream, Encoding.GetEncoding(encoding));
        }

        public LuaStreamWriter(Stream stream) {
            StreamWriter = new StreamWriter(stream);
        }

        public static LuaStreamWriter create(LuaFileStream fileStream, string encoding, int bufferSize, bool leaveOpen) => new LuaStreamWriter(fileStream.FileStream, encoding, bufferSize, leaveOpen);
        public static LuaStreamWriter create(LuaFileStream fileStream, string encoding, int bufferSize) => new LuaStreamWriter(fileStream.FileStream, encoding, bufferSize);
        public static LuaStreamWriter create(LuaFileStream fileStream, string encoding) => new LuaStreamWriter(fileStream.FileStream, encoding);
        public static LuaStreamWriter create(LuaFileStream fileStream) => new LuaStreamWriter(fileStream.FileStream);

        public bool autoflush => StreamWriter.AutoFlush;
        public string encoding => StreamWriter.Encoding.ToString();
        public string newline => StreamWriter.NewLine;

        public void writeline() => StreamWriter.WriteLine();
        public void writeline(string data) => StreamWriter.WriteLine(data);
        public void write(char value) => StreamWriter.Write(value);
        public void dispose() => StreamWriter.Dispose();
        public void close() => StreamWriter.Close();
    }
}
