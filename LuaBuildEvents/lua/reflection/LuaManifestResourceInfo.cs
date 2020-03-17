using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MoonSharp.Interpreter.Interop;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.reflection {
    public class LuaManifestResourceInfo {

        [MoonSharpVisible(false)]
        private readonly ManifestResourceInfo _manifestResourceInfo;

        [MoonSharpVisible(false)]
        public ManifestResourceInfo GetManifestResourceInfo() { return _manifestResourceInfo; }

        public LuaManifestResourceInfo(ManifestResourceInfo manifestResourceInfo) {
            this._manifestResourceInfo = manifestResourceInfo;
        }

        public string fileName => _manifestResourceInfo.FileName;
        public LuaAssembly referencedAssembly => new LuaAssembly(_manifestResourceInfo.ReferencedAssembly);
        public string resourceLocation => _manifestResourceInfo.ResourceLocation.ToString();

    }
}
