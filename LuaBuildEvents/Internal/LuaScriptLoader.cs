using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Loaders;

namespace LuaBuildEvents.Internal {
    public class LuaScriptLoader : ScriptLoaderBase {
        private readonly Assembly _resourceAssembly;
        private readonly HashSet<string> _resourceNames;
        private readonly string _namespace;

        public LuaScriptLoader() {
            _resourceAssembly = Assembly.GetExecutingAssembly();
            _namespace = _resourceAssembly.FullName.Split(',').First();
            _resourceNames = new HashSet<string>(_resourceAssembly.GetManifestResourceNames());
        }

        private string FileNameToResource(string file) {
            file = file.Replace('/', '.');
            file = file.Replace('\\', '.');
            return _namespace + "." + file;
        }

        public override bool ScriptFileExists(string name) {
            return _resourceNames.Contains(FileNameToResource(name)) || File.Exists(name);
        }

        public override object LoadFile(string file, Table globalContext) {
            var resourceFile = FileNameToResource(file);
            return _resourceNames.Contains(resourceFile) ? _resourceAssembly.GetManifestResourceStream(resourceFile) : new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        }
    }
}
