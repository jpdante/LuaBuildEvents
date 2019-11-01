[[Path = _csharp_getType("io.LuaPath");]]

Assembly = {}

function Assembly:importLibrary(path) then
    _csharp_loadAssemblyFile(path)
end

LuaReflection = {}

function LuaReflection:getType(type) then
    return _csharp_getAssemblyType(type)
end