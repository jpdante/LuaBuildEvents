using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using MoonSharp.Interpreter;

namespace LuaBuildEvents.Internal.Lua.Security {
    public class LuaStringHash {
        
        public static byte[] hash_string_to_bytes(string encryption, string data) => hash_string_to_bytes(encryption, data, "UTF-8");
        public static byte[] hash_string_to_bytes(string encryption, string data, string encoding) {
            switch (encryption) {
                case "MD5":
                    using (var md5 = MD5.Create()) {
                        var buffer = Encoding.GetEncoding(encoding).GetBytes(data);
                        var hash = md5.ComputeHash(buffer, 0, buffer.Length);
                        return hash;
                    }
                case "SHA-1":
                    using (var sha1 = SHA1.Create()) {
                        var buffer = Encoding.GetEncoding(encoding).GetBytes(data);
                        var hash = sha1.ComputeHash(buffer, 0, buffer.Length);
                        return hash;
                    }
                case "SHA-256":
                    using (var sha256 = SHA256.Create()) {
                        var buffer = Encoding.GetEncoding(encoding).GetBytes(data);
                        var hash = sha256.ComputeHash(buffer, 0, buffer.Length);
                        return hash;
                    }
                case "SHA-384":
                    using (var sha384 = SHA384.Create()) {
                        var buffer = Encoding.GetEncoding(encoding).GetBytes(data);
                        var hash = sha384.ComputeHash(buffer, 0, buffer.Length);
                        return hash;
                    }
                case "SHA-512":
                    using (var sha512 = SHA512.Create()) {
                        var buffer = Encoding.GetEncoding(encoding).GetBytes(data);
                        var hash = sha512.ComputeHash(buffer, 0, buffer.Length);
                        return hash;
                    }
                default:
                    throw new ScriptRuntimeException("Failed to parse Encryption.");
            }
        }

        public static string hash_string_to_string(string encryption, string data) => hash_string_to_string(encryption, data, "UTF-8");
        public static string hash_string_to_string(string encryption, string data, string encoding) {
            switch (encryption) {
                case "MD5":
                    using (var md5 = MD5.Create()) {
                        var buffer = Encoding.GetEncoding(encoding).GetBytes(data);
                        var hash = md5.ComputeHash(buffer, 0, buffer.Length);
                        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    }
                case "SHA-1":
                    using (var sha1 = SHA1.Create()) {
                        var buffer = Encoding.GetEncoding(encoding).GetBytes(data);
                        var hash = sha1.ComputeHash(buffer, 0, buffer.Length);
                        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    }
                case "SHA-256":
                    using (var sha256 = SHA256.Create()) {
                        var buffer = Encoding.GetEncoding(encoding).GetBytes(data);
                        var hash = sha256.ComputeHash(buffer, 0, buffer.Length);
                        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    }
                case "SHA-384":
                    using (var sha384 = SHA384.Create()) {
                        var buffer = Encoding.GetEncoding(encoding).GetBytes(data);
                        var hash = sha384.ComputeHash(buffer, 0, buffer.Length);
                        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    }
                case "SHA-512":
                    using (var sha512 = SHA512.Create()) {
                        var buffer = Encoding.GetEncoding(encoding).GetBytes(data);
                        var hash = sha512.ComputeHash(buffer, 0, buffer.Length);
                        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    }
                default:
                    throw new ScriptRuntimeException("Failed to parse Encryption.");
            }
        }
    }
}
