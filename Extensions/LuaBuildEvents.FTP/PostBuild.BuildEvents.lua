print("[LuaBuildEvents] Starting LuaBuildEvents.Ftp PostBuild\n")
require("lua.io")

function execute(configuration, solution_folder, target_folder)
  if configuration == "Debug" then
    print("[LuaBuildEvents] Running in Debug Mode\n")
    outputDirectory = Path.combine(solution_folder, [[LuaBuildEvents/bin/x64/Release/netcoreapp3.1]])
    if Directory.exists(outputDirectory) == false then
	    Directory.createDirectory(outputDirectory)
	end
	File.copy(
      Path.combine(solution_folder, target_folder, "LuaBuildEvents.FTP.dll"),
      Path.combine(outputDirectory, "LuaBuildEvents.FTP.dll"),
      true
    )
    File.copy(
      Path.combine(solution_folder, target_folder, "FluentFTP.dll"),
      Path.combine(outputDirectory, "FluentFTP.dll"),
      true
    )
  elseif configuration == "Release" then
    print("[LuaBuildEvents] Running in Release Mode\n")
    outputDirectory = Path.combine(solution_folder, [[LuaBuildEvents/bin/x64/Release/netcoreapp3.1]])
    if Directory.exists(outputDirectory) == false then
	    Directory.createDirectory(outputDirectory)
	end
	File.copy(
      Path.combine(solution_folder, target_folder, "LuaBuildEvents.FTP.dll"),
      Path.combine(outputDirectory, "LuaBuildEvents.FTP.dll"),
      true
    )
    File.copy(
      Path.combine(solution_folder, target_folder, "FluentFTP.dll"),
      Path.combine(outputDirectory, "FluentFTP.dll"),
      true
    )
  end
end

execute(args[2], args[3], args[4])
print("[LuaBuildEvents] Finishing LuaBuildEvents.Ftp PostBuild\n")