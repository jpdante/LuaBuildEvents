using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.Internal.Lua.Net {
    // TODO: Add support for async and events
    public class LuaWebClient {
        [MoonSharpVisible(false)]
        private readonly WebClient _webClient;

        [MoonSharpVisible(false)]
        public WebClient GetWebClient() => _webClient;


        public LuaWebClient() {
            _webClient = new WebClient();
            headers = new LuaWebClientHeader(_webClient.Headers);
        }

        public NameValueCollection query_string => _webClient.QueryString;

        public Dictionary<string, string> response_headers => _webClient.ResponseHeaders.Keys.Cast<string>().ToDictionary(key => key, key => _webClient.ResponseHeaders.Get(key));

        public bool use_default_credentials {
            get => _webClient.UseDefaultCredentials;
            set => _webClient.UseDefaultCredentials = value;
        }

        public bool isBusy => _webClient.IsBusy;

        // TODO: Add support for credentials later

        /*public string credentials {
            get => _webClient.Credentials;
            set => _webClient.Credentials;
        }*/

        public LuaWebClientHeader headers { get; }

        public string cache_policy_level {
            get => _webClient.CachePolicy?.Level.ToString();
            set {
                if (Enum.TryParse(value, out RequestCacheLevel result)) {
                    _webClient.CachePolicy = new RequestCachePolicy(result);
                }
            }
        }

        public string base_address {
            get => _webClient.BaseAddress;
            set => _webClient.BaseAddress = value;
        }

        public string encoding {
            get => _webClient.Encoding?.ToString();
            set => _webClient.Encoding = Encoding.GetEncoding(value);
        }

        public byte[] download_data(string uri) => _webClient.DownloadData(uri);
        public void download_file(string uri, string fileName) => _webClient.DownloadFile(uri, fileName);
        public string download_string(string uri) => _webClient.DownloadString(uri);
        public byte[] upload_data(string uri, byte[] data) => _webClient.UploadData(uri, data);
        public byte[] upload_data(string uri, string method, byte[] data) => _webClient.UploadData(uri, method, data);
        public byte[] upload_file(string uri, string fileName) => _webClient.UploadFile(uri, fileName);
        public byte[] upload_file(string uri, string method, string fileName) => _webClient.UploadFile(uri, method, fileName);
        public string upload_string(string uri, string data) => _webClient.UploadString(uri, data);
        public string upload_string(string uri, string method, string data) => _webClient.UploadString(uri, method, data);
        public byte[] upload_values(string uri, NameValueCollection data) => _webClient.UploadValues(uri, data);
        public byte[] upload_values(string uri, string method, NameValueCollection data) => _webClient.UploadValues(uri, method, data);
        public void open_read(string uri) => _webClient.OpenRead(uri);
        public void open_write(string uri) => _webClient.OpenWrite(uri);
        public void dispose() => _webClient.Dispose();
    }

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
        public string get_key(int index) => _collection.GetKey(index);
        public string[] get_values(int index) => _collection.GetValues(index);
        public string[] get_values(string name) => _collection.GetValues(name);

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
