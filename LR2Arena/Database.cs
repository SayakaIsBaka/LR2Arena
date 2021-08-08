using Microsoft.Data.Sqlite;
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

        public static bool IsBmsPresentInDb(string hash)
        {
            using (var connection = new SqliteConnection("Data Source=" + dbPath))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT hash
                    FROM song
                    WHERE hash = $hash
                ";
                command.Parameters.AddWithValue("$hash", hash);

                using (var reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }
    }
}
