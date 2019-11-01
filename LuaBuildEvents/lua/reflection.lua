Assembly = {}

function Assembly.importLibrary(path)
    _csharp_loadAssemblyFile(path)
end

LuaReflection = {}

function LuaReflection.getType(type)
    return _csharp_getAssemblyType(type)
end