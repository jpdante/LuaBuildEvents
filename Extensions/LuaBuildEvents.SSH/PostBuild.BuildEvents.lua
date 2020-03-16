print("[LuaBuildEvents] Starting LuaBuildEvents.SSH PostBuild\n")
require("lua.io")

function execute(configuration, solution_folder)
  if args[2] == "Debug" then
    print("[LuaBuildEvents] Running in Debug Mode\n")
    outputDirectory = Path.combine(args[3], [[LuaBuildEvents/bin/Debug/netcoreapp3.1]])
    if Directory.exists(outputDirectory) == false then
	    Directory.createDirectory(outputDirectory)
	end
	File.copy(
      Path.combine(solution_folder, [[Extensions/LuaBuildEvents.SSH/bin/Debug/netcoreapp3.1/LuaBuildEvents.SSH.dll]]),
      Path.combine(outputDirectory, [[LuaBuildEvents.SSH.dll]]),
      true
    )
    File.copy(
      Path.combine(solution_folder, [[Extensions/LuaBuildEvents.SSH/bin/Debug/netcoreapp3.1/Renci.SshNet.dll]]),
      Path.combine(outputDirectory, [[Renci.SshNet.dll]]),
      true
    )
    File.copy(
      Path.combine(solution_folder, [[Extensions/LuaBuildEvents.SSH/bin/Debug/netcoreapp3.1/SshNet.Security.Cryptography.dll]]),
      Path.combine(outputDirectory, [[SshNet.Security.Cryptography.dll]]),
      true
    )
    File.copy(
      Path.combine(solution_folder, [[Extensions/LuaBuildEvents.SSH/bin/Debug/netcoreapp3.1/System.Xml.XPath.XmlDocument.dll]]),
      Path.combine(outputDirectory, [[System.Xml.XPath.XmlDocument.dll]]),
      true
    )
  elseif args[2] == "Release" then
    print("[LuaBuildEvents] Running in Release Mode\n")
    outputDirectory = Path.combine(args[3], [[LuaBuildEvents/bin/Release/netcoreapp3.1]])
    if Directory.exists(outputDirectory) == false then
	    Directory.createDirectory(outputDirectory)
	end
	File.copy(
      Path.combine(solution_folder, [[Extensions/LuaBuildEvents.SSH/bin/Release/netcoreapp3.1/LuaBuildEvents.SSH.dll]]),
      Path.combine(outputDirectory, [[LuaBuildEvents.SSH.dll]]),
      true
    )
    File.copy(
      Path.combine(solution_folder, [[Extensions/LuaBuildEvents.SSH/bin/Release/netcoreapp3.1/Renci.SshNet.dll]]),
      Path.combine(outputDirectory, [[Renci.SshNet.dll]]),
      true
    )
    File.copy(
      Path.combine(solution_folder, [[Extensions/LuaBuildEvents.SSH/bin/Release/netcoreapp3.1/SshNet.Security.Cryptography.dll]]),
      Path.combine(outputDirectory, [[SshNet.Security.Cryptography.dll]]),
      true
    )
    File.copy(
      Path.combine(solution_folder, [[Extensions/LuaBuildEvents.SSH/bin/Release/netcoreapp3.1/System.Xml.XPath.XmlDocument.dll]]),
      Path.combine(outputDirectory, [[System.Xml.XPath.XmlDocument.dll]]),
      true
    )
  end
end

execute(args[2], args[3])
print("[LuaBuildEvents] Finishing LuaBuildEvents.SSH PostBuild\n")