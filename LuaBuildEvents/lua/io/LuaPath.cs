using System.IO;

// ReSharper disable InconsistentNaming

namespace LuaBuildEvents.lua.io {
    public static class LuaPath {
        // TODO: FIX
        public static string combine(params string[] path) => Path.Combine(path);
        public static string get_full_path(string path) => Path.GetFullPath(path);
    }
}
