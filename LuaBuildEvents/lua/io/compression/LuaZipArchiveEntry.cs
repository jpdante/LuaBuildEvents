using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;
using LuaBuildEvents.lua.system;
using MoonSharp.Interpreter.Interop;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.io.compression {
    public class LuaZipArchiveEntry {
        [MoonSharpVisible(false)] 
        private readonly ZipArchiveEntry _entry;

        public LuaZipArchiveEntry(ZipArchiveEntry entry) {
            this._entry = entry;
        }

        public string fullName => _entry.FullName;
        public string name => _entry.Name;
        public LuaZipArchive archive => new LuaZipArchive(_entry.Archive);
        public long compressedLength => _entry.CompressedLength;
        public int crc32 => (int)_entry.Crc32;
        public long length => _entry.Length;
        public int externalAttributes {
            get => _entry.ExternalAttributes;
            set => _entry.ExternalAttributes = value;
        }
        public LuaDateTimeOffset lastWriteTime {
            get => new LuaDateTimeOffset(_entry.LastWriteTime);
            set => _entry.LastWriteTime = value.GetDateTimeOffset();
        }

        public LuaStream open() => new LuaStream(_entry.Open());
        public void delete() => _entry.Delete();

        public override string ToString() { return _entry.ToString(); }
    }
}
