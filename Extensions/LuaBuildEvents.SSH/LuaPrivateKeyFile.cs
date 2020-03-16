using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LuaBuildEvents.lua.io;
using MoonSharp.Interpreter.Interop;
using Renci.SshNet;
using Renci.SshNet.Security;

namespace LuaBuildEvents.SSH {
    public class LuaPrivateKeyFile {

        [MoonSharpVisible(false)]
        private readonly PrivateKeyFile _privateKeyFile;

        [MoonSharpVisible(false)]
        public PrivateKeyFile GetPrivateKeyFile() => _privateKeyFile;

        public LuaPrivateKeyFile(Stream privateKey) {
            _privateKeyFile = new PrivateKeyFile(privateKey);
        }

        public LuaPrivateKeyFile(Stream privateKey, string passPhrase) {
            _privateKeyFile = new PrivateKeyFile(privateKey, passPhrase);
        }

        public LuaPrivateKeyFile(string privateKey) {
            _privateKeyFile = new PrivateKeyFile(privateKey);
        }

        public LuaPrivateKeyFile(string privateKey, string passPhrase) {
            _privateKeyFile = new PrivateKeyFile(privateKey, passPhrase);
        }

        public static LuaPrivateKeyFile New(LuaStream privateKey) => new LuaPrivateKeyFile(privateKey.GetStream());
        public static LuaPrivateKeyFile New(LuaStream privateKey, string passPhrase) => new LuaPrivateKeyFile(privateKey.GetStream(), passPhrase);
        public static LuaPrivateKeyFile New(string privateKey) => new LuaPrivateKeyFile(privateKey);
        public static LuaPrivateKeyFile New(string privateKey, string passPhrase) => new LuaPrivateKeyFile(privateKey, passPhrase);

        #region Variables

        public HostAlgorithm hostKey => _privateKeyFile.HostKey;

        #endregion

    }
}
