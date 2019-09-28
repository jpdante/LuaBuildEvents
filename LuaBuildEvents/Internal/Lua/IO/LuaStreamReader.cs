using System;
using System.IO;
using System.Text;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.Internal.Lua.IO {
    public class LuaStreamReader {
        [MoonSharpVisible(false)]
        public readonly StreamReader StreamReader;

        public LuaStreamReader(Stream stream, string encoding, bool detectEncoding) {
            StreamReader = new StreamReader(stream, Encoding.GetEncoding(encoding), detectEncoding);
        }

        public LuaStreamReader(Stream stream, string encoding) {
            StreamReader = new StreamReader(stream, Encoding.GetEncoding(encoding));
        }

        public LuaStreamReader(Stream stream) {
            StreamReader = new StreamReader(stream);
        }

        public static LuaStreamReader create(LuaFileStream fileStream, string encoding, bool detectEncoding) => new LuaStreamReader(fileStream.FileStream, encoding, detectEncoding);
        public static LuaStreamReader create(LuaFileStream fileStream, string encoding) => new LuaStreamReader(fileStream.FileStream, encoding);
        public static LuaStreamReader create(LuaFileStream fileStream) => new LuaStreamReader(fileStream.FileStream);

        public bool end_of_stream => StreamReader.EndOfStream;

        public string readline() => StreamReader.ReadLine();
        public string read_to_end() => StreamReader.ReadToEnd();
        public void discard_buffered_data() => StreamReader.DiscardBufferedData();
        public int peek() => StreamReader.Peek();
        public int read() => StreamReader.Read();
        public int readblock(char[] buffer, int index, int buffer_length) => StreamReader.ReadBlock(buffer, index, buffer_length);
        public void dispose() => StreamReader.Dispose();
        public void close() => StreamReader.Close();
    }
}
