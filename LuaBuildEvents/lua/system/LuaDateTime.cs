using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using MoonSharp.Interpreter.Interop;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.system {
    public class LuaDateTime {

        [MoonSharpVisible(false)]
        private readonly DateTime _dateTime;

        [MoonSharpVisible(false)]
        public DateTime GetDateTime() => _dateTime;

        public LuaDateTime(DateTime dateTime) {
            _dateTime = dateTime;
        }

        public LuaDateTime() {
            _dateTime = new DateTime();
        }

        public LuaDateTime(int year, int month, int day) {
            _dateTime = new DateTime(year, month, day);
        }

        public LuaDateTime(int year, int month, int day, int hour, int minute, int second) {
            _dateTime = new DateTime(year, month, day, hour, minute, second);
        }

        #region Variables

        public int day => _dateTime.Day;
        public LuaDateTime date => new LuaDateTime(_dateTime.Date);
        public DayOfWeek dayOfWeek => _dateTime.DayOfWeek;
        public int dayOfYear => _dateTime.DayOfYear;
        public int hour => _dateTime.Hour;
        public DateTimeKind kind => _dateTime.Kind;
        public int millisecond => _dateTime.Millisecond;
        public int minute => _dateTime.Minute;
        public int month => _dateTime.Month;
        public int second => _dateTime.Second;
        public long ticks => _dateTime.Ticks;
        public LuaTimeSpan timeOfDay => new LuaTimeSpan(_dateTime.TimeOfDay);
        public int year => _dateTime.Year;

        #endregion

        #region Sync

        public int compareTo(LuaDateTime luaDateTime) => _dateTime.CompareTo(luaDateTime.GetDateTime());
        public long toBinary() => _dateTime.ToBinary();
        public long toFileTime() => _dateTime.ToFileTime();
        public long toFileTimeUtc() => _dateTime.ToFileTimeUtc();
        public override string ToString() => _dateTime.ToString(CultureInfo.CurrentCulture);
        public string ToString(string format) => _dateTime.ToString(format);
        public LuaDateTime add(LuaTimeSpan luaTimeSpan) => new LuaDateTime(_dateTime.Add(luaTimeSpan.GetTimeSpan()));
        public LuaDateTime addDays(double value) => new LuaDateTime(_dateTime.AddDays(value));
        public LuaDateTime addHours(double value) => new LuaDateTime(_dateTime.AddHours(value));
        public LuaDateTime addMilliseconds(double value) => new LuaDateTime(_dateTime.AddMilliseconds(value));
        public LuaDateTime addMinutes(double value) => new LuaDateTime(_dateTime.AddMinutes(value));
        public LuaDateTime addMonths(int value) => new LuaDateTime(_dateTime.AddMonths(value));
        public LuaDateTime addSeconds(double value) => new LuaDateTime(_dateTime.AddSeconds(value));
        public LuaDateTime addTicks(long value) => new LuaDateTime(_dateTime.AddTicks(value));
        public LuaDateTime addYears(int value) => new LuaDateTime(_dateTime.AddYears(value));
        public string[] getDateTimeFormats() => _dateTime.GetDateTimeFormats();
        public bool isDaylightSavingTime() => _dateTime.IsDaylightSavingTime();
        public LuaTimeSpan subtract(LuaDateTime luaDateTime) => new LuaTimeSpan(_dateTime.Subtract(luaDateTime.GetDateTime()));
        public LuaDateTime subtract(LuaTimeSpan luaTimeSpan) => new LuaDateTime(_dateTime.Subtract(luaTimeSpan.GetTimeSpan()));
        public LuaDateTime toLocalTime() => new LuaDateTime(_dateTime.ToLocalTime());
        public string toLongDateString() => _dateTime.ToLongDateString();
        public string toLongTimeString() => _dateTime.ToLongTimeString();
        public double toOADate() => _dateTime.ToOADate();
        public string toShortDateString() => _dateTime.ToShortDateString();
        public string toShortTimeString() => _dateTime.ToShortTimeString();
        public LuaDateTime toUniversalTime() => new LuaDateTime(_dateTime.ToUniversalTime());

        #endregion

    }
}
