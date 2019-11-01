using System;
using System.IO;
using System.Reflection;
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
            luaScript.Globals["_csharp_getType"] = new Func<string, Type>( (requestedType) => {
                var type = Assembly.GetExecutingAssembly().GetType(requestedType);
                if(type == null) throw new ScriptRuntimeException($"Failed to decode assemblies for '{requestedType}'");
                UserData.RegisterType(type);
                return type;
            });
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
    }
}