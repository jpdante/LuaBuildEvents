using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

// ReSharper disable InconsistentNaming

namespace LuaBuildEvents.lua.system {
    public class LuaEnvironment {
        public static string command_line => Environment.CommandLine;
        public static string new_line => Environment.NewLine;

        public static string current_directory {
            get => Environment.CurrentDirectory;
            set => Environment.CurrentDirectory = value;
        }

        public static string machineName => Environment.MachineName;
        public static string stackTrace => Environment.StackTrace;
        public static string systemDirectory => Environment.SystemDirectory;
        public static string userDomainName => Environment.UserDomainName;
        public static string userName => Environment.UserName;
        public static string expandEnvironmentVariables(string name) => Environment.ExpandEnvironmentVariables(name);
        public static string getEnvironmentVariable(string variable) => Environment.GetEnvironmentVariable(variable);

        public static Dictionary<string, string> getEnvironmentVariables() => Environment.GetEnvironmentVariables()
            .Cast<DictionaryEntry>().ToDictionary(var => var.Key.ToString(), var => var.Value.ToString());

        public static string getFolderPath(string value) =>
            Enum.TryParse(value, out Environment.SpecialFolder folderType)
                ? Environment.GetFolderPath(folderType)
                : null;

        public static int currentManagedThreadID => Environment.CurrentManagedThreadId;

        public static int exitCode {
            get => Environment.ExitCode;
            set => Environment.ExitCode = value;
        }

        public static bool hasShutdownStarted => Environment.HasShutdownStarted;
        public static bool is64BitOperatingSystem => Environment.Is64BitOperatingSystem;
        public static bool is64BitProcess => Environment.Is64BitProcess;
        public static LuaOperatingSystem osVersion => new LuaOperatingSystem(Environment.OSVersion);
        public static int processorCount => Environment.ProcessorCount;
        public static int systemPageSize => Environment.SystemPageSize;
        public static int tickCount => Environment.TickCount;
        public static bool userInteractive => Environment.UserInteractive;
        public static LuaVersion version => new LuaVersion(Environment.Version);
    }

    public class LuaVersion {

        private readonly Version _version;

        public LuaVersion(Version version) { _version = version; }

        public int build => _version.Build;
        public int major => _version.Major;
        public int majorRevision => _version.MajorRevision;
        public int minor => _version.Minor;
        public int minorRevision => _version.MinorRevision;
        public int revision => _version.Revision;
    }

    public class LuaOperatingSystem {

        private readonly OperatingSystem _operatingSystem;

        public LuaOperatingSystem(OperatingSystem operatingSystem) {
            _operatingSystem = operatingSystem;
            version = new LuaVersion(_operatingSystem.Version);
        }

        public string versionString => _operatingSystem.VersionString;
        public string servicePack => _operatingSystem.ServicePack;
        public string plataform => _operatingSystem.Platform.ToString();
        public LuaVersion version { get; }
    }

}
