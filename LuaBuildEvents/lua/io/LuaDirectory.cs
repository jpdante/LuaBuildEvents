using System;
using System.Collections.Generic;
using System.IO;
using MoonSharp.Interpreter;

// ReSharper disable InconsistentNaming

namespace LuaBuildEvents.lua.io {
    public static class LuaDirectory {
        public static bool exists(string path) => Directory.Exists(path);
        public static void delete(string path) => Directory.Delete(path);
        public static void move(string from, string to) => Directory.Move(from, to);
        public static string getCurrentDirectory() => Directory.GetCurrentDirectory();
        public static void createDirectory(string path) => Directory.CreateDirectory(path);
        public static string[] getFiles(string path) => Directory.GetFiles(path);
        public static string[] getFiles(string path, string pattern) => Directory.GetFiles(path, pattern);
        public static string[] getDirectories(string path) => Directory.GetDirectories(path);
        public static string[] getDirectories(string path, string pattern) => Directory.GetDirectories(path, pattern);
        public static DateTime getCreationTime(string path) => Directory.GetCreationTime(path);
        public static DateTime getCreationTimeUtc(string path) => Directory.GetCreationTimeUtc(path);
        public static DateTime getLastAccessTime(string path) => Directory.GetLastAccessTime(path);
        public static DateTime getLastAccessTimeUtc(string path) => Directory.GetLastAccessTimeUtc(path);
        public static DateTime getLastWriteTime(string path) => Directory.GetLastWriteTime(path);
        public static DateTime getLastWriteTimeUtc(string path) => Directory.GetLastWriteTimeUtc(path);
        public static void setCreationTime(string path, DateTime dateTime) => Directory.SetCreationTime(path, dateTime);
        public static void setCreationTimeUtc(string path, DateTime dateTime) => Directory.SetCreationTimeUtc(path, dateTime);
        public static void setLastAccessTime(string path, DateTime dateTime) => Directory.SetLastAccessTime(path, dateTime);
        public static void setLastAccessTimeUtc(string path, DateTime dateTime) => Directory.SetLastAccessTimeUtc(path, dateTime);
        public static void setLastWriteTime(string path, DateTime dateTime) => Directory.SetLastWriteTime(path, dateTime);
        public static void setLastWriteTimeUtc(string path, DateTime dateTime) => Directory.SetLastWriteTimeUtc(path, dateTime);
        public static void setCurrentDirectory(string path) => Directory.SetCurrentDirectory(path);
        public static string getDirectoryRoot(string path) => Directory.GetDirectoryRoot(path);
        public static string[] getFileSystemEntries(string path) => Directory.GetFileSystemEntries(path);
        public static string[] getFileSystemEntries(string path, string pattern) => Directory.GetFileSystemEntries(path, pattern);
        public static string[] getLogicalDrives(string path) => Directory.GetLogicalDrives();
        public static LuaDirectoryInfo getParent(string path) => new LuaDirectoryInfo(Directory.GetParent(path));
        public static string[] getDirectories(string path, string pattern, string searchOption) {
            if (!Enum.TryParse(searchOption, out SearchOption result)) {
                return Directory.GetDirectories(path, pattern, result);
            }
            throw new ScriptRuntimeException("Failed to parse SearchOption.");
        }
        public static string[] getFiles(string path, string pattern, string searchOption) {
            if (!Enum.TryParse(searchOption, out SearchOption result)) {
                return Directory.GetFiles(path, pattern, result);
            }
            throw new ScriptRuntimeException("Failed to parse SearchOption.");
        }
        public static string[] getFileSystemEntries(string path, string pattern, string searchOption) {
            if (!Enum.TryParse(searchOption, out SearchOption result)) {
                return Directory.GetFileSystemEntries(path, pattern, result);
            }
            throw new ScriptRuntimeException("Failed to parse SearchOption.");
        }
    }
}
