_csharp_loadAssembly("System.IO")
_csharp_loadAssembly("System.IO.FileSystem")
_csharp_loadAssembly("System.IO.FileSystem.Watcher")

-- Path
Path = _csharp_getType("io.LuaPath");

-- File
File = _csharp_getType("io.LuaFile");
FileInfo = _csharp_getType("io.LuaFileInfo");

-- Directory
Directory = _csharp_getType("io.LuaDirectory");
DirectoryInfo = _csharp_getType("io.LuaDirectoryInfo");

-- Stream
Stream = _csharp_getType("io.LuaStream");
FileStream = _csharp_getType("io.LuaFileStream");
StreamReader = _csharp_getType("io.LuaStreamReader");
StreamWriter = _csharp_getType("io.LuaStreamWriter");

-- FileSystem
FileSystemInfo = _csharp_getType("io.LuaFileSystemInfo");

-- FileSystem.Watcher
NotifyFilters = _csharp_getStaticType("System.IO.NotifyFilters");
WatcherChangeTypes = _csharp_getStaticType("System.IO.WatcherChangeTypes");
FileSystemWatcher = _csharp_getType("io.LuaFileSystemWatcher");