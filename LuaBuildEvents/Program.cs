using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using MoonSharp.Interpreter;
// ReSharper disable StringLiteralTypo

namespace LuaBuildEvents {
    public static class Program {

        public static LuaScriptLoader ScriptLoader;
        public static Script Script;

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
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainOnAssemblyResolve;
            ScriptLoader = new LuaScriptLoader {
                ModulePaths = new[] {
                    "?.lua",
                    $"{Directory.GetCurrentDirectory()}/?",
                    $"{Directory.GetCurrentDirectory()}/?.lua"
                }
            };
            Script = new Script {
                Options = {
                    ScriptLoader = ScriptLoader,
                    DebugPrint = Console.Write,
                }
            };
            Script.Globals["args"] = args;
            Script.Globals["exit"] = new Action<int>(Environment.Exit);
            Script.Globals["_csharp_getType"] = new Func<string, Type>((requestedType) => {
                var type = Assembly.GetExecutingAssembly().GetType("LuaBuildEvents.lua." + requestedType);
                if (type == null) {
                    throw new ScriptRuntimeException($"Failed to decode assemblies for '{requestedType}'");
                }
                UserData.RegisterType(type);
                return type;
            });
            Script.Globals["_csharp_getAssemblyType"] = new Func<string, Type>((requestedType) => {
                foreach (var assembly in ScriptLoader.ResourceAssemblies) {
                    var type = assembly.GetType(requestedType);
                    if (type == null) {
                        continue;
                    }
                    UserData.RegisterType(type);
                    return type;
                }
                throw new ScriptRuntimeException($"Failed to decode assemblies for '{requestedType}'");
            });
            try {
                Script.DoFile(filename);
            } catch (ScriptRuntimeException ex) {
                Console.WriteLine(ex.DecoratedMessage);
                Console.WriteLine(ex.StackTrace);
                return ex.HResult;
            } catch (InternalErrorException ex) {
                Console.WriteLine(ex.DecoratedMessage);
                Console.WriteLine(ex.StackTrace);
                return ex.HResult;
            } catch (InterpreterException ex) {
                Console.WriteLine(ex.DecoratedMessage);
                Console.WriteLine(ex.StackTrace);
                return ex.HResult;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return ex.HResult;
            }
            return 0;
        }

        private static Assembly CurrentDomainOnAssemblyResolve(object sender, ResolveEventArgs args) {
            var pluginDependencyName = args.Name.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).First();
            var path = getApplicationPath(pluginDependencyName + ".dll");
            var assembly = Assembly.LoadFile(path);
            return assembly;
        }

        public static string getApplicationPath(string fileName) {
            var exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Split('\\', 2)[1];
            return Path.Combine(exePath, fileName);
        }
    }
}