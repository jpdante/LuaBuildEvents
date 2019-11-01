Assembly.importLibrary([[C:\Users\jpdante\source\repos\LuaBuildEvents\Extensions\LuaBuildEvents.MySqlConnector\bin\Debug\netcoreapp3.0\LuaBuildEvents.MySqlConnector.dll]])
require("mysqlconnector.mysql")

connection = MySqlConnection.New("Server=127.0.0.1;Database=test;Uid=root;Pwd=root;")
connection.open()
command = MySqlCommand.New("SELECT * FROM `gas_stations`;", connection)
reader = command.executeReader()
if reader.hasRows == false then
    print("No rows found!")
end
while reader.read() do
    print("ID: " .. reader.getInt32(0) .. "\n")
	print("Location: " .. reader.getString(1) .. "\n")
	print("ProviderLocations: " .. reader.getString(2) .. "\n")
	print("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n")
end
	print("Finished\n")