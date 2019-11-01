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

        public static LuaUri New(LuaUri baseUri, LuaUri relativeUri) => new LuaUri(baseUri, relativeUri);
        public static LuaUri New(string uriString) => new LuaUri(uriString);

        #region Variables
        public int port => _uri.Port;
        public string absolutePath => _uri.AbsolutePath;
        public string absoluteUri => _uri.AbsoluteUri;
        public string authority => _uri.Authority;
        public string dnsSafeHost => _uri.DnsSafeHost;
        public string fragment => _uri.Fragment;
        public string host => _uri.Host;
        public UriHostNameType hostNameType => _uri.HostNameType;
        public string idnHost => _uri.IdnHost;
        public bool isAbsoluteUri => _uri.IsAbsoluteUri;
        public bool isDefaultPort => _uri.IsDefaultPort;
        public bool isFile => _uri.IsFile;
        public bool isLoopback => _uri.IsLoopback;
        public bool isUnc => _uri.IsUnc;
        public string userInfo => _uri.UserInfo;
        public bool userEscaped => _uri.UserEscaped;
        public string[] segments => _uri.Segments;
        public string scheme => _uri.Scheme;
        public string query => _uri.Query;
        public string pathAndQuery => _uri.PathAndQuery;
        public string originalString => _uri.OriginalString;
        public string localPath => _uri.LocalPath;
        #endregion

        #region Sync
        public LuaUri makeRelativeUri(LuaUri uri) => new LuaUri(_uri.MakeRelativeUri(uri._uri));
        public bool isWellFormedOriginalString() => _uri.IsWellFormedOriginalString();
        public bool isBaseOf(LuaUri uri) => _uri.IsBaseOf(uri._uri);
        public string getLeftPart(UriPartial partial) => _uri.GetLeftPart(partial);
        #endregion
    }
}