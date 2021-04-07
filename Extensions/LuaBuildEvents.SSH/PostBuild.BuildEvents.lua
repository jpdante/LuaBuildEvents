print("[LuaBuildEvents] Starting LuaBuildEvents.SSH PostBuild\n")
require("lua.io")

function execute(configuration, solution_folder, target_folder)
  if configuration == "Debug" then
    print("[LuaBuildEvents] Running in Debug Mode\n")
    outputDirectory = Path.combine(solution_folder, [[LuaBuildEvents/bin/x64/Release/netcoreapp3.1]])
    if Directory.exists(outputDirectory) == false then
	    Directory.createDirectory(outputDirectory)
	end
	File.copy(
      Path.combine(solution_folder, target_folder, "LuaBuildEvents.SSH.dll"),
      Path.combine(outputDirectory, "LuaBuildEvents.SSH.dll"),
      true
    )
    File.copy(
      Path.combine(solution_folder, target_folder, "Renci.SshNet.dll"),
      Path.combine(outputDirectory, "Renci.SshNet.dll"),
      true
    )
    File.copy(
      Path.combine(solution_folder, target_folder, "SshNet.Security.Cryptography.dll"),
      Path.combine(outputDirectory, "SshNet.Security.Cryptography.dll"),
      true
    )
    File.copy(
      Path.combine(solution_folder, target_folder, "System.Xml.XPath.XmlDocument.dll"),
      Path.combine(outputDirectory, "System.Xml.XPath.XmlDocument.dll"),
      true
    )
  elseif configuration == "Release" then
    print("[LuaBuildEvents] Running in Release Mode\n")
    outputDirectory = Path.combine(solution_folder, [[LuaBuildEvents/bin/x64/Release/netcoreapp3.1]])
    if Directory.exists(outputDirectory) == false then
	    Directory.createDirectory(outputDirectory)
	end
	File.copy(
      Path.combine(solution_folder, target_folder, "LuaBuildEvents.SSH.dll"),
      Path.combine(outputDirectory, "LuaBuildEvents.SSH.dll"),
      true
    )
    File.copy(
      Path.combine(solution_folder, target_folder, "Renci.SshNet.dll"),
      Path.combine(outputDirectory, "Renci.SshNet.dll"),
      true
    )
    File.copy(
      Path.combine(solution_folder, target_folder, "SshNet.Security.Cryptography.dll"),
      Path.combine(outputDirectory, "SshNet.Security.Cryptography.dll"),
      true
    )
    File.copy(
      Path.combine(solution_folder, target_folder, "System.Xml.XPath.XmlDocument.dll"),
      Path.combine(outputDirectory, "System.Xml.XPath.XmlDocument.dll"),
      true
    )
  end
end

execute(args[2], args[3], args[4])
print("[LuaBuildEvents] Finishing LuaBuildEvents.SSH PostBuild\n")