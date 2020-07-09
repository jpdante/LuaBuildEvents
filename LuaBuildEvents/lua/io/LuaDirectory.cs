using System;
using System.Collections.Generic;
using System.IO;
using LuaBuildEvents.lua.system;
using MoonSharp.Interpreter;

// ReSharper disable InconsistentNaming

namespace LuaBuildEvents.lua.io {
    public static class LuaDirectory {
        public static bool exists(string path) => Directory.Exists(path);
        public static void delete(string path) => Directory.Delete(path);
        public static void delete(string path, bool recursive) => Directory.Delete(path, recursive);
        public static void move(string from, string to) => Directory.Move(from, to);
        public static string getCurrentDirectory() => Directory.GetCurrentDirectory();
        public static void createDirectory(string path) => Directory.CreateDirectory(path);
        public static string[] getFiles(string path) => Directory.GetFiles(path);
        public static string[] getFiles(string path, string pattern) => Directory.GetFiles(path, pattern);
        public static string[] getDirectories(string path) => Directory.GetDirectories(path);
        public static string[] getDirectories(string path, string pattern) => Directory.GetDirectories(path, pattern);
        public static LuaDateTime getCreationTime(string path) => new LuaDateTime(Directory.GetCreationTime(path));
        public static LuaDateTime getCreationTimeUtc(string path) => new LuaDateTime(Directory.GetCreationTimeUtc(path));
        public static LuaDateTime getLastAccessTime(string path) => new LuaDateTime(Directory.GetLastAccessTime(path));
        public static LuaDateTime getLastAccessTimeUtc(string path) => new LuaDateTime(Directory.GetLastAccessTimeUtc(path));
        public static LuaDateTime getLastWriteTime(string path) => new LuaDateTime(Directory.GetLastWriteTime(path));
        public static LuaDateTime getLastWriteTimeUtc(string path) => new LuaDateTime(Directory.GetLastWriteTimeUtc(path));
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
        public static string[] getDirectories(string path, string pattern, SearchOption searchOption) => Directory.GetDirectories(path, pattern, searchOption);
        public static string[] getFiles(string path, string pattern, SearchOption searchOption) => Directory.GetFiles(path, pattern, searchOption);
        public static string[] getFileSystemEntries(string path, string pattern, SearchOption searchOption) => Directory.GetFileSystemEntries(path, pattern, searchOption);
    }
}
