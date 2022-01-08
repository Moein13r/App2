using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App2.Models;
using SQLite;

namespace App2.Database
{
    internal class GameDatabse
    {
        static public SQLiteAsyncConnection database;
        public static readonly AsyncLazy<GameDatabse> Instnace = new AsyncLazy<GameDatabse>(async () =>
        {
            var instance = new GameDatabse();
            CreateTableResult result = await database.CreateTableAsync<Models.Score>();
            return instance;
        });
        public GameDatabse()
        {
            database = new SQLiteAsyncConnection(Constant.databsepath, Constant.falgs);
        }
        public Task<List<Models.Score>> GetItemAsync()
        {
            return database.Table<Models.Score>().ToListAsync();
        }
        public Task<List<Models.Score>> GetItem()
        {
            return database.QueryAsync<Models.Score>("SELECT * FROM [Score]");
        }
        public Task<List<Models.Score>> GetBestScore(string name)
        {
            return database.QueryAsync<Models.Score>("SELECT score,state FROM [Score] where name='" + name + "' ORDER BY score desc limit 3");
        }
        public Task<int> SaveItem(Models.Score record)
        {
            return database.InsertOrReplaceAsync(record);
        }
    }
}
