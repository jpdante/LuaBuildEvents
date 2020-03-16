using System;
using System.Linq;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace LuaBuildEvents.SSH {
    public class LuaPrivateKeyAuthenticationMethod : LuaAuthenticationMethod {

        public LuaPrivateKeyAuthenticationMethod(string username, params PrivateKeyFile[] keyFiles) {
            AuthenticationMethod = new PrivateKeyAuthenticationMethod(username, keyFiles);
        }

        public static LuaPrivateKeyAuthenticationMethod New(string username, params LuaPrivateKeyFile[] luaKeyFiles) => new LuaPrivateKeyAuthenticationMethod(username, luaKeyFiles.Select(privateKeyFile => privateKeyFile.GetPrivateKeyFile()).ToArray());

        #region Variables

        public string name => ((PrivateKeyAuthenticationMethod)AuthenticationMethod).Name;

        public string username => ((PrivateKeyAuthenticationMethod)AuthenticationMethod).Username;

        public string[] allowedAuthentications => ((PrivateKeyAuthenticationMethod)AuthenticationMethod).AllowedAuthentications;

        #endregion

    }
}