using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

// ReSharper disable InconsistentNaming

namespace LuaBuildEvents.Internal.Lua.Sys {
    public class LuaEnvironment {
        public static string command_line => Environment.CommandLine;
        public static string new_line => Environment.NewLine;
        public static string current_directory {
            get => Environment.CurrentDirectory;
            set => Environment.CurrentDirectory = value;
        }
        public static string machine_name => Environment.MachineName;
        public static string stack_trace => Environment.StackTrace;
        public static string system_directory => Environment.SystemDirectory;
        public static string user_domain_name => Environment.UserDomainName;
        public static string user_name => Environment.UserName;
        public static string expand_environment_variables(string name) => Environment.ExpandEnvironmentVariables(name);
        public static string get_environment_variable(string variable) => Environment.GetEnvironmentVariable(variable);
        public static Dictionary<string, string> get_environment_variables() => Environment.GetEnvironmentVariables().Cast<DictionaryEntry>().ToDictionary(var => var.Key.ToString(), var => var.Value.ToString());
        public static string get_folder_path(string value) => Enum.TryParse(value, out Environment.SpecialFolder folderType) ? Environment.GetFolderPath(folderType) : null;
        public static int current_managed_thread_id => Environment.CurrentManagedThreadId;
        public static int exit_code {
            get => Environment.ExitCode;
            set => Environment.ExitCode = value;
        }
        public static bool has_shutdown_started => Environment.HasShutdownStarted;
        public static bool is_64_bit_operating_system => Environment.Is64BitOperatingSystem;
        public static bool is_64_bit_process => Environment.Is64BitProcess;
        public static string os_version_version_string => Environment.OSVersion.VersionString;
        public static string os_version_service_pack => Environment.OSVersion.ServicePack;
        public static string os_version_platform => Environment.OSVersion.Platform.ToString();
        public static string os_version_version => Environment.OSVersion.Version.ToString();
        public static int processor_count => Environment.ProcessorCount;
        public static int system_page_size => Environment.SystemPageSize;
        public static int tick_count => Environment.TickCount;
        public static bool user_interactive => Environment.UserInteractive;
        public static string version => Environment.Version.ToString();
        public static int version_build => Environment.Version.Build;
        public static int version_major => Environment.Version.Major;
        public static int version_major_revision => Environment.Version.MajorRevision;
        public static int version_minor => Environment.Version.Minor;
        public static int version_minor_revision => Environment.Version.MinorRevision;
        public static int version_revision => Environment.Version.Revision;
    }
}
