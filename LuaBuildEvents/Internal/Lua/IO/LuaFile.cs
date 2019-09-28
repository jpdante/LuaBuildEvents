using System.IO;

// ReSharper disable InconsistentNaming

namespace LuaBuildEvents.Internal.Lua.IO {
    public class LuaFile {
        public static bool exists(string path) => File.Exists(path);
        public static void delete(string path) => File.Delete(path);
        public static void move(string from, string to, bool overwrite = false) => File.Move(from, to, overwrite);
        public static void copy(string from, string to, bool overwrite = false) => File.Copy(from, to, overwrite);
        public static void write_all_text(string path, string content) => File.WriteAllText(path, content);
        public static void write_all_lines(string path, string[] content) => File.WriteAllLines(path, content);
        public static void write_all_bytes(string path, byte[] buffer) => File.WriteAllBytes(path, buffer);
        public static void append_all_lines(string path, string[] content) => File.AppendAllLines(path, content);
        public static void append_all_text(string path, string content) => File.AppendAllText(path, content);
        public static string read_all_text(string path) => File.ReadAllText(path);
        public static string[] read_all_lines(string path) => File.ReadAllLines(path);
        public static byte[] read_all_bytes(string path) => File.ReadAllBytes(path);
        public static void create(string path) => File.Create(path);
    }
}
