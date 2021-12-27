using App2.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App2.DataBase
{
    class GameDatabase
    {
        static SQLiteAsyncConnection Database;
        public GameDatabase()
        {
            Database = new SQLiteAsyncConnection(Constant.databasePath,Constant.flags);
        }

        static SQLite.SQLiteConnection Databse;
        //public  static GameDatabase instance
        //{
        //    get
        //    {
        //        Task.Run(async()=>await Database.CreateTablesAsync<Score>());
        //        return instance;
        //    }
        //}


        //public Task<string> GetItemAsync()
        //{
        // return 
        //}
    }
}
