using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using LuaBuildEvents.lua.system;
using MoonSharp.Interpreter.Interop;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.reflection {
    public class LuaAssemblyName {
        [MoonSharpVisible(false)]
        private readonly AssemblyName _assemblyName;

        [MoonSharpVisible(false)]
        public AssemblyName GetAssemblyName() { return _assemblyName; }
        
        public LuaAssemblyName(AssemblyName assemblyName) { this._assemblyName = assemblyName; }

        public string escapedCodeBase => _assemblyName.EscapedCodeBase;
        public string codeBase {
            get => _assemblyName.CodeBase;
            set => _assemblyName.CodeBase = value;
        }
        public string fullName => _assemblyName.FullName;
        public string cultureName => _assemblyName.CultureName;
        public string name {
            get => _assemblyName.Name;
            set => _assemblyName.Name = value;
        }
        public string contentType => _assemblyName.ContentType.ToString();
        //public string cultureInfo => _assemblyName.CultureInfo;
        //public string flags => _assemblyName.Flags;
        //public string hashAlgorithm => _assemblyName.HashAlgorithm;
        //public string keyPair => _assemblyName.KeyPair.;
        public string processorArchitecture => _assemblyName.ProcessorArchitecture.ToString();
        public LuaVersion version => new LuaVersion(_assemblyName.Version);
        public string versionCompatibility => _assemblyName.VersionCompatibility.ToString();

        public byte[] getPublicKey() => _assemblyName.GetPublicKey();

        public void setPublicKey(byte[] key) => _assemblyName.SetPublicKey(key);

        public byte[] getPublicKeyToken => _assemblyName.GetPublicKeyToken();

        public void setPublicKeyToken(byte[] token) => _assemblyName.SetPublicKeyToken(token);

    }
}
