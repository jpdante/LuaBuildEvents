print("[LuaBuildEvents] Starting LuaBuildEvents.MySqlConnector PostBuild\n")
require("lua.io")

function execute(configuration, solution_folder)
  if args[2] == "Debug" then
    print("[LuaBuildEvents] Running in Debug Mode\n")
    outputDirectory = Path.combine(args[3], [[LuaBuildEvents/bin/Debug/netcoreapp3.1]])
    if Directory.exists(outputDirectory) == false then
	    Directory.createDirectory(outputDirectory)
	end
	File.copy(
      Path.combine(solution_folder, [[Extensions/LuaBuildEvents.MySqlConnector/bin/Debug/netcoreapp3.1/LuaBuildEvents.MySqlConnector.dll]]),
      Path.combine(outputDirectory, [[LuaBuildEvents.MySqlConnector.dll]]),
      true
    )
    File.copy(
      Path.combine(solution_folder, [[Extensions/LuaBuildEvents.MySqlConnector/bin/Debug/netcoreapp3.1/MySqlConnector.dll]]),
      Path.combine(outputDirectory, [[MySqlConnector.dll]]),
      true
    )
  elseif args[2] == "Release" then
    print("[LuaBuildEvents] Running in Release Mode\n")
    outputDirectory = Path.combine(args[3], [[LuaBuildEvents/bin/Release/netcoreapp3.1]])
    if Directory.exists(outputDirectory) == false then
	    Directory.createDirectory(outputDirectory)
	end
	File.copy(
      Path.combine(solution_folder, [[Extensions/LuaBuildEvents.MySqlConnector/bin/Release/netcoreapp3.1/LuaBuildEvents.MySqlConnector.dll]]),
      Path.combine(outputDirectory, [[LuaBuildEvents.MySqlConnector.dll]]),
      true
    )
    File.copy(
      Path.combine(solution_folder, [[Extensions/LuaBuildEvents.MySqlConnector/bin/Release/netcoreapp3.1/MySqlConnector.dll]]),
      Path.combine(outputDirectory, [[MySqlConnector.dll]]),
      true
    )
  end
end

execute(args[2], args[3])
print("[LuaBuildEvents] Finishing LuaBuildEvents.MySqlConnector PostBuild\n")