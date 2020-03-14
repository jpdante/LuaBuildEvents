﻿using System;
using System.Diagnostics;
using System.IO;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.io {
    public class LuaFileSystemWatcher {

        [MoonSharpVisible(false)]
        private readonly FileSystemWatcher _fileSystemWatcher;

        [MoonSharpVisible(false)]
        public FileSystemWatcher GetFileSystemWatcher() => _fileSystemWatcher;

        public LuaFileSystemWatcher() {
            _fileSystemWatcher = new FileSystemWatcher();
            _fileSystemWatcher.Changed += FileSystemWatcherOnChanged;
            _fileSystemWatcher.Created += FileSystemWatcherOnCreated;
            _fileSystemWatcher.Deleted += FileSystemWatcherOnDeleted;
            _fileSystemWatcher.Error += FileSystemWatcherOnError;
            _fileSystemWatcher.Renamed += FileSystemWatcherOnRenamed;
            _fileSystemWatcher.Disposed += FileSystemWatcherOnDisposed;
        }

        public LuaFileSystemWatcher(string path) {
            _fileSystemWatcher = new FileSystemWatcher(path);
            _fileSystemWatcher.Changed += FileSystemWatcherOnChanged;
            _fileSystemWatcher.Created += FileSystemWatcherOnCreated;
            _fileSystemWatcher.Deleted += FileSystemWatcherOnDeleted;
            _fileSystemWatcher.Error += FileSystemWatcherOnError;
            _fileSystemWatcher.Renamed += FileSystemWatcherOnRenamed;
            _fileSystemWatcher.Disposed += FileSystemWatcherOnDisposed;
        }

        public LuaFileSystemWatcher(string path, string filter) {
            _fileSystemWatcher = new FileSystemWatcher(path, filter);
            _fileSystemWatcher.Changed += FileSystemWatcherOnChanged;
            _fileSystemWatcher.Created += FileSystemWatcherOnCreated;
            _fileSystemWatcher.Deleted += FileSystemWatcherOnDeleted;
            _fileSystemWatcher.Error += FileSystemWatcherOnError;
            _fileSystemWatcher.Renamed += FileSystemWatcherOnRenamed;
            _fileSystemWatcher.Disposed += FileSystemWatcherOnDisposed;
        }

        public static LuaFileSystemWatcher New() => new LuaFileSystemWatcher();
        public static LuaFileSystemWatcher New(string path) => new LuaFileSystemWatcher(path);
        public static LuaFileSystemWatcher New(string path, string filter) => new LuaFileSystemWatcher(path, filter);

        #region Events

        public event EventHandler onChanged;
        public event EventHandler onCreated;
        public event EventHandler onDeleted;
        public event EventHandler onError;
        public event EventHandler onRenamed;
        public event EventHandler onDisposed;

        private void FileSystemWatcherOnDisposed(object? sender, EventArgs e) {
            onDisposed?.Invoke(this, e);
        }

        private void FileSystemWatcherOnRenamed(object sender, RenamedEventArgs e) {
            onRenamed?.Invoke(this, e);
        }

        private void FileSystemWatcherOnError(object sender, ErrorEventArgs e) {
            onError?.Invoke(this, e);
        }

        private void FileSystemWatcherOnDeleted(object sender, FileSystemEventArgs e) {
            onDeleted?.Invoke(this, e);
        }

        private void FileSystemWatcherOnCreated(object sender, FileSystemEventArgs e) {
            onCreated?.Invoke(this, e);
        }

        private void FileSystemWatcherOnChanged(object sender, FileSystemEventArgs e) {
            onChanged?.Invoke(this, e);
        }

        #endregion

        #region Variables

        public string name {
            get => _fileSystemWatcher.Filter;
            set => _fileSystemWatcher.Filter = value;
        }

        public string path {
            get => _fileSystemWatcher.Path;
            set => _fileSystemWatcher.Path = value;
        }

        public bool enableRaisingEvents {
            get => _fileSystemWatcher.EnableRaisingEvents;
            set => _fileSystemWatcher.EnableRaisingEvents = value;
        }

        public bool includeSubdirectories {
            get => _fileSystemWatcher.IncludeSubdirectories;
            set => _fileSystemWatcher.IncludeSubdirectories = value;
        }

        public int internalBufferSize {
            get => _fileSystemWatcher.InternalBufferSize;
            set => _fileSystemWatcher.InternalBufferSize = value;
        }

        public string notifyFilter {
            get => _fileSystemWatcher.NotifyFilter.ToString();
            set {
                if (!Enum.TryParse(value, out NotifyFilters result)) {
                    _fileSystemWatcher.NotifyFilter = result;
                }
                throw new ScriptRuntimeException("Failed to parse NotifyFilters.");
            }
        }

        #endregion

        #region Sync

        public void beginInit() => _fileSystemWatcher.BeginInit();
        public void endInit() => _fileSystemWatcher.EndInit();
        public void waitForChanged(string value) {
            if (!Enum.TryParse(value, out WatcherChangeTypes result)) {
                _fileSystemWatcher.WaitForChanged(result);
            }
            throw new ScriptRuntimeException("Failed to parse WatcherChangeTypes.");
        }
        public void waitForChanged(string value, int timeout) {
            if (!Enum.TryParse(value, out WatcherChangeTypes result)) {
                _fileSystemWatcher.WaitForChanged(result, timeout);
            }
            throw new ScriptRuntimeException("Failed to parse WatcherChangeTypes.");
        }
        public void dispose() => _fileSystemWatcher.Dispose();

        #endregion
    }
}
