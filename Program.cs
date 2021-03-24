using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;


namespace ConsoleFileManager
{
    class Program
    {
        const string fileErrors = "random_name_exception.txt";
        static void Main(string[] args)
        {
            Commands.InitCommandDictionary();
            string docPath = "dir  \\temp";
            //      Commands.dicOfWinCommands.Select(y => "Key [" + y.Key + "]: Command: " + y.Value.Kommand + " How Many Args = " + y.Value.HowManyArg + " Index = " + y.Value.Index).ToList().ForEach(Console.WriteLine);
            Rabina(docPath);
        }
        public static int enoughArguments(int count, string[] str)
        {

            int howMany = Commands.dicOfWinCommands[count].HowManyArg;
            int result = Commands.dicOfWinCommands[count].Index;
            int argsCount = 0;

            for (int k = 0; k < str.Length; k++)
                if (!String.IsNullOrWhiteSpace(str[k])) argsCount++;
            try
            {
                if (argsCount < howMany) { throw new InvalidOperationException("Недостаточно аргументов в команде!"); }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                File.AppendAllText(fileErrors, ex.ToString());
                File.AppendAllText(fileErrors, Environment.NewLine);
                result = -1;
            }

            //   Console.WriteLine(result);
            return result;
        }
        public static string[] splitStringArg(string str, int arg)
        {

            // Отделяем от команды аргументы из входящей строки 
            string temp = str.Substring(arg, str.Length - arg);
            string[] text = temp.Split(' ');
            // Самое больше количество аргументов - 2
            string[] result = new string[2];
            // Команда как первая часть строки и аргументы последующие части.
            int penultimate = text.Length - 2;
            // Аргумент отсутствует у команды. 
            if (penultimate < 0) return result;
            // Предпоследний аргумент                  
            if (text[penultimate] != null && penultimate > 0)
            {
                result[0] = text[penultimate];
            }
            // Последний аргумент
            if (text[text.Length - 1] != null)
            {
                result[result.Length - 1] = text[text.Length - 1];
            }
            //   for (int k = 0; k < result.Length; k++) Console.WriteLine(result[k]);
            return result;
        }
        static void runCommand(string command)
        {
            //  Console.WriteLine(command);
            if (command != string.Empty)
            {
                Process process = new Process();
                process.StartInfo.FileName = @"cmd.exe";
                process.StartInfo.Arguments = "/C " + command;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                Console.WriteLine(output);
                process.WaitForExit();
            }
        }

        public static string chooseCommand(int val, string[] args)
        {
            string command = null;
            int caseSwitch = Commands.dicOfWinCommands[val].Index;
            command = Commands.dicOfWinCommands[val].Kommand.ToString();
            command = command + " ";
            command = command + args[0];
            command = command + " ";
            command = command + args[1];

            switch (caseSwitch)
            {
                case 1:
                    try
                    {
                        if (!Directory.Exists(args[1])) throw new DirectoryNotFoundException();
                        else
                        {
                            Directory.SetCurrentDirectory(args[1]);
                            //       Directory.GetParent(args[1]);
                            //               Console.WriteLine("Root directory: {0}", Directory.GetDirectoryRoot(args[1]));
                            //             Console.WriteLine("Current directory: {0}", Directory.GetCurrentDirectory());
                            //         Console.WriteLine("Parent directory: {0}", Directory.GetParent(args[1]));
                        }
                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        File.AppendAllText(fileErrors, ex.ToString());
                        File.AppendAllText(fileErrors, Environment.NewLine);

                    }
                    finally { command = null; }
                    break;
                case 2:
                    Clear(10, 10, 80, 12);
                    command = null;
                    break;
                case 3:
                    try
                    {
                        if (Directory.Exists(args[1]))
                        {
                            Directory.Delete(args[1], false);
                            // Directory.Delete(args[1],true);
                        }
                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        File.AppendAllText(fileErrors, ex.ToString());
                        File.AppendAllText(fileErrors, Environment.NewLine);

                    }
                    finally { command = null; }
                    break;
                case 4:
                    try
                    {
                        if (!File.Exists(args[1])) throw new FileNotFoundException();

                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        File.AppendAllText(fileErrors, ex.ToString());
                        File.AppendAllText(fileErrors, Environment.NewLine);
                        command = null;
                    }

                    break;
                case 5:
                    try
                    {
                        if (!File.Exists(args[1])) throw new FileNotFoundException();
                        else { File.Delete(args[1]); }
                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        File.AppendAllText(fileErrors, ex.ToString());
                        File.AppendAllText(fileErrors, Environment.NewLine);

                    }
                    finally { command = null; }
                    break;
                case 6:
                    try
                    {
                        if (!Directory.Exists(args[1])) throw new DirectoryNotFoundException();

                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        File.AppendAllText(fileErrors, ex.ToString());
                        File.AppendAllText(fileErrors, Environment.NewLine);
                        command = null;
                    }

                    break;
                case 7:
                    Console.WriteLine(args[1]);
                    command = null;
                    break;
                case 8:
                    Environment.Exit(0);
                    command = null;
                    break;
                case 9:
                    try
                    {
                        if (!Directory.Exists(args[1]))
                        {
                            Directory.CreateDirectory(args[1]);
                        }
                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        File.AppendAllText(fileErrors, ex.ToString());
                        File.AppendAllText(fileErrors, Environment.NewLine);

                    }
                    finally { command = null; }
                    break;
                case 10:
                    try
                    {

                        if (!File.Exists(args[0])) throw new FileNotFoundException();
                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        File.AppendAllText(fileErrors, ex.ToString());
                        File.AppendAllText(fileErrors, Environment.NewLine);
                        command = null;
                    }
                    break;
                case 11:
                    try
                    {
                        if (!Directory.Exists(args[0])) if (!File.Exists(args[0])) throw new FileNotFoundException();
                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        File.AppendAllText(fileErrors, ex.ToString());
                        File.AppendAllText(fileErrors, Environment.NewLine);
                        command = null;
                    }
                    break;
                case 12:
                    try
                    {
                        if (!File.Exists(args[0])) throw new FileNotFoundException();
                        if (File.Exists(args[1])) throw new Exception("Файл с таким именем уже есть!");
                    }

                    catch (System.Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        File.AppendAllText(fileErrors, ex.ToString());
                        File.AppendAllText(fileErrors, Environment.NewLine);
                        command = null;
                    }
                    break;
            }

            //      Console.WriteLine(command);
            return command;
        }
        static void Clear(int x, int y, int width, int height)
        {
            int curTop = Console.CursorTop;
            int curLeft = Console.CursorLeft;
            for (; height > 0;)
            {
                Console.SetCursorPosition(x, y + --height);
                Console.Write(new string(' ', width));
            }
            Console.SetCursorPosition(curLeft, curTop);
        }
        public static void Rabina(string s)
        {
            string str = s.ToLower();
            string nom = null;
            ICollection<int> keys = Commands.dicOfWinCommands.Keys;
            var commands = Commands.dicOfWinCommands.Values;
            foreach (var res in commands)
            {
                int len = res.Kommand.Length;
                int i = 0;
                bool flag = true;
                if (str.Length < len) continue;
                do
                {
                    //Сдвигаемся на одну букву и ищем подстроку в строку дальше
                    nom = str.Substring(i, len);
                    int shash = nom.GetHashCode();
                    // дошли до конца строки и нет совпадений - выход по break
                    if (i == (str.Length - len)) break;
                    if (keys.Contains(shash))
                    {
                        string[] tempArgs = splitStringArg(s, i);
                        if (enoughArguments(shash, tempArgs) > 0)
                        {
                            runCommand(chooseCommand(shash, tempArgs));
                        }
                        flag = false;
                    }
                    i++;

                } while (flag);
                if (flag == false) break;
            }
        }
    }

}
