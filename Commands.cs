using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleFileManager
{
    class Commands
    {
        public class Command
        {
            public string Kommand { get; set; }
            public byte HowManyArg { get; set; }
            public byte Index { get; set; }
        }
        public static readonly Dictionary<int, Command> dicOfWinCommands = new Dictionary<int, Command>();


        static string[] CommandsInSystem()
        {
            string[] allCommands = new string[] {
                "chdir ",
                "cls ",
                "rmdir ",
                "type ",
                "erase ",
                "dir ",
                "echo ",
                "exit ",
                "mkdir ",
                "copy ",
                "move ",
                "rename "
                };
            return allCommands;
        }
        public static void InitCommandDictionary()
        {
            byte x = 1;
            byte z = x;
            var testArr = CommandsInSystem();
            for (int i = 0; i < testArr.Length; i++)
            {
                int y = testArr[i].GetHashCode();
                if (i > testArr.Length - 4) { x = 2; }
                dicOfWinCommands.Add(y, new Command { Kommand = testArr[i], HowManyArg = x, Index = z });
                z++;
            }

        }
        

    }
}
