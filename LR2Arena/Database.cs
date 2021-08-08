using System;
using System.IO;

namespace LR2Arena
{
    class Database
    {
        static string dbPath = "";

        public static void SetDbPathFromLr2Executable(string path)
        {
            string basePath = Path.GetDirectoryName(path);
            dbPath = basePath + "\\LR2files\\Database\\song.db";
            Console.WriteLine(dbPath);
        }
    }
}
