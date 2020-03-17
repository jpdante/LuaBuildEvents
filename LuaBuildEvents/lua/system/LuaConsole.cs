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

        #region Variables

        public static string title {
            get => Console.Title;
            set => Console.Title = value;
        }

        public static int bufferWidth {
            get => Console.BufferWidth;
            set => Console.BufferWidth = value;
        }

        public static int bufferHeight {
            get => Console.BufferHeight;
            set => Console.BufferHeight = value;
        }

        public static ConsoleColor backgroundColor {
            get => Console.BackgroundColor;
            set => Console.BackgroundColor = value;
        }

        public static bool capsLock => Console.CapsLock;

        public static int cursorLeft {
            get => Console.CursorLeft;
            set => Console.CursorLeft = value;
        }

        public static int cursorSize {
            get => Console.CursorSize;
            set => Console.CursorSize = value;
        }

        public static int cursorTop {
            get => Console.CursorTop;
            set => Console.CursorTop = value;
        }

        public static bool cursorVisible {
            get => Console.CursorVisible;
            set => Console.CursorVisible = value;
        }

        public static ConsoleColor foregroundColor {
            get => Console.ForegroundColor;
            set => Console.ForegroundColor = value;
        }

        public static string inputEncoding {
            get => Console.InputEncoding?.ToString();
            set => Console.InputEncoding = Encoding.GetEncoding(value);
        }

        public static bool isErrorRedirected => Console.IsErrorRedirected;

        public static bool isInputRedirected => Console.IsInputRedirected;

        public static bool isOutputRedirected => Console.IsOutputRedirected;

        public static bool keyAvailable => Console.KeyAvailable;

        public static bool numberLock => Console.NumberLock;

        public static bool treatControlCAsInput {
            get => Console.TreatControlCAsInput;
            set => Console.TreatControlCAsInput = value;
        }

        public static int largestWindowHeight => Console.LargestWindowHeight;

        public static int largestWindowWidth => Console.LargestWindowWidth;

        public static string outputEncoding {
            get => Console.OutputEncoding?.ToString();
            set => Console.OutputEncoding = Encoding.GetEncoding(value);
        }

        #endregion

        #region Sync

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

        #endregion
    }
}
