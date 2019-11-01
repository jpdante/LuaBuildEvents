using System.IO;

// ReSharper disable InconsistentNaming

namespace LuaBuildEvents.lua.io {
    public class LuaFile : LuaBridgeScript {
        public static bool exists(string path) => File.Exists(path);
        public static void delete(string path) => File.Delete(path);
        public static void move(string from, string to) => move(from, to, false);
        public static void move(string from, string to, bool overwrite) => File.Move(from, to, overwrite);
        public static void copy(string from, string to) => copy(from, to, false);
        public static void copy(string from, string to, bool overwrite) => File.Copy(from, to, overwrite);
        public static void writeAllText(string path, string content) => File.WriteAllText(path, content);
        public static void writeAllLines(string path, string[] content) => File.WriteAllLines(path, content);
        public static void writeAllBytes(string path, byte[] buffer) => File.WriteAllBytes(path, buffer);
        public static void appendAllLines(string path, string[] content) => File.AppendAllLines(path, content);
        public static void appendAllText(string path, string content) => File.AppendAllText(path, content);
        public static string readAllText(string path) => File.ReadAllText(path);
        public static string[] readAllLines(string path) => File.ReadAllLines(path);
        public static byte[] readAllBytes(string path) => File.ReadAllBytes(path);
        public static void create(string path) => File.Create(path);
    }
}
