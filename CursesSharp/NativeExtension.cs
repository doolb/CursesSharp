using System;

namespace CursesSharp {
    public static class NativeExtension {
        public static bool IsEof ( this char c ) {
            return (short)c == -1;
        }

        public static bool NextBool ( this Random rand ) {
            return rand.Next () % 2 == 0;
        }
    }
}
