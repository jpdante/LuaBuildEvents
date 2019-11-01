using System.Net;
using System.Net.Sockets;
using MoonSharp.Interpreter.Interop;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.net {
    public class LuaIPAddress : LuaBridgeScript {
        [MoonSharpVisible(false)]
        private readonly IPAddress _ipAddress;

        [MoonSharpVisible(false)]
        public IPAddress GetIPAddress() {
            return _ipAddress;
        }

        public LuaIPAddress(IPAddress ipAddress) { _ipAddress = ipAddress; }

        public AddressFamily addressFamily => _ipAddress.AddressFamily;
        public bool isIPv4MappedToIPv6 => _ipAddress.IsIPv4MappedToIPv6;
        public bool isIPv6LinkLocal => _ipAddress.IsIPv6LinkLocal;
        public bool isIPv6Multicast => _ipAddress.IsIPv6Multicast;
        public bool isIPv6SiteLocal => _ipAddress.IsIPv6SiteLocal;
        public bool isIPv6Teredo => _ipAddress.IsIPv6Teredo;

        public long scopeID {
            get => _ipAddress.ScopeId;
            set => _ipAddress.ScopeId = value;
        }

        public LuaIPAddress New(byte[] address) => new LuaIPAddress(new IPAddress(address));
        public LuaIPAddress New(byte[] address, long scope) => new LuaIPAddress(new IPAddress(address, scope));
        public LuaIPAddress New(string ipString) => new LuaIPAddress(IPAddress.Parse(ipString));

        public static LuaIPAddress Any => new LuaIPAddress(IPAddress.Any);
        public static LuaIPAddress Broadcast => new LuaIPAddress(IPAddress.Broadcast);
        public static LuaIPAddress IPv6Any => new LuaIPAddress(IPAddress.IPv6Any);
        public static LuaIPAddress IPv6Loopback => new LuaIPAddress(IPAddress.IPv6Loopback);
        public static LuaIPAddress IPv6None => new LuaIPAddress(IPAddress.IPv6None);
        public static LuaIPAddress Loopback => new LuaIPAddress(IPAddress.Loopback);
        public static LuaIPAddress None => new LuaIPAddress(IPAddress.None);

        public static LuaIPAddress parse(string ipString) => new LuaIPAddress(IPAddress.Parse(ipString));
        
        public static bool tryParse(string ipString, out LuaIPAddress ipAddress) {
            var data = IPAddress.TryParse(ipString, out var address);
            ipAddress = new LuaIPAddress(address);
            return data;
        }

        public static short hostToNetworkOrder(short host) => IPAddress.HostToNetworkOrder(host);
        public static int hostToNetworkOrder(int host) => IPAddress.HostToNetworkOrder(host);
        public static long hostToNetworkOrder(long host) => IPAddress.HostToNetworkOrder(host);
        public static bool isLoopback(LuaIPAddress ipAddress) => IPAddress.IsLoopback(ipAddress.GetIPAddress());
        public static short networkToHostOrder(short network) => IPAddress.NetworkToHostOrder(network);
        public static int networkToHostOrder(int network) => IPAddress.NetworkToHostOrder(network);
        public static long networkToHostOrder(long network) => IPAddress.NetworkToHostOrder(network);
    }
}
