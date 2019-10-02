using System.IO;

// ReSharper disable InconsistentNaming

namespace LuaBuildEvents.Internal.Lua.IO {
    public class LuaPath {
        public static string combine(string path, string path2) => Path.Combine(path, path2);
        public static string get_full_path(string path) => Path.GetFullPath(path);
    }
}
