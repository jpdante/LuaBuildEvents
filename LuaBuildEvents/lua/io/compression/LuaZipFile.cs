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
        
        public static void createFromDirectory(string sourceDirectoryName, string destinationArchiveFileName, CompressionLevel compressionLevel, bool includeBaseDirectory) => 
            ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName, compressionLevel, includeBaseDirectory);

        public static void createFromDirectory(string sourceDirectoryName, string destinationArchiveFileName, CompressionLevel compressionLevel, bool includeBaseDirectory, string encoding) => 
            ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName, compressionLevel, includeBaseDirectory, Encoding.GetEncoding(encoding));

        public static LuaZipArchive open(string path, ZipArchiveMode zipArchiveMode) =>
            new LuaZipArchive(ZipFile.Open(path, zipArchiveMode));

        public static LuaZipArchive open(string path, ZipArchiveMode zipArchiveMode, string encoding) => 
            new LuaZipArchive(ZipFile.Open(path, zipArchiveMode, Encoding.GetEncoding(encoding)));
    }
}
