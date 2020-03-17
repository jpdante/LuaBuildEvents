using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using LuaBuildEvents.lua.io;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.reflection {
    public class LuaAssembly {

        [MoonSharpVisible(false)]
        private readonly Assembly _assembly;

        public LuaAssembly(Assembly assembly) {
            this._assembly = assembly;
        }

        public string codeBase => _assembly.CodeBase;
        public string escapedCodeBase => _assembly.EscapedCodeBase;
        public string fullName => _assembly.FullName;
        public string imageRuntimeVersion => _assembly.ImageRuntimeVersion;
        public string location => _assembly.Location;
        // TODO: Fix LuaAssembly
        //public string customAttributes => _assembly.CustomAttributes;
        //public string definedTypes => _assembly.DefinedTypes;
        //public string entryPoint => _assembly.EntryPoint;
        public LuaType[] exportedTypes => _assembly.ExportedTypes.Select(type => new LuaType(type)).ToArray();
        public bool globalAssemblyCache => _assembly.GlobalAssemblyCache;
        public long hostContext => _assembly.HostContext;
        public bool isCollectible => _assembly.IsCollectible;
        public bool isDynamic => _assembly.IsDynamic;
        public bool isFullyTrusted => _assembly.IsFullyTrusted;
        public LuaModule manifestModule => new LuaModule(_assembly.ManifestModule);
        public LuaModule[] modules => _assembly.Modules.Select(module => new LuaModule(module)).ToArray();
        public bool reflectionOnly => _assembly.ReflectionOnly;
        public string securityRuleSet => _assembly.SecurityRuleSet.ToString();

        public void createInstance(string typeName) => _assembly.CreateInstance(typeName);
        public void createInstance(string typeName, bool ignoreCase) => _assembly.CreateInstance(typeName, ignoreCase);

        public object[] getCustomAttributes(LuaType type, bool inherit) => _assembly.GetCustomAttributes(type.GetVarType(), inherit);
        public object[] getCustomAttributes(bool inherit) => _assembly.GetCustomAttributes(inherit);

        public LuaType[] getExportedTypes() => _assembly.GetExportedTypes().Select(type => new LuaType(type)).ToArray();

        public LuaFileStream getFile(string name) => new LuaFileStream(_assembly.GetFile(name));

        public LuaFileStream[] getFiles() => _assembly.GetFiles().Select(fileStream => new LuaFileStream(fileStream)).ToArray();
        public LuaFileStream[] getFiles(bool getResourceModules) => _assembly.GetFiles(getResourceModules).Select(fileStream => new LuaFileStream(fileStream)).ToArray();

        public LuaType[] getForwardedTypes() => _assembly.GetForwardedTypes().Select(type => new LuaType(type)).ToArray();

        public LuaModule[] getLoadedModules() => _assembly.GetLoadedModules().Select(module => new LuaModule(module)).ToArray();
        public LuaModule[] getLoadedModules(bool getResourceModules) => _assembly.GetLoadedModules().Select(module => new LuaModule(module)).ToArray();

        public LuaManifestResourceInfo getManifestResourceInfo(string resourceName) {
            var data = _assembly.GetManifestResourceInfo(resourceName);
            return data != null ? new LuaManifestResourceInfo(data) : null;
        }

        public string[] getManifestResourceNames() => _assembly.GetManifestResourceNames();

        public LuaStream getManifestResourceStream(LuaType type, string name) => new LuaStream(_assembly.GetManifestResourceStream(type.GetVarType(), name));
        public LuaStream getManifestResourceStream(string name) => new LuaStream(_assembly.GetManifestResourceStream(name));

        public LuaModule getModule(string name) => new LuaModule(_assembly.GetModule(name));

        public LuaModule[] getModules() => _assembly.GetModules().Select(module => new LuaModule(module)).ToArray();
        public LuaModule[] getModules(bool getResourceModules) => _assembly.GetModules(getResourceModules).Select(module => new LuaModule(module)).ToArray();

        public LuaAssemblyName getName() => new LuaAssemblyName(_assembly.GetName());
        public LuaAssemblyName getName(bool copiedName) => new LuaAssemblyName(_assembly.GetName(copiedName));

        public LuaAssemblyName[] getReferencedAssemblies() => _assembly.GetReferencedAssemblies().Select(assemblyName => new LuaAssemblyName(assemblyName)).ToArray();

        public LuaAssembly getSatelliteAssembly(string cultureInfoRaw) {
            var cultureInfo = cultureInfoRaw switch {
                "CurrentCulture" => CultureInfo.CurrentCulture,
                "CurrentUICulture" => CultureInfo.CurrentUICulture,
                "DefaultThreadCurrentCulture" => CultureInfo.DefaultThreadCurrentCulture,
                "DefaultThreadCurrentUICulture" => CultureInfo.DefaultThreadCurrentUICulture,
                "InstalledUICulture" => CultureInfo.InstalledUICulture,
                "InvariantCulture" => CultureInfo.InvariantCulture,
                _ => CultureInfo.GetCultureInfo(cultureInfoRaw ?? throw new ArgumentNullException(nameof(cultureInfoRaw)))
            };
            return new LuaAssembly(_assembly.GetSatelliteAssembly(cultureInfo));
        }

        public LuaType getType() => new LuaType(_assembly.GetType());
        public LuaType getType(string name) => new LuaType(_assembly.GetType(name));
        public LuaType getType(string name, bool throwOnError) => new LuaType(_assembly.GetType(name, throwOnError));
        public LuaType getType(string name, bool throwOnError, bool ignoreCase) => new LuaType(_assembly.GetType(name, throwOnError, ignoreCase));

        public LuaType[] getTypes() => _assembly.GetTypes().Select(type => new LuaType(type)).ToArray();

        public bool isDefined(LuaType type) => _assembly.IsDefined(type.GetVarType());
        public bool isDefined(LuaType type, bool inherit) => _assembly.IsDefined(type.GetVarType(), inherit);

        public static LuaAssembly loadAssembly(string assemblyString) {
            var assembly = Assembly.Load(assemblyString);
            Program.ScriptLoader.AddAssembly(assembly);
            return new LuaAssembly(assembly);
        }

        public static LuaAssembly loadFileAssembly(string filename) {
            var assembly = Assembly.LoadFile(filename);
            Program.ScriptLoader.AddAssembly(assembly);
            return new LuaAssembly(assembly);
        }

    }
}