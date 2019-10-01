using System;
using System.IO;
using LuaBuildEvents.Internal;
using LuaBuildEvents.Internal.Lua;
using LuaBuildEvents.Internal.Lua.IO;
using LuaBuildEvents.Internal.Lua.Security;
using LuaBuildEvents.Internal.Lua.Sys;
using MoonSharp.Interpreter;
// ReSharper disable StringLiteralTypo

namespace LuaBuildEvents {
    public static class Program {
        public static int Main(string[] args) {
            if (args.Length <= 0) {
                Console.WriteLine($"Usage: dotnet LuaBuildEvents.dll <path to script.lua>");
                return 2;
            }
            if (!File.Exists(args[0])) {
                Console.WriteLine($"The file \"{args[0]}\" does not exist.");
                return 1;
            }
            return Run(args[0], args);
        }

        public static int Run(string filename, string[] args) {
            RegisterTypes();
            var luaScript = new Script {
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
            luaScript.Globals["args"] = args;
            luaScript.Globals["exit"] = new Action<int>(Environment.Exit);
            luaScript.Globals["_internal_io_file"] = typeof(LuaFile);
            luaScript.Globals["_internal_io_path"] = typeof(LuaPath);
            luaScript.Globals["_internal_io_directory"] = typeof(LuaDirectory);
            luaScript.Globals["_internal_io_filestream"] = typeof(LuaFileStream);
            luaScript.Globals["_internal_io_streamreader"] = typeof(LuaStreamReader);
            luaScript.Globals["_internal_io_streamwriter"] = typeof(LuaStreamWriter);
            luaScript.Globals["_internal_sys_environment"] = typeof(LuaEnvironment);
            luaScript.Globals["_internal_sys_process"] = typeof(LuaProcess);
            luaScript.Globals["_internal_sys_processstartinfo"] = typeof(LuaProcessStartInfo);
            luaScript.Globals["_internal_security_filehash"] = typeof(LuaFileHash);
            luaScript.Globals["_internal_security_stringhash"] = typeof(LuaStringHash);
            try {
                luaScript.DoFile(filename);
            } catch (ScriptRuntimeException ex) {
                Console.WriteLine(ex.DecoratedMessage);
                return ex.HResult;
            } catch (InternalErrorException ex) {
                Console.WriteLine(ex.DecoratedMessage);
                return ex.HResult;
            } catch (InterpreterException ex) {
                Console.WriteLine(ex.DecoratedMessage);
                return ex.HResult;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return ex.HResult;
            }
            return 0;
        }

        public static void RegisterTypes() {
            UserData.RegisterType<LuaFile>();
            UserData.RegisterType<LuaDirectory>();
            UserData.RegisterType<LuaPath>();
            UserData.RegisterType<LuaFileStream>();
            UserData.RegisterType<LuaStreamReader>();
            UserData.RegisterType<LuaStreamWriter>();
            UserData.RegisterType<LuaEnvironment>();
            UserData.RegisterType<LuaProcess>();
            UserData.RegisterType<LuaProcessStartInfo>();
            UserData.RegisterType<LuaFileHash>();
            UserData.RegisterType<LuaStringHash>();
        }
    }
}