using System.IO;
using System.IO.Compression;
using MoonSharp.Interpreter.Interop;

namespace LuaBuildEvents.lua.io.compression {
    public class LuaGZipStream : LuaStream {

        [MoonSharpVisible(false)]
        private readonly GZipStream _gzipStream;

        [MoonSharpVisible(false)]
        public GZipStream GetGZipStream() => _gzipStream;

        public LuaGZipStream(Stream stream, CompressionLevel compressionLevel) {
            _gzipStream = new GZipStream(stream, compressionLevel);
            this.SetStream(_gzipStream);
        }

        public LuaGZipStream(Stream stream, CompressionMode compressionMode) {
            _gzipStream = new GZipStream(stream, compressionMode);
            this.SetStream(_gzipStream);
        }

        public LuaGZipStream(Stream stream, CompressionLevel compressionLevel, bool leaveOpen) {
            _gzipStream = new GZipStream(stream, compressionLevel, leaveOpen);
            this.SetStream(_gzipStream);
        }

        public LuaGZipStream(Stream stream, CompressionMode compressionMode, bool leaveOpen) {
            _gzipStream = new GZipStream(stream, compressionMode, leaveOpen);
            this.SetStream(_gzipStream);
        }

        public static LuaGZipStream New(LuaStream stream, CompressionLevel compressionLevel) => new LuaGZipStream(stream.GetStream(), compressionLevel);
        public static LuaGZipStream New(LuaStream stream, CompressionMode compressionMode) => new LuaGZipStream(stream.GetStream(), compressionMode);
        public static LuaGZipStream New(LuaStream stream, CompressionLevel compressionLevel, bool leaveOpen) => new LuaGZipStream(stream.GetStream(), compressionLevel, leaveOpen);
        public static LuaGZipStream New(LuaStream stream, CompressionMode compressionMode, bool leaveOpen) => new LuaGZipStream(stream.GetStream(), compressionMode, leaveOpen);
    }
}
