using System.IO;

// ReSharper disable InconsistentNaming

namespace LuaBuildEvents.lua.io {
    public static class LuaPath {
        public static string combine(params string[] path) => Path.Combine(path);
        public static string join(params string[] path) => Path.Join(path);
        public static string changeExtension(string path, string extension) => Path.ChangeExtension(path, extension);
        public static string getDirectoryName(string path) => Path.GetDirectoryName(path);
        public static string getExtension(string path) => Path.GetExtension(path);
        public static string getFileName(string path) => Path.GetFileName(path);
        public static string getFileNameWithoutExtension(string path) => Path.GetFileNameWithoutExtension(path);
        public static string getFullPath(string path) => Path.GetFullPath(path);
        public static string getPathRoot(string path) => Path.GetPathRoot(path);
        public static string getRandomFileName() => Path.GetRandomFileName();
        public static string getRelativePath(string relativeTo, string path) => Path.GetRelativePath(relativeTo, path);
        public static string getTempFileName() => Path.GetTempFileName();
        public static string getTempPath() => Path.GetTempPath();
        public static string trimEndingDirectorySeparator(string path) => Path.TrimEndingDirectorySeparator(path);
        public static bool endsInDirectorySeparator(string path) => Path.EndsInDirectorySeparator(path);
        public static char[] getInvalidFileNameChars() => Path.GetInvalidFileNameChars();
        public static char[] getInvalidPathChars() => Path.GetInvalidPathChars();
        public static bool hasExtension(string path) => Path.HasExtension(path);
        public static bool isPathFullyQualified(string path) => Path.IsPathFullyQualified(path);
        public static bool isPathRooted(string path) => Path.IsPathRooted(path);

        public static char altDirectorySeparatorChar => Path.AltDirectorySeparatorChar;
        public static char directorySeparatorChar => Path.DirectorySeparatorChar;
        public static char pathSeparator => Path.PathSeparator;
        public static char volumeSeparatorChar => Path.VolumeSeparatorChar;
    }
}
