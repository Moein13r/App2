using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Text;

namespace App2.DataBase
{
    class Constant
    {
        public const string DatabaseFileName = "Butterfly_db.db3";
        public const SQLite.SQLiteOpenFlags flags = SQLite.SQLiteOpenFlags.Create | SQLite.SQLiteOpenFlags.ReadWrite | SQLite.SQLiteOpenFlags.SharedCache;
        public static string databasePath { 
            get 
            { var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath,DatabaseFileName);
            } 
        }

    }
}
