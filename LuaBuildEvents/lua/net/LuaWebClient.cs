using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.net {
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

        public static LuaWebClient New() => new LuaWebClient();

        public NameValueCollection queryString => _webClient.QueryString;

        public Dictionary<string, string> responseHeaders => _webClient.ResponseHeaders.Keys.Cast<string>().ToDictionary(key => key, key => _webClient.ResponseHeaders.Get(key));

        public bool useDefaultCredentials {
            get => _webClient.UseDefaultCredentials;
            set => _webClient.UseDefaultCredentials = value;
        }

        public bool isBusy => _webClient.IsBusy;

        public LuaICredentials credentials {
            get => new LuaICredentials(_webClient.Credentials);
            set => _webClient.Credentials = value.GetCredentials();
        }

        public LuaWebClientHeader headers { get; }

        public string cachePolicyLevel {
            get => _webClient.CachePolicy?.Level.ToString();
            set {
                if (Enum.TryParse(value, out RequestCacheLevel result)) {
                    _webClient.CachePolicy = new RequestCachePolicy(result);
                }
            }
        }

        public string baseAddress {
            get => _webClient.BaseAddress;
            set => _webClient.BaseAddress = value;
        }

        public string encoding {
            get => _webClient.Encoding?.ToString();
            set => _webClient.Encoding = Encoding.GetEncoding(value);
        }

        public byte[] downloadData(string uri) => _webClient.DownloadData(uri);
        public void downloadFile(string uri, string fileName) => _webClient.DownloadFile(uri, fileName);
        public string downloadString(string uri) => _webClient.DownloadString(uri);
        public byte[] uploadData(string uri, byte[] data) => _webClient.UploadData(uri, data);
        public byte[] uploadData(string uri, string method, byte[] data) => _webClient.UploadData(uri, method, data);
        public byte[] uploadFile(string uri, string fileName) => _webClient.UploadFile(uri, fileName);
        public byte[] uploadFile(string uri, string method, string fileName) => _webClient.UploadFile(uri, method, fileName);
        public string uploadString(string uri, string data) => _webClient.UploadString(uri, data);
        public string uploadString(string uri, string method, string data) => _webClient.UploadString(uri, method, data);
        public byte[] uploadValues(string uri, NameValueCollection data) => _webClient.UploadValues(uri, data);
        public byte[] uploadValues(string uri, string method, NameValueCollection data) => _webClient.UploadValues(uri, method, data);
        public void openRead(string uri) => _webClient.OpenRead(uri);
        public void openWrite(string uri) => _webClient.OpenWrite(uri);
        public void dispose() => _webClient.Dispose();
    }
}
