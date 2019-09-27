using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
// ReSharper disable InconsistentNaming

namespace LuaBuildEvents.Internal.Lua {
    public class LuaFile {
        public bool exists(string path) => File.Exists(path);
        public void delete(string path) => File.Delete(path);
        public void move(string from, string to, bool overwrite = false) => File.Move(from, to, overwrite);
        public void copy(string from, string to, bool overwrite = false) => File.Copy(from, to, overwrite);
        public void write_all_text(string path, string content) => File.WriteAllText(path, content);
        public void write_all_lines(string path, string[] content) => File.WriteAllLines(path, content);
        public void write_all_bytes(string path, byte[] buffer) => File.WriteAllBytes(path, buffer);
        public void append_all_lines(string path, string[] content) => File.AppendAllLines(path, content);
        public void append_all_text(string path, string content) => File.AppendAllText(path, content);
        public string read_all_text(string path) => File.ReadAllText(path);
        public string[] read_all_lines(string path) => File.ReadAllLines(path);
        public byte[] read_all_bytes(string path) => File.ReadAllBytes(path);
        public void create(string path) => File.Create(path);
    }
}
