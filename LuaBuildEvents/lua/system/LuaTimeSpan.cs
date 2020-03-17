using System;
using System.Collections.Generic;
using System.Text;
using MoonSharp.Interpreter.Interop;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.system {
    public class LuaTimeSpan {

        [MoonSharpVisible(false)]
        private readonly TimeSpan _timeSpan;

        [MoonSharpVisible(false)]
        public TimeSpan GetTimeSpan() => _timeSpan;

        public LuaTimeSpan(TimeSpan timeSpan) {
            _timeSpan = timeSpan;
        }

        public LuaTimeSpan() {
            _timeSpan = new TimeSpan();
        }

        public LuaTimeSpan(int days, int hours, int minutes, int seconds) {
            _timeSpan = new TimeSpan(days, hours, minutes, seconds);
        }

        public LuaTimeSpan(int days, int hours, int minutes, int seconds, int milliseconds) {
            _timeSpan = new TimeSpan(days, hours, minutes, seconds, milliseconds);
        }

        public LuaTimeSpan(int hours, int minutes, int seconds) {
            _timeSpan = new TimeSpan(hours, minutes, seconds);
        }

        public LuaTimeSpan(long ticks) {
            _timeSpan = new TimeSpan(ticks);
        }

        #region Variables

        public int days => _timeSpan.Days;
        public int hours => _timeSpan.Hours;
        public int milliseconds => _timeSpan.Milliseconds;
        public int minutes => _timeSpan.Minutes;
        public int seconds => _timeSpan.Seconds;
        public double totalSeconds => _timeSpan.TotalSeconds;
        public long ticks => _timeSpan.Ticks;
        public double totalDays => _timeSpan.TotalDays;
        public double totalHours => _timeSpan.TotalHours;
        public double totalMilliseconds => _timeSpan.TotalMilliseconds;
        public double totalMinutes => _timeSpan.TotalMinutes;

        #endregion

        #region Sync

        public LuaTimeSpan add(LuaTimeSpan luaTimeSpan) => new LuaTimeSpan(_timeSpan.Add(luaTimeSpan.GetTimeSpan()));
        public int compareTo(LuaTimeSpan luaTimeSpan) => _timeSpan.CompareTo(luaTimeSpan.GetTimeSpan());
        public double divide(LuaTimeSpan luaTimeSpan) => _timeSpan.Divide(luaTimeSpan.GetTimeSpan());
        public LuaTimeSpan duration() => new LuaTimeSpan(_timeSpan.Duration());
        public LuaTimeSpan multiply(double factor) => new LuaTimeSpan(_timeSpan.Multiply(factor));
        public LuaTimeSpan negate() => new LuaTimeSpan(_timeSpan.Negate());
        public LuaTimeSpan subtract(LuaTimeSpan luaTimeSpan) => new LuaTimeSpan(_timeSpan.Subtract(luaTimeSpan.GetTimeSpan()));
        public override string ToString() => _timeSpan.ToString();

        #endregion
    }
}
