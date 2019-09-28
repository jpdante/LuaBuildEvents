using System;
using System.IO;
using LuaBuildEvents.Internal;
using LuaBuildEvents.Internal.Lua;
using LuaBuildEvents.Internal.Lua.IO;
using LuaBuildEvents.Internal.Lua.Sys;
using MoonSharp.Interpreter;
// ReSharper disable StringLiteralTypo

namespace LuaBuildEvents {
    public class Program {
        public static int Main(string[] args) {
            if (args.Length <= 0) {
                Console.WriteLine($"Usage: dotnet LuaBuildEvents.dll <path to script.lua>");
                return 2;
            }
            if (!File.Exists(args[0])) {
                Console.WriteLine($"The file \"{args[0]}\" does not exist.");
                return 1;
            }
            return new Program().Run(args[0], args);
        }

        private Script _luaScript;

        public int Run(string filename, string[] args) {
            RegisterTypes();
            _luaScript = new Script {
                Options = {
                    ScriptLoader = new LuaScriptLoader {
                        ModulePaths = new[] {
                            "?.lua",
                            $"{Directory.GetCurrentDirectory()}/?",
                            $"{Directory.GetCurrentDirectory()}/?.lua"
                        }
                    },
                    DebugPrint = Console.Write,
                }
            };
            _luaScript.Globals["args"] = args;
            _luaScript.Globals["exit"] = new Action<int>(Environment.Exit);
            _luaScript.Globals["_internal_io_file"] = typeof(LuaFile);
            _luaScript.Globals["_internal_io_path"] = typeof(LuaPath);
            _luaScript.Globals["_internal_io_directory"] = typeof(LuaDirectory);
            _luaScript.Globals["_internal_io_filestream"] = typeof(LuaFileStream);
            _luaScript.Globals["_internal_io_streamreader"] = typeof(LuaStreamReader);
            _luaScript.Globals["_internal_io_streamwriter"] = typeof(LuaStreamWriter);
            _luaScript.Globals["_internal_sys_environment"] = typeof(LuaEnvironment);
            //_luaScript.Globals["_internal_io_file"] = new Func<object>(() => new LuaFile());
            try {
                _luaScript.DoFile(filename);
            } catch (ScriptRuntimeException ex) {
                Console.WriteLine(ex.DecoratedMessage);
                return ex.HResult;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return ex.HResult;
            }
            return 0;
        }

        public void RegisterTypes() {
            UserData.RegisterType<LuaFile>();
            UserData.RegisterType<LuaDirectory>();
            UserData.RegisterType<LuaPath>();
            UserData.RegisterType<LuaFileStream>();
            UserData.RegisterType<LuaStreamReader>();
            UserData.RegisterType<LuaStreamWriter>();
            UserData.RegisterType<LuaEnvironment>();
        }
    }
}