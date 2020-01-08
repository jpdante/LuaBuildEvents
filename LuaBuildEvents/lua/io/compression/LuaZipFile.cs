using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;
using MoonSharp.Interpreter;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.io.compression {
    public static class LuaZipFile {

        public static LuaZipArchive openRead(string path) => new LuaZipArchive(ZipFile.OpenRead(path));
        
        public static void createFromDirectory(string sourceDirectoryName, string destinationArchiveFileName) =>
            ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName);
        
        public static void extractToDirectory(string sourceArchiveFileName, string destinationArchiveFileName) =>
            ZipFile.ExtractToDirectory(sourceArchiveFileName, destinationArchiveFileName);
        
        public static void extractToDirectory(string sourceArchiveFileName, string destinationArchiveFileName, bool overwriteFiles) =>
            ZipFile.ExtractToDirectory(sourceArchiveFileName, destinationArchiveFileName, overwriteFiles);
        
        public static void extractToDirectory(string sourceArchiveFileName, string destinationArchiveFileName, string encoding) =>
            ZipFile.ExtractToDirectory(sourceArchiveFileName, destinationArchiveFileName, Encoding.GetEncoding(encoding));
        
        public static void extractToDirectory(string sourceArchiveFileName, string destinationArchiveFileName, string encoding, bool overwriteFiles) => 
            ZipFile.ExtractToDirectory(sourceArchiveFileName, destinationArchiveFileName, Encoding.GetEncoding(encoding), overwriteFiles);
        
        public static LuaZipArchive createFromDirectory(string sourceDirectoryName, string destinationArchiveFileName, string level, bool includeBaseDirectory) {
            if (!Enum.TryParse(level, out CompressionLevel compressionLevel)) {
                ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName, compressionLevel, includeBaseDirectory);
            }
            throw new ScriptRuntimeException("Failed to parse CompressionLevel.");
        }

        public static LuaZipArchive createFromDirectory(string sourceDirectoryName, string destinationArchiveFileName, string level, bool includeBaseDirectory, string encoding) {
            if (!Enum.TryParse(level, out CompressionLevel compressionLevel)) {
                ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName, compressionLevel, includeBaseDirectory, Encoding.GetEncoding(encoding));
            }
            throw new ScriptRuntimeException("Failed to parse CompressionLevel.");
        }

        public static LuaZipArchive open(string path, string mode) {
            if (!Enum.TryParse(mode, out ZipArchiveMode zipArchiveMode)) {
                return new LuaZipArchive(ZipFile.Open(path, zipArchiveMode));
            }
            throw new ScriptRuntimeException("Failed to parse ZipArchiveMode.");
        }

        public static LuaZipArchive open(string path, string mode, string encoding) {
            if (!Enum.TryParse(mode, out ZipArchiveMode zipArchiveMode)) {
                return new LuaZipArchive(ZipFile.Open(path, zipArchiveMode, Encoding.GetEncoding(encoding)));
            }
            throw new ScriptRuntimeException("Failed to parse ZipArchiveMode.");
        }
    }
}
