using System;
using System.Net;
using LuaBuildEvents.lua.system;
using MoonSharp.Interpreter.Interop;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.net {
    public class LuaCredentialCache : LuaICredentials {

        [MoonSharpVisible(false)]
        private readonly CredentialCache _credentialCache;

        [MoonSharpVisible(false)]
        public CredentialCache GetCredentialCache() => _credentialCache;

        private LuaCredentialCache() {
            _credentialCache = new CredentialCache();
            SetCredentials(_credentialCache);
        }

        public static LuaCredentialCache New() => new LuaCredentialCache();

        public void add(LuaUri uri, string authenticationType, LuaNetworkCredential credential) => _credentialCache.Add(uri.GetUri(), authenticationType, credential.GetNetworkCredential());
        public void add(string host, int port, string authenticationType, LuaNetworkCredential credential) => _credentialCache.Add(host, port, authenticationType, credential.GetNetworkCredential());
        public LuaNetworkCredential getCredential(LuaUri uri, string authenticationType) => new LuaNetworkCredential(_credentialCache.GetCredential(uri.GetUri(), authenticationType));
        public LuaNetworkCredential getCredential(string host, int port, string authenticationType) => new LuaNetworkCredential(_credentialCache.GetCredential(host, port, authenticationType));
        public void remove(LuaUri uri, string authenticationType) => _credentialCache.Remove(uri.GetUri(), authenticationType);
        public void remove(string host, int port, string authenticationType) => _credentialCache.Remove(host, port, authenticationType);
    }
}