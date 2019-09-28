using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
// ReSharper disable InconsistentNaming

namespace LuaBuildEvents.Internal.Lua {
    public class LuaDirectory {
        public static bool exists(string path) => Directory.Exists(path);
        public static void delete(string path) => Directory.Delete(path);
        public static void move(string from, string to) => Directory.Move(from, to);
        public static string get_current_directory() => Directory.GetCurrentDirectory();
        public static void create_directory(string path) => Directory.CreateDirectory(path);
        public static void get_files(string path, string pattern = "*.*", bool topOnly = false) => Directory.GetFiles(path, pattern, topOnly ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
        public static void get_directories(string path, string pattern = "*.*", bool topOnly = false) => Directory.GetDirectories(path, "*.*", topOnly ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
    }
}
