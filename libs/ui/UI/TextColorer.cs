using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    internal class TextColorer
    {
        internal static void MenuHeader(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        internal static void Alert(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str);
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        internal static void Notify(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        internal static void MenuChoise(string str)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }
}
