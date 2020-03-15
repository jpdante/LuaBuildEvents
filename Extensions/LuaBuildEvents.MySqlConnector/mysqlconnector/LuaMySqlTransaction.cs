using MoonSharp.Interpreter.Interop;
using MySql.Data.MySqlClient;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.MySqlConnector.mysqlconnector {
    public class LuaMySqlTransaction {
        [MoonSharpVisible(false)]
        public MySqlTransaction Transaction;

        public LuaMySqlConnection Connection { get; }

        public LuaMySqlTransaction(MySqlTransaction transaction, LuaMySqlConnection sqlConnection) {
            Transaction = transaction;
            Connection = sqlConnection;
        }

        public static LuaMySqlTransaction New(LuaMySqlConnection sqlConnection) => sqlConnection.beginTransaction();

        public void commit() => Transaction.Commit();
        public void rollback() => Transaction.Rollback();
        public void dispose() => Transaction.Dispose();
    }
}