using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using MoonSharp.Interpreter.Interop;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.Internal.Lua.Net {
    public class LuaWebClient {
        [MoonSharpVisible(false)]
        private readonly WebClient _webClient;

        [MoonSharpVisible(false)]
        public WebClient GetWebClient() => _webClient;


        public LuaWebClient() {
            _webClient = new WebClient();
        }

        /*public string query_string {
            get => _webClient.QueryString;
            set => _webClient.BaseAddress = value;
        }*/

        public Dictionary<string, string> response_headers => _webClient.ResponseHeaders.Keys.Cast<string>().ToDictionary(key => key, key => _webClient.ResponseHeaders.Get(key));

        public bool use_default_credentials {
            get => _webClient.UseDefaultCredentials;
            set => _webClient.UseDefaultCredentials = value;
        }

        public bool isBusy => _webClient.IsBusy;

        /*public string credentials {
            get => _webClient.Credentials;
            set => _webClient.BaseAddress = value;
        }

        public string headers {
            get => _webClient.Headers;
            set => _webClient.BaseAddress = value;
        }*/

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

        public void dispose() => _webClient.Dispose();
    }
}
