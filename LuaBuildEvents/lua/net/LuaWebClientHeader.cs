using System;
using System.Net;
using MoonSharp.Interpreter;

namespace LuaBuildEvents.lua.net {
    public class LuaWebClientHeader {
        private readonly WebHeaderCollection _collection;
        
        public LuaWebClientHeader(WebHeaderCollection collection) { _collection = collection; }

        public string this[string key] {
            get => _collection[key];
            set => _collection[key] = value;
        }

        public void clear() {
            _collection.Clear();
        }

        public void add(string header, string value) {
            if (Enum.TryParse(header, out HttpRequestHeader result)) {
                _collection.Add(result, value);
            } else {
                throw new ScriptRuntimeException("Invalid HttpRequestHeader.");
            }
        }

        public string get(int index) => _collection.Get(index);
        public string get(string name) => _collection.Get(name);
        public string getKey(int index) => _collection.GetKey(index);
        public string[] getValues(int index) => _collection.GetValues(index);
        public string[] getValues(string name) => _collection.GetValues(name);

        public void remove(string name) {
            if (Enum.TryParse(name, out HttpRequestHeader result)) {
                _collection.Remove(result);
            } else {
                if (Enum.TryParse(name, out HttpResponseHeader result2)) {
                    _collection.Remove(result2);
                } else {
                    throw new ScriptRuntimeException("Invalid HttpRequestHeader.");
                }
            }
        }

        public void set(string name, string value) {
            if (Enum.TryParse(name, out HttpRequestHeader result)) {
                _collection.Set(result, value);
            } else {
                if (Enum.TryParse(name, out HttpResponseHeader result2)) {
                    _collection.Set(result2, value);
                } else {
                    throw new ScriptRuntimeException("Invalid HttpRequestHeader.");
                }
            }
        }
    }
}