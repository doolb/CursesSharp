using System;
using System.Runtime.InteropServices;

namespace CursesSharp {
    internal static partial class Native {

        [DllImport ("kernel32.dll", SetLastError = true)] internal static extern IntPtr GetProcAddress ( IntPtr hModule, string procName );
        [DllImport ("kernel32.dll", SetLastError = true)] internal static extern IntPtr LoadLibrary ( string lpszLib );
        public static int getInt32 ( string name ) {
            int value = 0;
            IntPtr hdl = Native.LoadLibrary ("Curses.dll");
            if (hdl != IntPtr.Zero) {
                IntPtr addr = Native.GetProcAddress (hdl, name);
                if (addr != IntPtr.Zero) { value = Marshal.ReadInt32 (addr); }
            }
            return value;
        }

        [DllImport ("Curses", CallingConvention = CallingConvention.Cdecl)] public static extern IntPtr initscr ();
        [DllImport ("Curses", CallingConvention = CallingConvention.Cdecl)] public static extern int endwin ();
        [DllImport ("Curses", CallingConvention = CallingConvention.Cdecl)] public static extern Boolean isendwin ();
        [DllImport ("Curses", CallingConvention = CallingConvention.Cdecl)] public static extern int resize_term ( int nlines, int ncols );



        [DllImport ("Curses", CallingConvention = CallingConvention.Cdecl)] public static extern int wrefresh ( IntPtr win );
        [DllImport ("Curses", CallingConvention = CallingConvention.Cdecl)] public static extern int napms ( int ms );
        [DllImport ("Curses", CallingConvention = CallingConvention.Cdecl)] public static extern int werase ( IntPtr win );


        // output
        [DllImport ("Curses", CallingConvention = CallingConvention.Cdecl)] public static extern int wechochar ( IntPtr win, uint ch );
        [DllImport ("Curses", CallingConvention = CallingConvention.Cdecl)] public static extern int waddch ( IntPtr win, uint ch );
        [DllImport ("Curses", CallingConvention = CallingConvention.Cdecl)] public static extern int mvwaddch ( IntPtr win, int y, int x, uint ch );
        [DllImport ("Curses", CallingConvention = CallingConvention.Cdecl)] public static extern int waddnstr ( IntPtr win, String str, int n );
        [DllImport ("Curses", CallingConvention = CallingConvention.Cdecl)] public static extern int mvwaddnstr ( IntPtr win, int y, int x, String str, int n );
        [DllImport ("Curses", CallingConvention = CallingConvention.Cdecl)] public static extern int wmove ( IntPtr win, int y, int x );

        // input
        [DllImport ("Curses", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)] public static extern int wgetch ( IntPtr win );
        [DllImport ("Curses", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)] public static extern int mvwgetch ( IntPtr win, int y, int x );
        [DllImport ("Curses", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)] public static extern int ungetch ( int ch );
        [DllImport ("Curses", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)] public static extern int flushinp ();

        // setting
        [DllImport ("Curses", CallingConvention = CallingConvention.Cdecl)] public static extern int nodelay ( IntPtr win, bool flag );
        [DllImport ("Curses", CallingConvention = CallingConvention.Cdecl)] public static extern int noecho ();
        [DllImport ("Curses", CallingConvention = CallingConvention.Cdecl)] public static extern int echo ();
        [DllImport ("Curses", CallingConvention = CallingConvention.Cdecl)] public static extern int curs_set ( bool vis );
        [DllImport ("Curses", CallingConvention = CallingConvention.Cdecl)] public static extern int keypad ( IntPtr win, bool bf );


        // color
        [DllImport ("Curses", CallingConvention = CallingConvention.Cdecl)] public static extern int start_color ();
        [DllImport ("Curses", CallingConvention = CallingConvention.Cdecl)] public static extern bool has_colors ();
        [DllImport ("Curses", CallingConvention = CallingConvention.Cdecl)] public static extern int init_pair ( int pair, int fg, int bg );
        [DllImport ("Curses", CallingConvention = CallingConvention.Cdecl)] public static extern int use_default_colors ();
        [DllImport ("Curses", CallingConvention = CallingConvention.Cdecl)] public static extern int wattr_set ( IntPtr win, uint attr, int color, IntPtr opt );

    }
}
