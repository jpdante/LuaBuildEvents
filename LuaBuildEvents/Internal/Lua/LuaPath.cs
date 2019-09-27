using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
// ReSharper disable InconsistentNaming

namespace LuaBuildEvents.Internal.Lua {
    public class LuaPath {
        public string combine(string path, string path2) => Path.Combine(path, path2);
        public string get_full_path(string path) => Path.GetFullPath(path);
    }
}
