using MoonSharp.Interpreter.Interop;
using MySql.Data.MySqlClient;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.MySql {
    public class LuaMySqlConnection {
        [MoonSharpVisible(false)]
        public MySqlConnection SqlConnection;

        public LuaMySqlConnection() {
            SqlConnection = new MySqlConnection();
        }

        public LuaMySqlConnection(string connectionString) {
            SqlConnection = new MySqlConnection(connectionString);
        }

        public static LuaMySqlConnection New() => new LuaMySqlConnection();
        public static LuaMySqlConnection New(string connectionString) => new LuaMySqlConnection(connectionString);

        public int connectionTimeout => SqlConnection.ConnectionTimeout;
        public int serverThread => SqlConnection.ServerThread;
        public string connectionString => SqlConnection.ConnectionString;
        public string database => SqlConnection.Database;
        public string state => SqlConnection.State.ToString();
        public string dataSource => SqlConnection.DataSource;
        public string serverVersion => SqlConnection.ServerVersion;

        public void open() => SqlConnection.Open();
        public void close() => SqlConnection.Close();
        public void changeDatabase(string databaseName) => SqlConnection.ChangeDatabase(databaseName);
        public bool ping() => SqlConnection.Ping();
        public LuaMySqlTransaction beginTransaction() => new LuaMySqlTransaction(SqlConnection.BeginTransaction(), this);
        public void dispose() => SqlConnection.Dispose();
    }
}
