using System;
using System.Net.Sockets;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.Internal.Lua.Net {
    public class LuaSocket {
        [MoonSharpVisible(false)]
        private readonly Socket _socket;

        [MoonSharpVisible(false)]
        public Socket GetSocket() {
            return _socket;
        }

        public LuaSocket(Socket socket) {
            _socket = socket;
        }

        public LuaSocket(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType) {
            _socket = new Socket(addressFamily, socketType, protocolType);
        }

        public LuaSocket(SocketType socketType, ProtocolType protocolType) {
            _socket = new Socket(socketType, protocolType);
        }

        public static LuaSocket create(string addressFamily, string socketType, string protocolType) {
            if (Enum.TryParse(addressFamily, out AddressFamily result1) &&
                Enum.TryParse(socketType, out SocketType result2) &&
                Enum.TryParse(protocolType, out ProtocolType result3)) {
                return new LuaSocket(result1, result2, result3);
            }

            throw new ScriptRuntimeException("Failed to parse Enums.");
        }

        public static LuaSocket create(string socketType, string protocolType) {
            if (Enum.TryParse(socketType, out SocketType result1) &&
                Enum.TryParse(protocolType, out ProtocolType result2)) {
                return new LuaSocket(result1, result2);
            }

            throw new ScriptRuntimeException("Failed to parse Enums.");
        }

        public int available => _socket.Available;

        public bool blocking {
            get => _socket.Blocking;
            set => _socket.Blocking = value;
        }

        public bool isConnected => _socket.Connected;

        public bool dont_fragment {
            get => _socket.DontFragment;
            set => _socket.DontFragment = value;
        }

        public bool dual_mode {
            get => _socket.DualMode;
            set => _socket.DualMode = value;
        }

        public bool enable_broadcast {
            get => _socket.EnableBroadcast;
            set => _socket.EnableBroadcast = value;
        }

        public bool isBound => _socket.IsBound;

        public bool multicast_loopback {
            get => _socket.MulticastLoopback;
            set => _socket.MulticastLoopback = value;
        }

        public bool no_delay {
            get => _socket.NoDelay;
            set => _socket.NoDelay = value;
        }

        public bool exclusive_address_use {
            get => _socket.ExclusiveAddressUse;
            set => _socket.ExclusiveAddressUse = value;
        }

        public bool use_only_overlapped_io {
            get => _socket.UseOnlyOverlappedIO;
            set => _socket.UseOnlyOverlappedIO = value;
        }

        public short ttl => _socket.Ttl;

        public string address_family => _socket.AddressFamily.ToString();

        public bool linger_state_enabled {
            get => _socket.LingerState.Enabled;
            set => _socket.LingerState.Enabled = value;
        }

        public int linger_state_linger_time {
            get => _socket.LingerState.LingerTime;
            set => _socket.LingerState.LingerTime = value;
        }

        public string protocol_type => _socket.ProtocolType.ToString();

        public int receive_timeout {
            get => _socket.ReceiveTimeout;
            set => _socket.ReceiveTimeout = value;
        }

        public int send_timeout {
            get => _socket.SendTimeout;
            set => _socket.SendTimeout = value;
        }

        public string socket_type => _socket.SocketType.ToString();

        public string local_end_point => _socket.LocalEndPoint.ToString();

        public string remote_end_point => _socket.RemoteEndPoint.ToString();

        public int send_buffer_size {
            get => _socket.SendBufferSize;
            set => _socket.SendBufferSize = value;
        }

        public int receive_buffer_size {
            get => _socket.ReceiveBufferSize;
            set => _socket.ReceiveBufferSize = value;
        }

        public LuaSocket accept() => new LuaSocket(_socket.Accept());
        public void bind() => _socket.Bind();
        public void close() => _socket.Close();
        public LuaSocket connect() => _socket.Connect();
        public LuaSocket disconnect() => _socket.Disconnect();
        public LuaSocket dispose() => _socket.Dispose();
        public LuaSocket listen() => _socket.Listen();

        public LuaSocket poll(int microSeconds, string selectMode) {
            _socket.Poll(microSeconds, selectMode);
        }

        public LuaSocket receive() => _socket.Receive();
        public LuaSocket send() => _socket.Send();
        public LuaSocket shutdown() => _socket.Shutdown();
        public LuaSocket receive_from() => _socket.ReceiveFrom();
        public LuaSocket send_file() => _socket.SendFile();
        public LuaSocket send_to() => _socket.SendTo();
        public LuaSocket io_control() => _socket.IOControl();
        public LuaSocket receive_message_from() => _socket.ReceiveMessageFrom();
        public LuaSocket set_ip_protection_level() => _socket.SetIPProtectionLevel();
        public LuaSocket set_socket_option() => _socket.SetSocketOption();
        public LuaSocket get_socket_option() => _socket.GetSocketOption();
    }
}