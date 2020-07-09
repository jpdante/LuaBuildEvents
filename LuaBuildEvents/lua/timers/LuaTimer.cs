using System;
using System.Timers;
using MoonSharp.Interpreter.Interop;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.timers {
    public class LuaTimer : IDisposable {
        [MoonSharpVisible(false)] private readonly Timer _timer;

        [MoonSharpVisible(false)]
        public Timer GetTimer() => _timer;

        public LuaTimer() {
            _timer = new Timer();
            _timer.Elapsed += TimerOnElapsed;
        }

        public LuaTimer(double interval) {
            _timer = new Timer() {
                Interval = interval
            };
            _timer.Elapsed += TimerOnElapsed;
        }

        public LuaTimer(Timer timer) {
            _timer = timer;
            _timer.Elapsed += TimerOnElapsed;
        }

        public static LuaTimer New() => new LuaTimer();
        public static LuaTimer New(double interval) => new LuaTimer(interval);

        public event EventHandler onElapsed;

        private void TimerOnElapsed(object sender, ElapsedEventArgs e) {
            onElapsed?.Invoke(this, EventArgs.Empty);
        }

        public bool enabled {
            get => _timer.Enabled;
            set => _timer.Enabled = value;
        }

        public bool autoReset {
            get => _timer.AutoReset;
            set => _timer.AutoReset = value;
        }

        public void dispose() => Dispose();
        public void enable() => _timer.Enabled = true;
        public void disable() => _timer.Enabled = false;

        [MoonSharpVisible(false)]
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        [MoonSharpVisible(false)]
        protected virtual void Dispose(bool disposing) {
            if (disposing) {
                _timer?.Dispose();
            }
        }
    }
}
