using System;
using System.Linq;
using System.Net.Sockets;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.net.sockets {
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

        public static LuaSocket New(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType) => new LuaSocket(addressFamily, socketType, protocolType);
        public static LuaSocket New(SocketType socketType, ProtocolType protocolType) => new LuaSocket(socketType, protocolType);

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

        public AddressFamily addressFamily => _socket.AddressFamily;

        public bool lingerStateEnabled {
            get => _socket.LingerState.Enabled;
            set => _socket.LingerState.Enabled = value;
        }

        public int lingerStateLingerTime {
            get => _socket.LingerState.LingerTime;
            set => _socket.LingerState.LingerTime = value;
        }

        public ProtocolType protocolType => _socket.ProtocolType;

        public int receiveTimeout {
            get => _socket.ReceiveTimeout;
            set => _socket.ReceiveTimeout = value;
        }

        public int sendTimeout {
            get => _socket.SendTimeout;
            set => _socket.SendTimeout = value;
        }

        public SocketType socketType => _socket.SocketType;

        public LuaEndPoint localEndPoint => new LuaEndPoint(_socket.LocalEndPoint);

        public LuaEndPoint remoteEndPoint => new LuaEndPoint(_socket.RemoteEndPoint);

        public int sendBufferSize {
            get => _socket.SendBufferSize;
            set => _socket.SendBufferSize = value;
        }

        public int receiveBufferSize {
            get => _socket.ReceiveBufferSize;
            set => _socket.ReceiveBufferSize = value;
        }

        public LuaSocket accept() => new LuaSocket(_socket.Accept());
        public void bind(LuaEndPoint endPoint) => _socket.Bind(endPoint.EndPoint);
        public void close() => _socket.Close();
        public void connect(LuaEndPoint endPoint) => _socket.Connect(endPoint.EndPoint);
        public void connect(LuaIPAddress address, int port) => _socket.Connect(address.GetIPAddress(), port);
        public void connect(LuaIPAddress[] addresses, int port) => _socket.Connect(addresses.Select(address => address.GetIPAddress()).ToArray(), port);
        public void connect(string host, int port) => _socket.Connect(host, port);
        public void disconnect() => _socket.Disconnect(false);
        public void disconnect(bool reuseSocket) => _socket.Disconnect(reuseSocket);
        public void dispose() => _socket.Dispose();
        public void listen(int backlog) => _socket.Listen(backlog);
        public void poll(int microSeconds, SelectMode selectMode) => _socket.Poll(microSeconds, selectMode);
        public int receive(byte[] buffer) => _socket.Receive(buffer);
        public int receive(byte[] buffer, int offset, int size, SocketFlags socketFlags) => _socket.Receive(buffer, offset, size, socketFlags);
        public int send(byte[] buffer) => _socket.Send(buffer);
        public int send(byte[] buffer, int offset, int size, SocketFlags socketFlags) => _socket.Send(buffer, offset, size, socketFlags);
        public void shutdown(SocketShutdown how) => _socket.Shutdown(how);
        public int receiveFrom(byte[] buffer, SocketFlags socketFlags, LuaEndPoint remoteEP) => _socket.ReceiveFrom(buffer, socketFlags, ref remoteEP.EndPoint);
        public int receiveFrom(byte[] buffer, int offset, int size, SocketFlags socketFlags, LuaEndPoint remoteEP) => _socket.ReceiveFrom(buffer, offset, size, socketFlags, ref remoteEP.EndPoint);
        public int receiveFrom(byte[] buffer, int size, SocketFlags socketFlags, LuaEndPoint remoteEP) => _socket.ReceiveFrom(buffer, size, socketFlags, ref remoteEP.EndPoint);
        public int receiveFrom(byte[] buffer, LuaEndPoint remoteEP) => _socket.ReceiveFrom(buffer, ref remoteEP.EndPoint);
        public void sendFile(string fileName) => _socket.SendFile(fileName);
        public void sendFile(string fileName, byte[] preBuffer, byte[] postBuffer, TransmitFileOptions transmitFileOptions) => _socket.SendFile(fileName, preBuffer, postBuffer, transmitFileOptions);
        public int sendTo(byte[] buffer, LuaEndPoint remoteEP) => _socket.SendTo(buffer, remoteEP.EndPoint);
        public int sendTo(byte[] buffer, SocketFlags socketFlags, LuaEndPoint remoteEP) => _socket.SendTo(buffer, socketFlags, remoteEP.EndPoint);
        public int sendTo(byte[] buffer, int offset, int size, SocketFlags socketFlags, LuaEndPoint remoteEP) => _socket.SendTo(buffer, offset, size, socketFlags, remoteEP.EndPoint);
        public int sendTo(byte[] buffer, int size, SocketFlags socketFlags, LuaEndPoint remoteEP) => _socket.SendTo(buffer, size, socketFlags, remoteEP.EndPoint);
        public int ioControl(IOControlCode controlCode, byte[] optionInValue, byte[] optionOutValue) => _socket.IOControl(controlCode, optionInValue, optionOutValue);
        public int ioControl(int controlCode, byte[] optionInValue, byte[] optionOutValue) => _socket.IOControl(controlCode, optionInValue, optionOutValue);
        public int receiveMessageFrom(byte[] buffer, int offset, int size, ref SocketFlags socketFlags, LuaEndPoint remoteEP, out IPPacketInformation packetInformation) => _socket.ReceiveMessageFrom(buffer, offset, size, ref socketFlags, ref remoteEP.EndPoint, out packetInformation);
        public void setIPProtectionLevel(IPProtectionLevel protectionLevel) => _socket.SetIPProtectionLevel(protectionLevel);
        public void setSocketOption(SocketOptionLevel socketOptionLevel, SocketOptionName socketOptionName, bool optionValue) => _socket.SetSocketOption(socketOptionLevel, socketOptionName, optionValue);
        public void setSocketOption(SocketOptionLevel socketOptionLevel, SocketOptionName socketOptionName, byte[] optionValue) => _socket.SetSocketOption(socketOptionLevel, socketOptionName, optionValue);
        public void setSocketOption(SocketOptionLevel socketOptionLevel, SocketOptionName socketOptionName, int optionValue) => _socket.SetSocketOption(socketOptionLevel, socketOptionName, optionValue);
        public void setSocketOption(SocketOptionLevel socketOptionLevel, SocketOptionName socketOptionName, object optionValue) => _socket.SetSocketOption(socketOptionLevel, socketOptionName, optionValue);
        public string getSocketOption(SocketOptionLevel socketOptionLevel, SocketOptionName socketOptionName) => _socket.GetSocketOption(socketOptionLevel, socketOptionName).ToString();

        // TODO: Async

        // TODO: BEGIN, END
    }
}