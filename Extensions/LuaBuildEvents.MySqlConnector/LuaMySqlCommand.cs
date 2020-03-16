using MoonSharp.Interpreter.Interop;
using MySql.Data.MySqlClient;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.MySqlConnector {
    public class LuaMySqlCommand {
        [MoonSharpVisible(false)]
        private readonly MySqlCommand _command;

        [MoonSharpVisible(false)]
        private LuaMySqlConnection _luaSqlConnection;

        [MoonSharpVisible(false)]
        private LuaMySqlTransaction _luaSqlTransaction;

        public LuaMySqlParameters Parameters { get; }

        public LuaMySqlCommand() {
            _command = new MySqlCommand();
            Parameters = new LuaMySqlParameters(_command);
        }

        public LuaMySqlCommand(LuaMySqlConnection connection) {
            _luaSqlConnection = connection;
            _command = new MySqlCommand();
            Parameters = new LuaMySqlParameters(_command);
        }

        public LuaMySqlCommand(string commandText) {
            _command = new MySqlCommand(commandText);
            Parameters = new LuaMySqlParameters(_command);
        }

        public LuaMySqlCommand(string commandText, LuaMySqlConnection connection) {
            _luaSqlConnection = connection;
            _command = new MySqlCommand(commandText, _luaSqlConnection.SqlConnection);
            Parameters = new LuaMySqlParameters(_command);
        }

        public LuaMySqlCommand(string commandText, LuaMySqlConnection connection, LuaMySqlTransaction transaction) {
            _luaSqlConnection = connection;
            _luaSqlTransaction = transaction;
            _command = new MySqlCommand(commandText, _luaSqlConnection.SqlConnection, _luaSqlTransaction.Transaction);
            Parameters = new LuaMySqlParameters(_command);
        }

        public static LuaMySqlCommand New() => new LuaMySqlCommand();
        public static LuaMySqlCommand New(LuaMySqlConnection connection) => new LuaMySqlCommand(connection);
        public static LuaMySqlCommand New(string commandText) => new LuaMySqlCommand(commandText);
        public static LuaMySqlCommand New(string commandText, LuaMySqlConnection connection) => new LuaMySqlCommand(commandText, connection);
        public static LuaMySqlCommand New(string commandText, LuaMySqlConnection connection, LuaMySqlTransaction transaction) => new LuaMySqlCommand(commandText, connection, transaction);

        public LuaMySqlConnection connection {
            get => _luaSqlConnection;
            set {
                _luaSqlConnection = value;
                _command.Connection = _luaSqlConnection.SqlConnection;
            }
        }

        public LuaMySqlTransaction transaction {
            get => _luaSqlTransaction;
            set {
                _luaSqlTransaction = value;
                _command.Transaction = _luaSqlTransaction.Transaction;
            }
        }

        public string commandText => _command.CommandText;
        public int commandTimeout => _command.CommandTimeout;
        public bool designTimeVisible => _command.DesignTimeVisible;
        public bool isPrepared => _command.IsPrepared;
        public long lastInsertedId => _command.LastInsertedId;

        public int executeNonQuery() => _command.ExecuteNonQuery();
        public void prepare() => _command.Prepare();
        public object executeScalar() => _command.ExecuteScalar();
        public LuaMySqlDataReader executeReader() => new LuaMySqlDataReader(_command.ExecuteReader());
        public void cancel() => _command.Cancel();
        public void dispose() => _command.Dispose();
    }
}
