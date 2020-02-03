using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.IO;
using PCLStorage;
using Windows.Foundation;

namespace DataAccessLibrary
{
    public static class DataAccess
    {
        public async static void InitializeDatabase()
        {
            var currentDirectoryPath = Environment.CurrentDirectory;
            using (FileStream fs = new FileStream(currentDirectoryPath, FileMode.OpenOrCreate))
            {
                File.Create("StaffManagerDB.db");
            }

            //await ApplicationData.Current.LocalFolder.CreateFileAsync("sqliteSample.db", CreationCollisionOption.OpenIfExists);
            string dbpath = Path.Combine(AppContext.BaseDirectory, "StaffManagerDB.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS MyTable (Primary_Key INTEGER PRIMARY KEY, " +
                    "Text_Entry NVARCHAR(2048) NULL)";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }

        public static void AddData(string inputText)
        {
            string dbpath = Path.Combine(Environment.CurrentDirectory, "StaffManagerDB.db");
            using (SqliteConnection db =
              new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO MyTable VALUES (NULL, @Entry);";
                insertCommand.Parameters.AddWithValue("@Entry", inputText);

                insertCommand.ExecuteReader();

                db.Close();
            }

        }

        public static List<String> GetData()
        {
            List<String> entries = new List<string>();

            string dbpath = Path.Combine(Environment.CurrentDirectory, "StaffManagerDB.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT Text_Entry from MyTable", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                }

                db.Close();
            }

            return entries;
        }
    }
}
