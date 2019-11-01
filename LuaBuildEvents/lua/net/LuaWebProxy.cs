using System.Collections;
using System.Collections.Generic;
using System.Net;
using LuaBuildEvents.lua.system;
using MoonSharp.Interpreter.Interop;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.net {
    public class LuaWebProxy {
        [MoonSharpVisible(false)] 
        private readonly WebProxy _webProxy;

        [MoonSharpVisible(false)]
        public WebProxy GetWebProxy() => _webProxy;

        public LuaWebProxy(LuaUri uri) {
            _webProxy = new WebProxy(uri.GetUri());
        }

        public LuaWebProxy(LuaUri uri, bool bypassOnLocal) {
            _webProxy = new WebProxy(uri.GetUri(), bypassOnLocal);
        }

        public LuaWebProxy(LuaUri uri, bool bypassOnLocal, string[] bypassList) {
            _webProxy = new WebProxy(uri.GetUri(), bypassOnLocal, bypassList);
        }

        public LuaWebProxy(LuaUri uri, bool bypassOnLocal, string[] bypassList, LuaICredentials credentials) {
            _webProxy = new WebProxy(uri.GetUri(), bypassOnLocal, bypassList, credentials.GetCredentials());
        }

        public LuaWebProxy(WebProxy webProxy) {
            _webProxy = webProxy;
        }

        public static LuaWebProxy New(LuaUri uri) => new LuaWebProxy(uri);
        public static LuaWebProxy New(LuaUri uri, bool bypassOnLocal) => new LuaWebProxy(uri, bypassOnLocal);
        public static LuaWebProxy New(LuaUri uri, bool bypassOnLocal, string[] bypassList) => new LuaWebProxy(uri, bypassOnLocal, bypassList);
        public static LuaWebProxy New(LuaUri uri, bool bypassOnLocal, string[] bypassList, LuaICredentials credentials) => new LuaWebProxy(uri, bypassOnLocal, bypassList, credentials);

        public LuaICredentials credentials {
            get => new LuaICredentials(_webProxy.Credentials);
            set => _webProxy.Credentials = value.GetCredentials();
        }

        public LuaUri address {
            get => new LuaUri(_webProxy.Address);
            set => _webProxy.Address = value.GetUri();
        }

        public ArrayList bypassArrayList => _webProxy.BypassArrayList;

        public string[] bypassList {
            get => _webProxy.BypassList;
            set => _webProxy.BypassList = value;
        }

        public bool bypassProxyOnLocal {
            get => _webProxy.BypassProxyOnLocal;
            set => _webProxy.BypassProxyOnLocal = value;
        }

        public bool useDefaultCredentials {
            get => _webProxy.UseDefaultCredentials;
            set => _webProxy.UseDefaultCredentials = value;
        }

        public bool isBypassed(LuaUri uri) => _webProxy.IsBypassed(uri.GetUri());
        public LuaUri getProxy(LuaUri uri) => new LuaUri(_webProxy.GetProxy(uri.GetUri()));
    }
}