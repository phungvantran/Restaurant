using Restaurant.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Persistence
{
    public class SQLiteFoodStore : IFoodStore
    {
        private SQLiteAsyncConnection _connection;

        public SQLiteFoodStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Food>();
        }
        public async Task AddFood(Food food)
        {
            await _connection.InsertAsync(food);
        }

        public async Task DeleteFood(Food food)
        {
            await _connection.DeleteAsync(food);
        }

        public async Task<Food> GetFood(int id)
        {
            return await _connection.FindAsync<Food>(id);
        }

        public async Task<IEnumerable<Food>> GetFoodsAsync()
        {
            return await _connection.Table<Food>().ToListAsync();
        }

        public async Task UpdateFood(Food food)
        {
            await _connection.UpdateAsync(food);
        }
    }
}
