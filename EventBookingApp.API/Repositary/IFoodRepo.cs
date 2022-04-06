using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBookingApp.API.Repositary
{
    public interface IFoodRepo
    {
        Task<IEnumerable<Food>> Search(string FoodType);
        Task<Food> GetFood(int id);
        Task<IEnumerable<Food>> GetFoods();
        Task<Food> AddFood(Food food);
        Task<Food> UpdateFood(Food food);
        Task<Food> DeleteFood(int id);
    }
}
