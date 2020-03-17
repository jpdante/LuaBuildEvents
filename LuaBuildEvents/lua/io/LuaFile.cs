using System;
using System.IO;
using System.Text;
using LuaBuildEvents.lua.system;
using MoonSharp.Interpreter;

// ReSharper disable InconsistentNaming

namespace LuaBuildEvents.lua.io {
    public static class LuaFile {

        public static bool exists(string path) => File.Exists(path);
        public static void delete(string path) => File.Delete(path);
        public static void move(string from, string to) => File.Move(from, to);
        public static void move(string from, string to, bool overwrite) => File.Move(from, to, overwrite);
        public static void copy(string from, string to) => File.Copy(from, to);
        public static void copy(string from, string to, bool overwrite) => File.Copy(from, to, overwrite);
        public static void writeAllText(string path, string content) => File.WriteAllText(path, content);
        public static void writeAllText(string path, string content, string encoding) => File.WriteAllText(path, content, Encoding.GetEncoding(encoding));
        public static void writeAllLines(string path, string[] content) => File.WriteAllLines(path, content);
        public static void writeAllLines(string path, string[] content, string encoding) => File.WriteAllLines(path, content, Encoding.GetEncoding(encoding));
        public static void writeAllBytes(string path, byte[] buffer) => File.WriteAllBytes(path, buffer);
        public static void appendAllLines(string path, string[] content) => File.AppendAllLines(path, content);
        public static void appendAllLines(string path, string[] content, string encoding) => File.AppendAllLines(path, content, Encoding.GetEncoding(encoding));
        public static void appendAllText(string path, string content) => File.AppendAllText(path, content);
        public static void appendAllText(string path, string content, string encoding) => File.AppendAllText(path, content, Encoding.GetEncoding(encoding));
        public static LuaStreamWriter appendText(string path, string content) => new LuaStreamWriter(File.AppendText(path));
        public static string readAllText(string path) => File.ReadAllText(path);
        public static string[] readAllLines(string path) => File.ReadAllLines(path);
        public static byte[] readAllBytes(string path) => File.ReadAllBytes(path);
        public static string getAttributes(string path) => File.GetAttributes(path).ToString();
        public static LuaDateTime getCreationTime(string path) => new LuaDateTime(File.GetCreationTime(path));
        public static LuaDateTime getCreationTimeUtc(string path) => new LuaDateTime(File.GetCreationTimeUtc(path));
        public static LuaDateTime getLastAccessTime(string path) => new LuaDateTime(File.GetLastAccessTime(path));
        public static LuaDateTime getLastAccessTimeUtc(string path) => new LuaDateTime(File.GetLastAccessTimeUtc(path));
        public static LuaDateTime getLastWriteTime(string path) => new LuaDateTime(File.GetLastWriteTime(path));
        public static LuaDateTime getLastWriteTimeUtc(string path) => new LuaDateTime(File.GetLastWriteTimeUtc(path));
        public static void decrypt(string path) => File.Decrypt(path);
        public static void encrypt(string path) => File.Encrypt(path);
        public static LuaFileStream openRead(string path) => new LuaFileStream(File.OpenRead(path));
        public static LuaFileStream openWrite(string path) => new LuaFileStream(File.OpenWrite(path));
        public static LuaStreamReader openText(string path) => new LuaStreamReader(File.OpenText(path));
        public static void setCreationTime(string path, LuaDateTime luaDateTime) => File.SetCreationTime(path, luaDateTime.GetDateTime());
        public static void setCreationTimeUtc(string path, LuaDateTime luaDateTime) => File.SetCreationTimeUtc(path, luaDateTime.GetDateTime());
        public static void setLastAccessTime(string path, LuaDateTime luaDateTime) => File.SetLastAccessTime(path, luaDateTime.GetDateTime());
        public static void setLastAccessTimeUtc(string path, LuaDateTime luaDateTime) => File.SetLastAccessTimeUtc(path, luaDateTime.GetDateTime());
        public static void setLastWriteTime(string path, LuaDateTime luaDateTime) => File.SetLastWriteTime(path, luaDateTime.GetDateTime());
        public static void setLastWriteTimeUtc(string path, LuaDateTime luaDateTime) => File.SetLastWriteTimeUtc(path, luaDateTime.GetDateTime());
        public static LuaFileStream create(string path) => new LuaFileStream(File.Create(path));
        public static LuaFileStream create(string path, int bufferSize) => new LuaFileStream(File.Create(path, bufferSize));
        public static LuaFileStream create(string path, int bufferSize, FileOptions fileOptions) => new LuaFileStream(File.Create(path, bufferSize, fileOptions));
        public static LuaFileStream open(string path, FileMode fileMode) => new LuaFileStream(File.Open(path, fileMode));
        public static LuaFileStream open(string path, FileMode fileMode, FileAccess fileAccess) => new LuaFileStream(File.Open(path, fileMode, fileAccess));
        public static LuaFileStream open(string path, FileMode fileMode, FileAccess fileAccess, FileShare fileShare) => new LuaFileStream(File.Open(path, fileMode, fileAccess, fileShare));
        public static void setAttributes(string path, FileAttributes fileAttributes) => File.SetAttributes(path, fileAttributes);
    }
}
