using System;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.system {
    public class LuaUri {

        private readonly Uri _uri;

        public Uri GetUri() => _uri;

        public LuaUri(LuaUri baseUri, LuaUri relativeUri) { _uri = new Uri(baseUri.GetUri(), relativeUri.GetUri()); }
        public LuaUri(string uriString) { _uri = new Uri(uriString); }
        public LuaUri(Uri uri) { _uri = uri; }
    }
}