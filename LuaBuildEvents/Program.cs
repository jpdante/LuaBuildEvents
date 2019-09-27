using System;
using System.IO;
using LuaBuildEvents.Internal;
using LuaBuildEvents.Internal.Lua;
using MoonSharp.Interpreter;

namespace LuaBuildEvents {
    public class Program {
        public static int Main(string[] args) {
            if (args.Length != 1) {
                return 2;
            }
            if (!File.Exists(args[0])) {
                Console.WriteLine($"The file \"{args[0]}\" does not exist.");
            }
            return new Program().Run(args[0]);
        }

        private Script _luaScript;

        public int Run(string filename) {
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
            _luaScript.Globals["_internal_io_file"] = new Func<object>(() => new LuaFile());
            _luaScript.Globals["_internal_io_path"] = new Func<object>(() => new LuaPath());
            _luaScript.Globals["_internal_io_directory"] = new Func<object>(() => new LuaDirectory());
            try {
                _luaScript.DoFile(filename);
            } catch (ScriptRuntimeException   ex) {
                Console.WriteLine(ex.DecoratedMessage);
                return 1;
            }
            return 0;
        }

        public void RegisterTypes() {
            UserData.RegisterType<LuaFile>();
            UserData.RegisterType<LuaDirectory>();
            UserData.RegisterType<LuaPath>();
        }
    }
}