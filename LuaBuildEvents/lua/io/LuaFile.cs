using System;
using System.IO;
using System.Text;
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
        public static DateTime getCreationTime(string path) => File.GetCreationTime(path);
        public static DateTime getCreationTimeUtc(string path) => File.GetCreationTimeUtc(path);
        public static DateTime getLastAccessTime(string path) => File.GetLastAccessTime(path);
        public static DateTime getLastAccessTimeUtc(string path) => File.GetLastAccessTimeUtc(path);
        public static DateTime getLastWriteTime(string path) => File.GetLastWriteTime(path);
        public static DateTime getLastWriteTimeUtc(string path) => File.GetLastWriteTimeUtc(path);
        public static void decrypt(string path) => File.Decrypt(path);
        public static void encrypt(string path) => File.Encrypt(path);
        public static LuaFileStream openRead(string path) => new LuaFileStream(File.OpenRead(path));
        public static LuaFileStream openWrite(string path) => new LuaFileStream(File.OpenWrite(path));
        public static LuaStreamReader openText(string path) => new LuaStreamReader(File.OpenText(path));
        public static void setCreationTime(string path, DateTime dateTime) => File.SetCreationTime(path, dateTime);
        public static void setCreationTimeUtc(string path, DateTime dateTime) => File.SetCreationTimeUtc(path, dateTime);
        public static void setLastAccessTime(string path, DateTime dateTime) => File.SetLastAccessTime(path, dateTime);
        public static void setLastAccessTimeUtc(string path, DateTime dateTime) => File.SetLastAccessTimeUtc(path, dateTime);
        public static void setLastWriteTime(string path, DateTime dateTime) => File.SetLastWriteTime(path, dateTime);
        public static void setLastWriteTimeUtc(string path, DateTime dateTime) => File.SetLastWriteTimeUtc(path, dateTime);
        public static LuaFileStream create(string path) => new LuaFileStream(File.Create(path));
        public static LuaFileStream create(string path, int bufferSize) => new LuaFileStream(File.Create(path, bufferSize));
        public static LuaFileStream create(string path, int bufferSize, string fileOptions) {
            if (!Enum.TryParse(fileOptions, out FileOptions result)) {
                return new LuaFileStream(File.Create(path, bufferSize, result));
            }
            throw new ScriptRuntimeException("Failed to parse FileAttributes.");
        }
        public static LuaFileStream open(string path, string mode) {
            if (Enum.TryParse(mode, out FileMode fileMode)) {
                return new LuaFileStream(File.Open(path, fileMode));
            } else {
                throw new ScriptRuntimeException("Failed to parse FileStream arguments.");
            }
        }
        public static LuaFileStream open(string path, string mode, string access) {
            if (Enum.TryParse(mode, out FileMode fileMode) &&
                Enum.TryParse(access, out FileAccess fileAccess)) {
                return new LuaFileStream(File.Open(path, fileMode, fileAccess));
            } else {
                throw new ScriptRuntimeException("Failed to parse FileStream arguments.");
            }
        }
        public static LuaFileStream open(string path, string mode, string access, string share) {
            if (Enum.TryParse(mode, out FileMode fileMode) &&
                Enum.TryParse(access, out FileAccess fileAccess) &&
                Enum.TryParse(share, out FileShare fileShare)) {
                return new LuaFileStream(File.Open(path, fileMode, fileAccess, fileShare));
            } else {
                throw new ScriptRuntimeException("Failed to parse FileStream arguments.");
            }
        }
        public static void setAttributes(string path, string attributes) {
            if (Enum.TryParse(attributes, out FileAttributes fileAttributes)) { 
                File.SetAttributes(path, fileAttributes);
            } else {
                throw new ScriptRuntimeException("Failed to parse FileStream arguments.");
            }
        }
    }
}
