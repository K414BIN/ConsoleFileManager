using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleFileManager
{
    class Windows
    {
        protected static int origRow;
        protected static int origCol;
        struct Square
        {
            public string model1;
            public string model2;
            public string model3;
            public string model4;
            public string model5;

            public Square(int n)
            {
                model1 = "■";
                model2 = "█";
                model3 = "▓";
                model4 = "▒";
                model5 = "░";
            }
        }
        protected static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        public static void initWindow()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Square sq = new Square(0);
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;
            int windowYTop = 0;
            int windowXTop = 0;
            int windowYBottom = Console.LargestWindowHeight / 4 + Console.LargestWindowHeight / 6;
            int windowXBottom = Console.LargestWindowWidth / 3 + Console.LargestWindowWidth / 3;
            WriteAt("+", windowXTop, windowYTop);
            for (int i = windowYTop + 1; i <= windowYBottom; i++) WriteAt("!", windowXTop, i);
            WriteAt("+", windowXTop, windowYBottom);
            for (int k = windowXTop + 1; k <= windowXBottom; k++) WriteAt("-", k, windowYBottom);
            for (int k = windowXTop + 2; k < windowXBottom - 1; k++) WriteAt("#", k, windowYBottom + 1);
            WriteAt("/", windowXBottom - 1, windowYBottom + 1);
            WriteAt("\\", windowXTop + 1, windowYBottom + 1);
            WriteAt("+", windowXBottom, windowYBottom);
            for (int k = windowYTop + 1; k < windowYBottom; k++) WriteAt("!", windowXBottom, k);
            WriteAt("+", windowXBottom, windowXTop);
            for (int i = windowXTop + 1; i < windowXBottom; i++) WriteAt("-", i, windowYTop);
        }
    }
}
