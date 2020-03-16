using MoonSharp.Interpreter.Interop;
using MySql.Data.MySqlClient;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.MySql {
    public class LuaMySqlParameters {
        private readonly MySqlCommand _command;

        [MoonSharpVisible(false)]
        public LuaMySqlParameters(MySqlCommand command) {
            _command = command;
        }

        public int Count => _command.Parameters.Count;

        public void addWithValue(string parameterName, object value) => _command.Parameters.AddWithValue(parameterName, value);
        public void clear() => _command.Parameters.Clear();
        public bool contains(object value) => _command.Parameters.Contains(value);
        public int indexOf(object value) => _command.Parameters.IndexOf(value);
        public void remove(object value) => _command.Parameters.Remove(value);
        public void removeAt(int index) => _command.Parameters.RemoveAt(index);
    }
}