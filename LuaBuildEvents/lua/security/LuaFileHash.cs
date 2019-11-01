using System;
using System.Security.Cryptography;
using LuaBuildEvents.lua.io;
using MoonSharp.Interpreter;

namespace LuaBuildEvents.lua.sec {
    public class LuaFileHash {

        public static byte[] hashStreamToBytes(string encryption, LuaFileStream fileStream) {
            switch (encryption) {
                case "MD5":
                    using (var md5 = MD5.Create()) {
                        var hash = md5.ComputeHash(fileStream.GetFileStream());
                        return hash;
                    }
                case "SHA-1":
                    using (var sha1 = SHA1.Create()) {
                        var hash = sha1.ComputeHash(fileStream.GetFileStream());
                        return hash;
                    }
                case "SHA-256":
                    using (var sha256 = SHA256.Create()) {
                        var hash = sha256.ComputeHash(fileStream.GetFileStream());
                        return hash;
                    }
                case "SHA-384":
                    using (var sha384 = SHA384.Create()) {
                        var hash = sha384.ComputeHash(fileStream.GetFileStream());
                        return hash;
                    }
                case "SHA-512":
                    using (var sha512 = SHA512.Create()) {
                        var hash = sha512.ComputeHash(fileStream.GetFileStream());
                        return hash;
                    }
                default:
                    throw new ScriptRuntimeException("Failed to parse Encryption.");
            }
        }

        public static string hashStreamToString(string encryption, LuaFileStream fileStream) {
            switch (encryption) {
                case "MD5":
                    using (var md5 = MD5.Create()) {
                        var hash = md5.ComputeHash(fileStream.GetFileStream());
                        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    }
                case "SHA-1":
                    using (var sha1 = SHA1.Create()) {
                        var hash = sha1.ComputeHash(fileStream.GetFileStream());
                        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    }
                case "SHA-256":
                    using (var sha256 = SHA256.Create()) {
                        var hash = sha256.ComputeHash(fileStream.GetFileStream());
                        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    }
                case "SHA-384":
                    using (var sha384 = SHA384.Create()) {
                        var hash = sha384.ComputeHash(fileStream.GetFileStream());
                        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    }
                case "SHA-512":
                    using (var sha512 = SHA512.Create()) {
                        var hash = sha512.ComputeHash(fileStream.GetFileStream());
                        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    }
                default:
                    throw new ScriptRuntimeException("Failed to parse Encryption.");
            }
        }
    }
}
