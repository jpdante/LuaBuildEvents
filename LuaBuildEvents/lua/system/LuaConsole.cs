using System;
using System.Collections.Generic;
using System.Text;
using MoonSharp.Interpreter;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo


namespace LuaBuildEvents.lua.system {
    public class LuaConsole {

        public LuaConsole() {
            UserData.RegisterType<ConsoleColor>();
            Program.Script.Globals["ConsoleColor"] = UserData.CreateStatic<ConsoleColor>();
        }

        public string title {
            get => Console.Title;
            set => Console.Title = value;
        }

        public int bufferWidth {
            get => Console.BufferWidth;
            set => Console.BufferWidth = value;
        }

        public int bufferHeight {
            get => Console.BufferHeight;
            set => Console.BufferHeight = value;
        }

        public ConsoleColor backgroundColor {
            get => Console.BackgroundColor;
            set => Console.BackgroundColor = value;
        }

        public bool capsLock => Console.CapsLock;

        public int cursorLeft {
            get => Console.CursorLeft;
            set => Console.CursorLeft = value;
        }

        public int cursorSize {
            get => Console.CursorSize;
            set => Console.CursorSize = value;
        }

        public int cursorTop {
            get => Console.CursorTop;
            set => Console.CursorTop = value;
        }

        public bool cursorVisible {
            get => Console.CursorVisible;
            set => Console.CursorVisible = value;
        }

        public ConsoleColor foregroundColor {
            get => Console.ForegroundColor;
            set => Console.ForegroundColor = value;
        }

        public string inputEncoding {
            get => Console.InputEncoding?.ToString();
            set => Console.InputEncoding = Encoding.GetEncoding(value);
        }

        public bool isErrorRedirected => Console.IsErrorRedirected;

        public bool isInputRedirected => Console.IsInputRedirected;

        public bool isOutputRedirected => Console.IsOutputRedirected;

        public bool keyAvailable => Console.KeyAvailable;

        public bool numberLock => Console.NumberLock;

        public bool treatControlCAsInput {
            get => Console.TreatControlCAsInput;
            set => Console.TreatControlCAsInput = value;
        }

        public int largestWindowHeight => Console.LargestWindowHeight;

        public int largestWindowWidth => Console.LargestWindowWidth;

        public string outputEncoding {
            get => Console.OutputEncoding?.ToString();
            set => Console.OutputEncoding = Encoding.GetEncoding(value);
        }

        public static string readLine() => Console.ReadLine();
        public static int read() => Console.Read();
        public static void writeLine(object obj) => Console.WriteLine(obj);
        public static void beep() => Console.Beep();
        public static void beep(int frequency, int duration) => Console.Beep(frequency, duration);
        public static void clear() => Console.Clear();
        public static void resetColor() => Console.ResetColor();
        public static void setBufferSize(int width, int height) => Console.SetBufferSize(width, height);
        public static void write(object obj) => Console.Write(obj);
        public static void setWindowSize(int width, int height) => Console.SetWindowSize(width, height);
        public static void setWindowPosition(int left, int top) => Console.SetWindowPosition(left, top);
    }
}
