using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;

namespace LuaBuildEvents.lua.io.compression {
    public class LuaDeflateStream : LuaStream {

        [MoonSharpVisible(false)]
        private readonly DeflateStream _deflateStream;

        [MoonSharpVisible(false)]
        public DeflateStream GetDeflateStream() => _deflateStream;

        public LuaDeflateStream(Stream stream, CompressionLevel compressionLevel) {
            _deflateStream = new DeflateStream(stream, compressionLevel);
            this.SetStream(_deflateStream);
        }

        public LuaDeflateStream(Stream stream, CompressionMode compressionMode) {
            _deflateStream = new DeflateStream(stream, compressionMode);
            this.SetStream(_deflateStream);
        }

        public LuaDeflateStream(Stream stream, CompressionLevel compressionLevel, bool leaveOpen) {
            _deflateStream = new DeflateStream(stream, compressionLevel, leaveOpen);
            this.SetStream(_deflateStream);
        }

        public LuaDeflateStream(Stream stream, CompressionMode compressionMode, bool leaveOpen) {
            _deflateStream = new DeflateStream(stream, compressionMode, leaveOpen);
            this.SetStream(_deflateStream);
        }

        public static LuaDeflateStream New(LuaStream stream, CompressionLevel compressionLevel) => new LuaDeflateStream(stream.GetStream(), compressionLevel);
        public static LuaDeflateStream New(LuaStream stream, CompressionMode compressionMode) => new LuaDeflateStream(stream.GetStream(), compressionMode);
        public static LuaDeflateStream New(LuaStream stream, CompressionLevel compressionLevel, bool leaveOpen) => new LuaDeflateStream(stream.GetStream(), compressionLevel, leaveOpen);
        public static LuaDeflateStream New(LuaStream stream, CompressionMode compressionMode, bool leaveOpen) => new LuaDeflateStream(stream.GetStream(), compressionMode, leaveOpen);
    }
}
