using System;
using System.IO;
using System.Net;
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
            //RegisterTypes();
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
            RegisterFunctionsAndTypes(luaScript);
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

        public static void RegisterFunctionsAndTypes(Script luaScript) {
            luaScript.Globals["_internal_io_file"] = new Func<Type>( () => {
                UserData.RegisterType<LuaFile>();
                return typeof(LuaFile);
            });
            luaScript.Globals["_internal_io_path"] = new Func<Type>( () => {
                UserData.RegisterType<LuaPath>();
                return typeof(LuaPath);
            });
            luaScript.Globals["_internal_io_directory"] = new Func<Type>( () => {
                UserData.RegisterType<LuaDirectory>();
                return typeof(LuaDirectory);
            });
            luaScript.Globals["_internal_io_filestream"] = new Func<Type>( () => {
                UserData.RegisterType<LuaFileStream>();
                return typeof(LuaFileStream);
            });
            luaScript.Globals["_internal_io_streamreader"] = new Func<Type>( () => {
                UserData.RegisterType<LuaStreamReader>();
                return typeof(LuaStreamReader);
            });
            luaScript.Globals["_internal_io_streamwriter"] = new Func<Type>( () => {
                UserData.RegisterType<LuaStreamWriter>();
                return typeof(LuaStreamWriter);
            });
            luaScript.Globals["_internal_sys_environment"] = new Func<Type>( () => {
                UserData.RegisterType<LuaEnvironment>();
                return typeof(LuaEnvironment);
            });
            luaScript.Globals["_internal_sys_process"] = new Func<Type>( () => {
                UserData.RegisterType<LuaProcess>();
                return typeof(LuaProcess);
            });
            luaScript.Globals["_internal_sys_processstartinfo"] = new Func<Type>( () => {
                UserData.RegisterType<LuaProcessStartInfo>();
                return typeof(LuaProcessStartInfo);
            });
            luaScript.Globals["_internal_security_filehash"] = new Func<Type>( () => {
                UserData.RegisterType<LuaFileHash>();
                return typeof(LuaFileHash);
            });
            luaScript.Globals["_internal_security_stringhash"] = new Func<Type>( () => {
                UserData.RegisterType<LuaStringHash>();
                return typeof(LuaStringHash);
            });
            luaScript.Globals["_internal_net_webclient"] = new Func<Type>( () => {
                UserData.RegisterType<WebClient>();
                return typeof(WebClient);
            });
        }

        /*public static void RegisterTypes() {
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
        }*/
    }
}