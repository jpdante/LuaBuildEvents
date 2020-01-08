using System;
using System.IO;
using System.Text;
using MoonSharp.Interpreter.Interop;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.io {
    public class LuaStreamReader : IDisposable {
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

        public static LuaStreamReader New(LuaStream stream, string encoding, bool detectEncoding) => new LuaStreamReader(stream.GetStream(), encoding, detectEncoding);
        public static LuaStreamReader New(LuaStream stream, string encoding) => new LuaStreamReader(stream.GetStream(), encoding);
        public static LuaStreamReader New(LuaStream stream) => new LuaStreamReader(stream.GetStream());

        public bool isEndOfStream => _streamReader.EndOfStream;

        public string readLine() => _streamReader.ReadLine();

        public string readToEnd() => _streamReader.ReadToEnd();

        public void discardBufferedData() => _streamReader.DiscardBufferedData();

        public int peek() => _streamReader.Peek();

        public int read() => _streamReader.Read();

        public int readBlock(char[] buffer, int index, int buffer_length) => _streamReader.ReadBlock(buffer, index, buffer_length);

        public void dispose() => Dispose();

        public void close() => _streamReader.Close();

        ~LuaStreamReader() {
            Dispose(false);
        }

        [MoonSharpVisible(false)]
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        [MoonSharpVisible(false)]
        protected virtual void Dispose(bool disposing) {
            if (disposing) {
                _streamReader?.Dispose();
            }
        }
    }
}
