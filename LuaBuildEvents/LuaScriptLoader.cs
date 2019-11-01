using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Loaders;

namespace LuaBuildEvents {
    public class LuaScriptLoader : ScriptLoaderBase {
        public readonly List<Assembly> ResourceAssemblies;
        private readonly List<string> _namespaces;
        private readonly HashSet<string> _resourceNames;

        public LuaScriptLoader() {
            ResourceAssemblies = new List<Assembly> {Assembly.GetExecutingAssembly()};
            _namespaces = new List<string> {ResourceAssemblies[0].FullName.Split(',').First()};
            _resourceNames = new HashSet<string>(ResourceAssemblies[0].GetManifestResourceNames());
        }

        public void AddAssembly(Assembly assembly) {
            ResourceAssemblies.Add(assembly);
            _namespaces.Add(assembly.FullName.Split(',').First());
            foreach (var resource in assembly.GetManifestResourceNames()) {
                _resourceNames.Add(resource);
            }
        }

        private string FileNameToResource(string file) {
            file = file.Replace('/', '.');
            file = file.Replace('\\', '.');
            return _namespaces[0] + "." + file;
        }

        private static string FileNameToResource(string name, string file) {
            file = file.Replace('/', '.');
            file = file.Replace('\\', '.');
            return name + "." + file;
        }

        public override bool ScriptFileExists(string filename) {
            foreach (var name in _namespaces) {
                //Console.WriteLine(name + " - " + filename + Environment.NewLine);
                var assembly = ResourceAssemblies[_namespaces.IndexOf(name)];
                var pathName = FileNameToResource(name, filename);
                if (assembly.GetManifestResourceInfo(pathName) != null) return true;
            }
            return File.Exists(filename);
        }

        public override object LoadFile(string filename, Table globalContext) {
            foreach (var name in _namespaces) {
                var assembly = ResourceAssemblies[_namespaces.IndexOf(name)];
                var pathName = FileNameToResource(name, filename);
                if (assembly.GetManifestResourceInfo(pathName) != null) return assembly.GetManifestResourceStream(pathName);
            }
            return new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        }
    }
}
