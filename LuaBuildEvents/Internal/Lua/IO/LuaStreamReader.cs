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
        private readonly StreamReader _streamReader;

        [MoonSharpVisible(false)]
        public StreamReader GetStreamReader() => _streamReader;

        public LuaStreamReader(Stream stream, string encoding, bool detectEncoding) {
            _streamReader = new StreamReader(stream, Encoding.GetEncoding(encoding), detectEncoding);
        }

        public LuaStreamReader(Stream stream, string encoding) {
            _streamReader = new StreamReader(stream, Encoding.GetEncoding(encoding));
        }

        public LuaStreamReader(Stream stream) {
            _streamReader = new StreamReader(stream);
        }

        public LuaStreamReader(StreamReader streamReader) {
            _streamReader = streamReader;
        }

        public static LuaStreamReader create(LuaFileStream fileStream, string encoding, bool detectEncoding) => new LuaStreamReader(fileStream.GetFileStream(), encoding, detectEncoding);
        public static LuaStreamReader create(LuaFileStream fileStream, string encoding) => new LuaStreamReader(fileStream.GetFileStream(), encoding);
        public static LuaStreamReader create(LuaFileStream fileStream) => new LuaStreamReader(fileStream.GetFileStream());

        public bool end_of_stream => _streamReader.EndOfStream;

        public string readline() => _streamReader.ReadLine();
        public string read_to_end() => _streamReader.ReadToEnd();
        public void discard_buffered_data() => _streamReader.DiscardBufferedData();
        public int peek() => _streamReader.Peek();
        public int read() => _streamReader.Read();
        public int readblock(char[] buffer, int index, int buffer_length) => _streamReader.ReadBlock(buffer, index, buffer_length);
        public void dispose() => _streamReader.Dispose();
        public void close() => _streamReader.Close();
    }
}
