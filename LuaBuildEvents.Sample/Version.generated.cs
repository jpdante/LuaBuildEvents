using System;
using System.Collections.Generic;
using System.Text;

namespace LuaBuildEvents.Sample {
    public static class Version {

        public static readonly int Major = 1;
        public static readonly int Minor = 0;
        public static readonly int Patch = 0;
        public static readonly int Build = 8;

        public static string GetVersion() { return $"{Major}.{Minor}.{Patch} Build {Build}"; }

    }
}
