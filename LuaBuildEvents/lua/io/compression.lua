_csharp_loadAssembly("System.IO")
_csharp_loadAssembly("System.IO.Compression")

-- Dependencies
CompressionLevel = _csharp_getStaticType("System.IO.Compression.CompressionLevel");
CompressionMode = _csharp_getStaticType("System.IO.Compression.CompressionMode");

ZipFile = _csharp_getType("io.compression.LuaZipFile");
ZipArchive = _csharp_getType("io.compression.LuaZipArchive");
GZipStream = _csharp_getType("io.compression.LuaGZipStream");
DeflateStream = _csharp_getType("io.compression.LuaDeflateStream");