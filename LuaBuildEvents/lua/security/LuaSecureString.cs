﻿using System;
using System.Security;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace LuaBuildEvents.lua.security {
    public class LuaSecureString : IDisposable {

        private readonly SecureString _secureString;

        public SecureString GetSecureString() { return _secureString; }

        public LuaSecureString() { _secureString = new SecureString(); }

        public LuaSecureString(SecureString secureString) { _secureString = secureString; }


        public void Dispose() {
            _secureString?.Dispose();
        }
    }
}