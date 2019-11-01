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

        public bool dontFragment {
            get => _socket.DontFragment;
            set => _socket.DontFragment = value;
        }

        public bool dualMode {
            get => _socket.DualMode;
            set => _socket.DualMode = value;
        }

        public bool enableBroadcast {
            get => _socket.EnableBroadcast;
            set => _socket.EnableBroadcast = value;
        }

        public bool isBound => _socket.IsBound;

        public bool multicastLoopback {
            get => _socket.MulticastLoopback;
            set => _socket.MulticastLoopback = value;
        }

        public bool noDelay {
            get => _socket.NoDelay;
            set => _socket.NoDelay = value;
        }

        public bool exclusiveAddressUse {
            get => _socket.ExclusiveAddressUse;
            set => _socket.ExclusiveAddressUse = value;
        }

        public bool useOnlyOverlappedIO {
            get => _socket.UseOnlyOverlappedIO;
            set => _socket.UseOnlyOverlappedIO = value;
        }

        public short ttl => _socket.Ttl;

        public string addressFamily => _socket.AddressFamily.ToString();

        public bool lingerStateEnabled {
            get => _socket.LingerState.Enabled;
            set => _socket.LingerState.Enabled = value;
        }

        public int lingerStateLingerTime {
            get => _socket.LingerState.LingerTime;
            set => _socket.LingerState.LingerTime = value;
        }

        public string protocolType => _socket.ProtocolType.ToString();

        public int receiveTimeout {
            get => _socket.ReceiveTimeout;
            set => _socket.ReceiveTimeout = value;
        }

        public int sendTimeout {
            get => _socket.SendTimeout;
            set => _socket.SendTimeout = value;
        }

        public string socketType => _socket.SocketType.ToString();

        public string localEndPoint => _socket.LocalEndPoint.ToString();

        public string remoteEndPoint => _socket.RemoteEndPoint.ToString();

        public int sendBufferSize {
            get => _socket.SendBufferSize;
            set => _socket.SendBufferSize = value;
        }

        public int receiveBufferSize {
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
        public LuaSocket receiveFrom() => _socket.ReceiveFrom();
        public LuaSocket sendFile() => _socket.SendFile();
        public LuaSocket sendTo() => _socket.SendTo();
        public LuaSocket ioControl() => _socket.IOControl();
        public LuaSocket receiveMessageFrom() => _socket.ReceiveMessageFrom();
        public LuaSocket setIPProtectionLevel() => _socket.SetIPProtectionLevel();
        public LuaSocket setSocketOption() => _socket.SetSocketOption();
        public LuaSocket getSocketOption() => _socket.GetSocketOption();
    }
}