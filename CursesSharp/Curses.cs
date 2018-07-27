using System;
using System.Runtime.InteropServices;

namespace CursesSharp {
    public class Curses {

        public static IntPtr StdScr { get; private set; }

        public static void Init () {
            if (StdScr != IntPtr.Zero) { return; }
            IntPtr ret = Native.initscr ();
            NativeException.Verify (ret);
            StdScr = ret;
        }

        public static void Exit () {
            int ret = Native.endwin ();
            NativeException.Verify (ret);
            StdScr = IntPtr.Zero;
        }

        public static void Refresh () { int ret = Native.wrefresh (StdScr); NativeException.Verify (ret); }
        public static void Sleep ( int ms ) { int ret = Native.napms (ms); NativeException.Verify (ret); }
        public static void Erase () { int ret = Native.werase (StdScr); NativeException.Verify (ret); }


        // setting
        public static bool Blocking { set { { int ret = Native.nodelay (StdScr, !value); NativeException.Verify (ret); } } }
        public static bool Echo { set { { int ret = value ? Native.echo () : Native.noecho (); NativeException.Verify (ret); } } }
        public static bool Cursor { set { { int ret = Native.curs_set (value); NativeException.Verify (ret); } } }
        public static bool Keypad { set { { int ret = Native.keypad (StdScr, value); NativeException.Verify (ret); } } }

        // output
        public static void Add ( char ch ) { Native.waddch (StdScr, ch); }
        public static void Add ( int l, int c, char ch ) { Native.mvwaddch (StdScr, l, c, ch); }
        public static void Add ( string str ) { Native.waddnstr (StdScr, str, str.Length); }
        public static void Add ( int l, int c, string str ) { Native.mvwaddnstr (StdScr, l, c, str, str.Length); }
        public static void Move ( int l, int c ) { Native.wmove (StdScr, l, c); }


        // input
        public static char GetCh () { return (char)Native.wgetch (StdScr); }
        public static char GetCh ( int x, int y ) { return (char)Native.mvwgetch (StdScr, y, x); }
        public static void UnGetCh ( char ch ) { Native.ungetch (ch); }

        // ability
        public static int Lines { get { return Native.getInt32 ("LINES"); } }
        public static int Cols { get { return Native.getInt32 ("COLS"); } }
        public static int TabSize { get { return Native.getInt32 ("TABSIZE"); } }
        public static int MaxColor { get { return Native.getInt32 ("COLORS"); } }
        public static int MaxColorPair { get { return Native.getInt32 ("COLOR_PAIRS"); } }

        // color
        public static void StartColor () { int ret = Native.start_color (); NativeException.Verify (ret); }
        public static void InitPair ( int pair, int fg, int bg ) { int ret = Native.init_pair (pair, fg, bg); NativeException.Verify (ret); }
        public static bool HasColor () { return Native.has_colors (); }
        public static bool SetDefaultColor () { int ret = Native.use_default_colors (); NativeException.Verify (ret); return ret == 0; }
        public static void SetColor ( int color, uint attr = Attrs.NORMAL ) { int ret = Native.wattr_set (StdScr, attr, color, IntPtr.Zero); NativeException.Verify (ret); }
    }
}
