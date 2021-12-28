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

        public static readonly AsyncLazy<GameDatabase> Instance = new AsyncLazy<GameDatabase>(async () =>
        {
            var instance = new GameDatabase();
            CreateTableResult result = await Database.CreateTableAsync<Score>();
            return instance;
        });
        public GameDatabase()
        {        
            Database = new SQLiteAsyncConnection(Constant.databasePath, Constant.flags);
        }
        public Task<List<Score>> GetItem()
        {
            return Database.QueryAsync<Score>("SELECT * FROM [Score]");
        }
        public Task<List<Score>>GetBestState(string Name)
        {
            return Database.QueryAsync<Score>("SELECT state FROM [Score] WHERE name='"+Name+"'");
        }
        public Task SaveItem(Score item)
        {
            return Database.InsertOrReplaceAsync(item);
        }
        public Task DeleteItem(Score item)
        {
            return Database.DeleteAsync<Score>(item);
        }
    }
}
