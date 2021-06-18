using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.ViewModels
{
    public interface IFoodStore
    {
        Task<IEnumerable<Food>> GetFoodsAsync();
        Task<Food> GetFood(int id);
        Task AddFood(Food food);
        Task UpdateFood(Food food);
        Task DeleteFood(Food food);
    }
}
