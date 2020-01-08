using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.io.compression {
    public class LuaZipArchive : IDisposable {
        [MoonSharpVisible(false)] 
        private readonly ZipArchive _zipArchive;

        public LuaZipArchive(Stream stream) {
            this._zipArchive = new ZipArchive(stream);
        }

        public LuaZipArchive(Stream stream, ZipArchiveMode zipArchiveMode) {
            this._zipArchive = new ZipArchive(stream, zipArchiveMode);
        }

        public LuaZipArchive(Stream stream, ZipArchiveMode zipArchiveMode, bool leaveOpen) {
            this._zipArchive = new ZipArchive(stream, zipArchiveMode, leaveOpen);
        }

        public LuaZipArchive(Stream stream, ZipArchiveMode zipArchiveMode, bool leaveOpen, Encoding encoding) {
            this._zipArchive = new ZipArchive(stream, zipArchiveMode, leaveOpen, encoding);
        }

        public LuaZipArchive(ZipArchive zipArchive) {
            this._zipArchive = zipArchive;
        }

        public static LuaZipArchive New(LuaStream stream) => new LuaZipArchive(stream.GetStream());
        public static LuaZipArchive New(LuaStream stream, string mode) {
            if (!Enum.TryParse(mode, out ZipArchiveMode zipArchiveMode)) {
                return new LuaZipArchive(stream.GetStream(), zipArchiveMode);
            }
            throw new ScriptRuntimeException("Failed to parse SearchOption.");
        }
        public static LuaZipArchive New(LuaStream stream, string mode, bool leaveOpen) {
            if (!Enum.TryParse(mode, out ZipArchiveMode zipArchiveMode)) {
                return new LuaZipArchive(stream.GetStream(), zipArchiveMode, leaveOpen);
            }
            throw new ScriptRuntimeException("Failed to parse SearchOption.");
        }
        public static LuaZipArchive New(LuaStream stream, string mode, bool leaveOpen, string encoding) {
            if (!Enum.TryParse(mode, out ZipArchiveMode zipArchiveMode)) {
                return new LuaZipArchive(stream.GetStream(), zipArchiveMode, leaveOpen, Encoding.GetEncoding(encoding));
            }
            throw new ScriptRuntimeException("Failed to parse SearchOption.");
        }

        public string mode => _zipArchive.Mode.ToString();
        public List<LuaZipArchiveEntry> entries => _zipArchive.Entries.Select(entry => new LuaZipArchiveEntry(entry)).ToList();

        public LuaZipArchiveEntry createEntry(string entryName) => new LuaZipArchiveEntry(_zipArchive.CreateEntry(entryName));

        public LuaZipArchiveEntry createEntry(string entryName, string level) {
            if (!Enum.TryParse(level, out CompressionLevel compressionLevel)) {
                return new LuaZipArchiveEntry(_zipArchive.CreateEntry(entryName, compressionLevel));
            }
            throw new ScriptRuntimeException("Failed to parse SearchOption.");
        }

        public LuaZipArchiveEntry getEntry(string entryName) => new LuaZipArchiveEntry(_zipArchive.GetEntry(entryName));

        public void dispose() => Dispose();

        public override string ToString() { return _zipArchive.ToString(); }

        ~LuaZipArchive() {
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
                _zipArchive?.Dispose();
            }
        }
    }
}
