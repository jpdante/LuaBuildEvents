using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using LuaBuildEvents.lua.system;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.net {
    public class LuaWebClient {
        [MoonSharpVisible(false)]
        private readonly WebClient _webClient;

        [MoonSharpVisible(false)]
        public WebClient GetWebClient() => _webClient;

        public LuaWebClient() {
            _webClient = new WebClient();
            _webClient.DownloadDataCompleted += WebClientOnDownloadDataCompleted;
            _webClient.DownloadFileCompleted += WebClientOnDownloadFileCompleted;
            _webClient.DownloadProgressChanged += WebClientOnDownloadProgressChanged;
            _webClient.DownloadStringCompleted += WebClientOnDownloadStringCompleted;
            _webClient.OpenReadCompleted += WebClientOnOpenReadCompleted;
            _webClient.OpenWriteCompleted += WebClientOnOpenWriteCompleted;
            _webClient.UploadDataCompleted += WebClientOnUploadDataCompleted;
            _webClient.UploadFileCompleted += WebClientOnUploadFileCompleted;
            _webClient.UploadProgressChanged += WebClientOnUploadProgressChanged;
            _webClient.UploadStringCompleted += WebClientOnUploadStringCompleted;
            _webClient.UploadValuesCompleted += WebClientOnUploadValuesCompleted;
            _webClient.Disposed += WebClientOnDisposed;
            headers = new LuaWebClientHeader(_webClient.Headers);
        }

        public static LuaWebClient New() => new LuaWebClient();

        #region Events
        public event EventHandler onDownloadDataCompleted;
        public event EventHandler onDownloadFileCompleted;
        public event EventHandler onDownloadProgressChanged;
        public event EventHandler onDownloadStringCompleted;

        public event EventHandler onOpenReadCompleted;
        public event EventHandler onOpenWriteCompleted;

        public event EventHandler onUploadDataCompleted;
        public event EventHandler onUploadFileCompleted;
        public event EventHandler onUploadProgressChanged;
        public event EventHandler onUploadStringCompleted;
        public event EventHandler onUploadValuesCompleted;

        public event EventHandler onDisposed;

        [MoonSharpVisible(false)]
        private void WebClientOnDownloadFileCompleted(object sender, AsyncCompletedEventArgs e) { onDownloadDataCompleted?.Invoke(this, e); }
        [MoonSharpVisible(false)]
        private void WebClientOnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) { onDownloadFileCompleted?.Invoke(this, e); }
        [MoonSharpVisible(false)]
        private void WebClientOnDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e) { onDownloadProgressChanged?.Invoke(this, e); }
        [MoonSharpVisible(false)]
        private void WebClientOnDownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e) { onDownloadStringCompleted?.Invoke(this, e); }

        [MoonSharpVisible(false)]
        private void WebClientOnOpenReadCompleted(object sender, OpenReadCompletedEventArgs e) { onOpenReadCompleted?.Invoke(this, e); }
        [MoonSharpVisible(false)]
        private void WebClientOnOpenWriteCompleted(object sender, OpenWriteCompletedEventArgs e) { onOpenWriteCompleted?.Invoke(this, e); }
        
        [MoonSharpVisible(false)]
        private void WebClientOnUploadDataCompleted(object sender, UploadDataCompletedEventArgs e) { onUploadDataCompleted?.Invoke(this, e); }
        [MoonSharpVisible(false)]
        private void WebClientOnUploadFileCompleted(object sender, UploadFileCompletedEventArgs e) { onUploadFileCompleted?.Invoke(this, e); }
        [MoonSharpVisible(false)]
        private void WebClientOnUploadProgressChanged(object sender, UploadProgressChangedEventArgs e) { onUploadProgressChanged?.Invoke(this, e); }
        [MoonSharpVisible(false)]
        private void WebClientOnUploadStringCompleted(object sender, UploadStringCompletedEventArgs e) { onUploadStringCompleted?.Invoke(this, e); }
        [MoonSharpVisible(false)]
        private void WebClientOnUploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e) { onUploadValuesCompleted?.Invoke(this, e); }

        private void WebClientOnDisposed(object sender, EventArgs e) { onDisposed?.Invoke(this, e); }
        #endregion

        #region Variables
        public NameValueCollection queryString => _webClient.QueryString;

        public Dictionary<string, string> responseHeaders => _webClient.ResponseHeaders.Keys.Cast<string>().ToDictionary(key => key, key => _webClient.ResponseHeaders.Get(key));

        public bool useDefaultCredentials {
            get => _webClient.UseDefaultCredentials;
            set => _webClient.UseDefaultCredentials = value;
        }

        public bool isBusy => _webClient.IsBusy;

        public LuaWebProxy proxy {
            get => new LuaWebProxy((WebProxy)_webClient.Proxy);
            set => _webClient.Proxy = value.GetWebProxy();
        }

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
        #endregion

        #region Async
        public void downloadDataAsync(LuaUri uri) => _webClient.DownloadDataAsync(uri.GetUri());
        public void downloadDataAsync(LuaUri uri, object obj) => _webClient.DownloadDataAsync(uri.GetUri(), obj);

        public void downloadFileAsync(LuaUri uri, string fileName) => _webClient.DownloadFileAsync(uri.GetUri(), fileName);
        public void downloadFileAsync(LuaUri uri, string fileName, object obj) => _webClient.DownloadFileAsync(uri.GetUri(), fileName, obj);

        public void downloadStringAsync(LuaUri uri) => _webClient.DownloadStringAsync(uri.GetUri());
        public void downloadStringAsync(LuaUri uri, object obj) => _webClient.DownloadStringAsync(uri.GetUri(), obj);

        public void uploadDataAsync(LuaUri uri, byte[] data) => _webClient.UploadDataAsync(uri.GetUri(), data);
        public void uploadDataAsync(LuaUri uri, string method, byte[] data) => _webClient.UploadDataAsync(uri.GetUri(), method, data);
        public void uploadDataAsync(LuaUri uri, string method, byte[] data, object obj) => _webClient.UploadDataAsync(uri.GetUri(), method, data, obj);

        public void uploadFileAsync(LuaUri uri, string fileName) => _webClient.UploadFileAsync(uri.GetUri(), fileName);
        public void uploadFileAsync(LuaUri uri, string method, string fileName) => _webClient.UploadFileAsync(uri.GetUri(), method, fileName);
        public void uploadFileAsync(LuaUri uri, string method, string fileName, object obj) => _webClient.UploadFileAsync(uri.GetUri(), method, fileName, obj);

        public void uploadStringAsync(LuaUri uri, string data) => _webClient.UploadStringAsync(uri.GetUri(), data);
        public void uploadStringAsync(LuaUri uri, string method, string data) => _webClient.UploadStringAsync(uri.GetUri(), method, data);
        public void uploadStringAsync(LuaUri uri, string method, string data, object obj) => _webClient.UploadStringAsync(uri.GetUri(), method, data, obj);

        public void uploadStringAsync(LuaUri uri, NameValueCollection data) => _webClient.UploadValuesAsync(uri.GetUri(), data);
        public void uploadStringAsync(LuaUri uri, string method, NameValueCollection data) => _webClient.UploadValuesAsync(uri.GetUri(), method, data);
        public void uploadStringAsync(LuaUri uri, string method, NameValueCollection data, object obj) => _webClient.UploadValuesAsync(uri.GetUri(), method, data, obj);

        public void openReadAsync(LuaUri uri) => _webClient.OpenReadAsync(uri.GetUri());
        public void openReadAsync(LuaUri uri, object obj) => _webClient.OpenReadAsync(uri.GetUri(), obj);

        public void openWriteAsync(LuaUri uri) => _webClient.OpenWriteAsync(uri.GetUri());
        public void openWriteAsync(LuaUri uri, string method) => _webClient.OpenWriteAsync(uri.GetUri(), method);
        public void openWriteAsync(LuaUri uri, string method, object obj) => _webClient.OpenWriteAsync(uri.GetUri(), method, obj);

        public void cancelAsync() => _webClient.CancelAsync();
        #endregion

        #region Sync
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
        #endregion

        public void dispose() => _webClient.Dispose();
    }
}
