using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ConsoleFileManager
{
    class DirTree
    {
        public static void filesTree(string workDir)
        {
            string fileTree = "DIRtree.txt";
            if (Directory.Exists(workDir))
            {
                string[] entries = Directory.GetFileSystemEntries(workDir, "*", SearchOption.AllDirectories);
                for (int t = 0; t < entries.Length; t++)
                {
                    File.AppendAllText(fileTree, Environment.NewLine);
                    File.AppendAllText(fileTree, entries[t]);
                }
            }
        }
    }
}
