using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MoonSharp.Interpreter.Interop;
using YamlDotNet.RepresentationModel;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.config {
    public class LuaFastConfig : IDisposable {

        [MoonSharpVisible(false)]
        private readonly FileStream _fileStream;
        [MoonSharpVisible(false)]
        private readonly StreamReader _streamReader;
        [MoonSharpVisible(false)]
        private readonly StreamWriter _streamWriter;
        [MoonSharpVisible(false)]
        private readonly YamlStream _yamlStream;

        public LuaFastConfig(string fileName) {
            _yamlStream = new YamlStream();
            _fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
            _streamReader = new StreamReader(_fileStream);
            _streamWriter = new StreamWriter(_fileStream);
        }

        public static LuaFastConfig New(string filename) => new LuaFastConfig(filename);

        public string[] getKeys(string path) {
            return GetKeys(_yamlStream.Documents[0], path);
        }

        public string getString(string path) {
            var data = (YamlScalarNode)GetNode(_yamlStream.Documents[0], path);
            return data?.Value;
        }

        public int getInt(string path) {
            var data = (YamlScalarNode)GetNode(_yamlStream.Documents[0], path);
            return int.Parse(data.Value);
        }

        public int getFloat(string path) {
            var data = (YamlScalarNode)GetNode(_yamlStream.Documents[0], path);
            return int.Parse(data.Value);
        }

        public int getDouble(string path) {
            var data = (YamlScalarNode)GetNode(_yamlStream.Documents[0], path);
            return int.Parse(data.Value);
        }

        public int getLong(string path) {
            var data = (YamlScalarNode)GetNode(_yamlStream.Documents[0], path);
            return int.Parse(data.Value);
        }

        public int getByte(string path) {
            var data = (YamlScalarNode)GetNode(_yamlStream.Documents[0], path);
            return int.Parse(data.Value);
        }

        public bool has(string path) {
            if (_yamlStream.Documents.Count <= 0) return false;
            return GetNode(_yamlStream.Documents[0], path) != null;
        }

        public void set(string path, object data) {
            if (_yamlStream.Documents.Count <= 0) {
                _yamlStream.Add(new YamlDocument(new YamlMappingNode()));
            }
            if (!(_yamlStream.Documents[0].RootNode is YamlMappingNode mappingNode)) {
                return;
            }
            var sections = new Queue<string>(path.Split('.', StringSplitOptions.RemoveEmptyEntries));
            while (sections.Count > 0) {
                var nextSection = sections.Dequeue();
                if (sections.Count == 0) {
                    var key = new YamlScalarNode(nextSection);
                    if (mappingNode.Children.ContainsKey(key)) {
                        mappingNode.Children.Remove(key);
                    }
                    mappingNode.Children.Add(nextSection, new YamlScalarNode(data.ToString()));
                } else {
                    var temp = new YamlMappingNode();
                    mappingNode.Children.Add(nextSection, temp);
                    mappingNode = temp;
                }
            }
        }

        public void load() {
            _yamlStream.Load(_streamReader);
        }

        public void save() {
            _fileStream.SetLength(0);
            _yamlStream.Save(_streamWriter, false);
            _streamWriter.Flush();
        }

        [MoonSharpVisible(false)]
        private static YamlNode GetNode(YamlDocument doc, string path) {
            if (!(doc.RootNode is YamlMappingNode mappingNode)) {
                return null;
            }
            var sections = new Queue<string>(path.Split('.', StringSplitOptions.RemoveEmptyEntries));
            while (sections.Count > 1) {
                var nextSection = sections.Dequeue();
                var key = new YamlScalarNode(nextSection);
                if (mappingNode == null || !mappingNode.Children.ContainsKey(key)) {
                    return null;
                }
                mappingNode = mappingNode[key] as YamlMappingNode;
            }
            try {
                return mappingNode?[new YamlScalarNode(sections.Dequeue())];
            } catch {
                return null;
            }
        }

        [MoonSharpVisible(false)]
        private static string[] GetKeys(YamlDocument doc, string path) {
            var list = new List<string>();
            if (!(doc.RootNode is YamlMappingNode mappingNode)) {
                return list.ToArray();
            }
            var sections = new Queue<string>(path.Split('.', StringSplitOptions.RemoveEmptyEntries));
            while (sections.Count > 0) {
                var nextSection = sections.Dequeue();
                var key = new YamlScalarNode(nextSection);
                if (mappingNode == null || !mappingNode.Children.ContainsKey(key)) {
                    return null;
                }
                mappingNode = mappingNode[key] as YamlMappingNode;
            }
            list.AddRange(mappingNode.Children.Select(node => node.Key.ToString()));
            return list.ToArray();
        }

        public void dispose() => Dispose(true);

        ~LuaFastConfig() {
            Dispose(false);
        }

        [MoonSharpVisible(false)]
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        [MoonSharpVisible(false)]
        protected virtual void Dispose(bool disposing) {
            if (!disposing) return;
            _streamWriter?.Dispose();
            _streamReader?.Dispose();
            _fileStream?.Dispose();
        }
    }
}
