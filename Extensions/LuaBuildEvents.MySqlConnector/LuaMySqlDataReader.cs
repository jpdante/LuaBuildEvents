using System;
using System.Collections;
using System.IO;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.MySqlConnector {
    public class LuaMySqlDataReader {
        private readonly MySqlDataReader _dataReader;

        public LuaMySqlDataReader(MySqlDataReader dataReader) {
            _dataReader = dataReader;
        }

        public int depth => _dataReader.Depth;
        public int fieldCount => _dataReader.FieldCount;
        public bool hasRows => _dataReader.HasRows;
        public bool isClosed => _dataReader.IsClosed;
        public int recordsAffected => _dataReader.RecordsAffected;
        public int visibleFieldCount => _dataReader.VisibleFieldCount;

		public bool getBoolean(int ordinal) => _dataReader.GetBoolean(ordinal);
		public byte getByte(int ordinal) => _dataReader.GetByte(ordinal);
		public sbyte getSByte(int ordinal) => _dataReader.GetSByte(ordinal);
		public long getBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length) => _dataReader.GetBytes(ordinal, dataOffset, buffer, bufferOffset, length);
		public char getChar(int ordinal) => _dataReader.GetChar(ordinal);
		public long getChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length)=> _dataReader.GetChars(ordinal, dataOffset, buffer, bufferOffset, length);
		public Guid getGuid(int ordinal) => _dataReader.GetGuid(ordinal);
		public short getInt16(int ordinal) => _dataReader.GetInt16(ordinal);
		public int getInt32(int ordinal) => _dataReader.GetInt32(ordinal);
		public long getInt64(int ordinal) => _dataReader.GetInt64(ordinal);
		public string getDataTypeName(int ordinal) => _dataReader.GetDataTypeName(ordinal);
		public Type getFieldType(int ordinal) => _dataReader.GetFieldType(ordinal);
		public object getValue(int ordinal) => _dataReader.GetValue(ordinal);
		public IEnumerator getEnumerator() => _dataReader.GetEnumerator();
		public DateTime getDateTime(int ordinal) => _dataReader.GetDateTime(ordinal);
		public DateTimeOffset getDateTimeOffset(int ordinal) => _dataReader.GetDateTimeOffset(ordinal);
		public MySqlDateTime getMySqlDateTime(int ordinal) => _dataReader.GetMySqlDateTime(ordinal);
		public TimeSpan getTimeSpan(int ordinal) => (TimeSpan) getValue(ordinal);
		public Stream getStream(int ordinal) => _dataReader.GetStream(ordinal);
		public TextReader getTextReader(int ordinal) => new StringReader(getString(ordinal));
		public TextReader getTextReader(string name) => new StringReader(getString(name));
		public string getString(int ordinal) => _dataReader.GetString(ordinal);
		public decimal getDecimal(int ordinal) => _dataReader.GetDecimal(ordinal);
		public double getDouble(int ordinal) => _dataReader.GetDouble(ordinal);
		public float getFloat(int ordinal) => _dataReader.GetFloat(ordinal);
		public ushort getUInt16(int ordinal) => _dataReader.GetUInt16(ordinal);
		public uint getUInt32(int ordinal) => _dataReader.GetUInt32(ordinal);
		public ulong getUInt64(int ordinal) => _dataReader.GetUInt64(ordinal);


        public int getOrdinal(string name) => _dataReader.GetOrdinal(name);
        public bool getBoolean(string name) => _dataReader.GetBoolean(name);
        public byte getByte(string name) => _dataReader.GetByte(name);
        public sbyte getSByte(string name) => _dataReader.GetSByte(name);
        public char getChar(string name) => _dataReader.GetChar(name);
        public Guid getGuid(string name) => _dataReader.GetGuid(name);
        public short getInt16(string name) => _dataReader.GetInt16(name);
        public int getInt32(string name) => _dataReader.GetInt32(name);
        public long getInt64(string name) => _dataReader.GetInt64(name);
        public Type getFieldType(string name) => _dataReader.GetFieldType(name);
        public DateTime getDateTime(string name) => _dataReader.GetDateTime(name);
        public DateTimeOffset getDateTimeOffset(string name) => _dataReader.GetDateTimeOffset(name);
        public MySqlDateTime getMySqlDateTime(string name) => _dataReader.GetMySqlDateTime(name);
        public TimeSpan getTimeSpan(string name) => _dataReader.GetTimeSpan(name);
        public Stream getStream(string name) => _dataReader.GetStream(name);
        public string getString(string name) => _dataReader.GetString(name);
        public decimal getDecimal(string name) => _dataReader.GetDecimal(name);
        public double getDouble(string name) => _dataReader.GetDouble(name);
        public float getFloat(string name) => _dataReader.GetFloat(name);
        public ushort getUInt16(string name) => _dataReader.GetUInt16(name);
        public uint getUInt32(string name) => _dataReader.GetUInt32(name);
        public ulong getUInt64(string name) => _dataReader.GetUInt64(name);

        public void close() => _dataReader.Close();
        public bool isDBNull(int ordinal) => _dataReader.IsDBNull(ordinal);
        public bool nextResult() => _dataReader.NextResult();
        public bool read() => _dataReader.Read();
        public void dispose() => _dataReader.Dispose();
    }
}