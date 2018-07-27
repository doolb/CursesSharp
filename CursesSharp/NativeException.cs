using System;
using System.Runtime.CompilerServices;

namespace CursesSharp {
    internal class NativeException : Exception {
        internal NativeException () { }
        internal NativeException ( string message ) : base (message) { }
        internal NativeException ( string message, Exception inner ) : base (message, inner) { }

        internal static void Verify ( int result, [CallerMemberName]string fname = null ) {
            if (result == -1)
                throw new NativeException (fname + "() returned ERR");
        }
        internal static void Verify ( IntPtr result, [CallerMemberName]string fname = null ) {
            if (result == IntPtr.Zero)
                throw new NativeException (fname + "() returned NULL");
        }
    }
}
