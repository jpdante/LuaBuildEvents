using System.IO;

// ReSharper disable InconsistentNaming

namespace LuaBuildEvents.Internal.Lua.IO {
    public class LuaDirectory {
        public static bool exists(string path) => Directory.Exists(path);
        public static void delete(string path) => Directory.Delete(path);
        public static void move(string from, string to) => Directory.Move(from, to);
        public static string getCurrentDirectory() => Directory.GetCurrentDirectory();
        public static void createDirectory(string path) => Directory.CreateDirectory(path);
        public static string[] getFiles(string path) => getFiles(path, "*.*", false);
        public static string[] getFiles(string path, string pattern) => getFiles(path, pattern, false);
        public static string[] getFiles(string path, string pattern, bool topOnly) => Directory.GetFiles(path, pattern, topOnly ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
        public static string[] getDirectories(string path) => getDirectories(path, "*.*", false);
        public static string[] getDirectories(string path, string pattern) => getDirectories(path, pattern, false);
        public static string[] getDirectories(string path, string pattern, bool topOnly) => Directory.GetDirectories(path, "*.*", topOnly ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
    }
}
