using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using MoonSharp.Interpreter;
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

        public static LuaGZipStream New(LuaStream stream, string data) {
            if (Enum.TryParse(data, out CompressionLevel compressionLevel)) {
                return new LuaGZipStream(stream.GetStream(), compressionLevel);
            }
            if (Enum.TryParse(data, out CompressionMode compressionMode)) {
                return new LuaGZipStream(stream.GetStream(), compressionMode);
            }
            throw new ScriptRuntimeException("Failed to parse FileStream arguments.");
        }

        public static LuaGZipStream New(LuaStream stream, string data, bool leaveOpen) {
            if (Enum.TryParse(data, out CompressionLevel compressionLevel)) {
                return new LuaGZipStream(stream.GetStream(), compressionLevel, leaveOpen);
            }
            if (Enum.TryParse(data, out CompressionMode compressionMode)) {
                return new LuaGZipStream(stream.GetStream(), compressionMode, leaveOpen);
            }
            throw new ScriptRuntimeException("Failed to parse FileStream arguments.");
        }
    }
}
