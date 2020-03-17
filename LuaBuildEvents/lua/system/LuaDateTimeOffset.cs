using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using MoonSharp.Interpreter.Interop;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.system {
    public class LuaDateTimeOffset {

        [MoonSharpVisible(false)]
        private readonly DateTimeOffset _dateTimeOffset;

        [MoonSharpVisible(false)]
        public DateTimeOffset GetDateTimeOffset() => _dateTimeOffset;

        public LuaDateTimeOffset(DateTimeOffset dateTimeOffset) {
            _dateTimeOffset = dateTimeOffset;
        }

        public LuaDateTimeOffset() {
            _dateTimeOffset = new DateTimeOffset();
        }

        public LuaDateTimeOffset(DateTime dateTime) {
            _dateTimeOffset = new DateTimeOffset(dateTime);
        }

        public LuaDateTimeOffset(DateTime dateTime, TimeSpan offset) {
            _dateTimeOffset = new DateTimeOffset(dateTime, offset);
        }

        public LuaDateTimeOffset(int year, int month, int day) {
            _dateTimeOffset = new DateTime(year, month, day);
        }

        public LuaDateTimeOffset(int year, int month, int day, int hour, int minute, int second) {
            _dateTimeOffset = new DateTime(year, month, day, hour, minute, second);
        }

        public LuaDateTimeOffset(int year, int month, int day, int hour, int minute, int second, int millisecond) {
            _dateTimeOffset = new DateTime(year, month, day, hour, minute, second, millisecond);
        }

        public LuaDateTimeOffset(long ticks) {
            _dateTimeOffset = new DateTime(ticks);
        }

        #region Variables

        public int day => _dateTimeOffset.Day;
        public LuaDateTime date => new LuaDateTime(_dateTimeOffset.Date);
        public DayOfWeek dayOfWeek => _dateTimeOffset.DayOfWeek;
        public int dayOfYear => _dateTimeOffset.DayOfYear;
        public int hour => _dateTimeOffset.Hour;
        public int millisecond => _dateTimeOffset.Millisecond;
        public int minute => _dateTimeOffset.Minute;
        public int month => _dateTimeOffset.Month;
        public int second => _dateTimeOffset.Second;
        public long ticks => _dateTimeOffset.Ticks;
        public long utcTicks => _dateTimeOffset.UtcTicks;
        public LuaTimeSpan offset => new LuaTimeSpan(_dateTimeOffset.Offset);
        public LuaTimeSpan timeOfDay => new LuaTimeSpan(_dateTimeOffset.TimeOfDay);
        public int year => _dateTimeOffset.Year;

        #endregion

        #region Sync

        public int compareTo(LuaDateTime luaDateTime) => _dateTimeOffset.CompareTo(luaDateTime.GetDateTime());
        public long toFileTime() => _dateTimeOffset.ToFileTime();
        public override string ToString() => _dateTimeOffset.ToString(CultureInfo.CurrentCulture);
        public string ToString(string format) => _dateTimeOffset.ToString(format);
        public LuaDateTimeOffset add(LuaTimeSpan luaTimeSpan) => new LuaDateTimeOffset(_dateTimeOffset.Add(luaTimeSpan.GetTimeSpan()));
        public LuaDateTimeOffset addDays(double value) => new LuaDateTimeOffset(_dateTimeOffset.AddDays(value));
        public LuaDateTimeOffset addHours(double value) => new LuaDateTimeOffset(_dateTimeOffset.AddHours(value));
        public LuaDateTimeOffset addMilliseconds(double value) => new LuaDateTimeOffset(_dateTimeOffset.AddMilliseconds(value));
        public LuaDateTimeOffset addMinutes(double value) => new LuaDateTimeOffset(_dateTimeOffset.AddMinutes(value));
        public LuaDateTimeOffset addMonths(int value) => new LuaDateTimeOffset(_dateTimeOffset.AddMonths(value));
        public LuaDateTimeOffset addSeconds(double value) => new LuaDateTimeOffset(_dateTimeOffset.AddSeconds(value));
        public LuaDateTimeOffset addTicks(long value) => new LuaDateTimeOffset(_dateTimeOffset.AddTicks(value));
        public LuaDateTimeOffset addYears(int value) => new LuaDateTimeOffset(_dateTimeOffset.AddYears(value));
        public LuaTimeSpan subtract(LuaDateTime luaDateTime) => new LuaTimeSpan(_dateTimeOffset.Subtract(luaDateTime.GetDateTime()));
        public LuaDateTimeOffset subtract(LuaTimeSpan luaTimeSpan) => new LuaDateTimeOffset(_dateTimeOffset.Subtract(luaTimeSpan.GetTimeSpan()));
        public LuaDateTimeOffset toLocalTime() => new LuaDateTimeOffset(_dateTimeOffset.ToLocalTime());
        public LuaDateTimeOffset toUniversalTime() => new LuaDateTimeOffset(_dateTimeOffset.ToUniversalTime());
        public LuaDateTimeOffset toOffset(LuaTimeSpan luaTimeSpan) => new LuaDateTimeOffset(_dateTimeOffset.ToOffset(luaTimeSpan.GetTimeSpan()));
        public LuaDateTimeOffset toUnixTimeMilliseconds() => new LuaDateTimeOffset(_dateTimeOffset.ToUnixTimeMilliseconds());
        public LuaDateTimeOffset toUnixTimeSeconds() => new LuaDateTimeOffset(_dateTimeOffset.ToUnixTimeSeconds());

        #endregion

    }
}
