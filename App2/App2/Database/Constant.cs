using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace App2.Database
{
    internal class Constant
    {
        static public string databaseName = "Butterfly_db.db3";
        static public SQLite.SQLiteOpenFlags falgs =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;
        static public string databsepath
        {
            get
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                return Path.Combine(path,databaseName);
            }
        }
    }
}
