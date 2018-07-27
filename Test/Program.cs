using CursesSharp;
using System;

namespace Test {
    class Program {

        static Random rand = new Random ();
        static void Main ( string[] args ) {
            Curses.Init ();

            if (Curses.HasColor ()) {
                Curses.StartColor ();

                int bg = Colors.BLACK;
                if (Curses.SetDefaultColor ())
                    bg = -1;

                Curses.InitPair (1, Colors.BLUE, bg);
                Curses.InitPair (2, Colors.CYAN, bg);
            }

            int maxy = Curses.Lines;


            Curses.Cursor = false;
            Curses.Blocking = false;
            Curses.Echo = false;
            Curses.Keypad = true;

            int start, end, row, diff, flag, direction;
            short i;

            Curses.Init ();

            int[] color_table =
{
    Colors.RED, Colors.BLUE, Colors.GREEN, Colors.CYAN,
    Colors.RED, Colors.MAGENTA, Colors.YELLOW, Colors.WHITE
};
            for (i = 0; i < 8; i++)
                Curses.InitPair (i+1, color_table[i], Colors.BLACK);

            flag = 0;

            while (Curses.GetCh ().IsEof ())      /* loop until a key is hit */
            {
                do {
                    start = rand.Next (Curses.Cols - 3);
                    end = rand.Next (Curses.Cols - 3);
                    start = (start < 2) ? 2 : start;
                    end = (end < 2) ? 2 : end;
                    direction = (start > end) ? -1 : 1;
                    diff = Math.Abs (start - end);

                } while (diff < 2 || diff >= Curses.Lines - 2);

                for (row = 0; row < diff; row++) {
                    Curses.Add (Curses.Lines- row, row * direction + start,
                        (direction < 0) ? "\\" : "/");

                    if (flag++ > 0) {
                        myrefresh ();
                        Curses.Erase ();
                        flag = 0;
                    }
                }

                if (flag++ > 0) {
                    myrefresh ();
                    flag = 0;
                }

                explode (Curses.Lines - row, diff * direction + start);
                Curses.Erase ();
                myrefresh ();
            }

            Curses.Exit ();
        }

        static void explode ( int row, int col ) {
            Curses.Erase ();
            Curses.Add (row, col, "-");
            myrefresh ();

            --col;

            get_color ();
            Curses.Add (row - 1, col, " - ");
            Curses.Add (row, col, "-+-");
            Curses.Add (row + 1, col, " - ");
            myrefresh ();

            --col;

            get_color ();
            Curses.Add (row - 2, col, " --- ");
            Curses.Add (row - 1, col, "-+++-");
            Curses.Add (row, col, "-+#+-");
            Curses.Add (row + 1, col, "-+++-");
            Curses.Add (row + 2, col, " --- ");
            myrefresh ();

            get_color ();
            Curses.Add (row - 2, col, " +++ ");
            Curses.Add (row - 1, col, "++#++");
            Curses.Add (row, col, "+# #+");
            Curses.Add (row + 1, col, "++#++");
            Curses.Add (row + 2, col, " +++ ");
            myrefresh ();

            get_color ();
            Curses.Add (row - 2, col, "  #  ");
            Curses.Add (row - 1, col, "## ##");
            Curses.Add (row, col, "#   #");
            Curses.Add (row + 1, col, "## ##");
            Curses.Add (row + 2, col, "  #  ");
            myrefresh ();

            get_color ();
            Curses.Add (row - 2, col, " # # ");
            Curses.Add (row - 1, col, "#   #");
            Curses.Add (row, col, "     ");
            Curses.Add (row + 1, col, "#   #");
            Curses.Add (row + 2, col, " # # ");
            myrefresh ();
        }

        static void myrefresh () {
            Curses.Sleep (200);
            Curses.Move (Curses.Lines - 1, Curses.Cols - 1);
            Curses.Refresh ();
        }

        static void get_color () {
            //chtype bold = (rand () % 2) ? A_BOLD : A_NORMAL;
            //attrset (COLOR_PAIR (rand () % 8) | bold);
            Curses.SetColor (rand.Next (1, 9), rand.NextBool () ? Attrs.NORMAL : Attrs.BOLD);
        }
    }
}
