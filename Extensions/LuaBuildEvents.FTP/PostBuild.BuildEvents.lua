print("[LuaBuildEvents] Starting LuaBuildEvents.Ftp PostBuild\n")
require("lua.io")

function execute(configuration, solution_folder)
  if args[2] == "Debug" then
    print("[LuaBuildEvents] Running in Debug Mode\n")
    outputDirectory = Path.combine(args[3], [[LuaBuildEvents/bin/Debug/netcoreapp3.1]])
    if Directory.exists(outputDirectory) == false then
	    Directory.createDirectory(outputDirectory)
	end
	File.copy(
      Path.combine(solution_folder, [[Extensions/LuaBuildEvents.FTP/bin/Debug/netcoreapp3.1/LuaBuildEvents.FTP.dll]]),
      Path.combine(outputDirectory, [[LuaBuildEvents.FTP.dll]]),
      true
    )
    File.copy(
      Path.combine(solution_folder, [[Extensions/LuaBuildEvents.FTP/bin/Debug/netcoreapp3.1/FluentFTP.dll]]),
      Path.combine(outputDirectory, [[FluentFTP.dll]]),
      true
    )
  elseif args[2] == "Release" then
    print("[LuaBuildEvents] Running in Release Mode\n")
    outputDirectory = Path.combine(args[3], [[LuaBuildEvents/bin/Release/netcoreapp3.1]])
    if Directory.exists(outputDirectory) == false then
	    Directory.createDirectory(outputDirectory)
	end
	File.copy(
      Path.combine(solution_folder, [[Extensions/LuaBuildEvents.FTP/bin/Release/netcoreapp3.1/LuaBuildEvents.FTP.dll]]),
      Path.combine(outputDirectory, [[LuaBuildEvents.FTP.dll]]),
      true
    )
    File.copy(
      Path.combine(solution_folder, [[Extensions/LuaBuildEvents.FTP/bin/Release/netcoreapp3.1/FluentFTP.dll]]),
      Path.combine(outputDirectory, [[FluentFTP.dll]]),
      true
    )
  end
end

execute(args[2], args[3])
print("[LuaBuildEvents] Finishing LuaBuildEvents.Ftp PostBuild\n")