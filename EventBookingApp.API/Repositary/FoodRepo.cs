using DataAcessLayer;
using EventBookingApp.API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBookingApp.API.Repositary
{
    public class FoodRepo : IFoodRepo
    {
        private readonly ApplicationDbContext _context;
        public FoodRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Food> AddFood(Food food)
        {
            var result = await _context.Foods.AddAsync(food);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Food> DeleteFood(int id)
        {
            var result = await _context.Foods.FirstOrDefaultAsync(x => x.FoodId == id);
            if(result != null)
            {
                _context.Foods.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Food> GetFood(int id)
        {
            return await _context.Foods.FirstOrDefaultAsync(x => x.FoodId == id);
        }

        public async Task<IEnumerable<Food>> GetFoods()
        {
            return await _context.Foods.ToListAsync();
        }

        //public async Task<IEnumerable<Food>> Search(string FoodType)
        //{
        //    IQueryable<Food> query = _context.Foods;
        //    if (!string.IsNullOrEmpty(FoodType))
        //    {
                
        //        query = query.Where(o => o.FoodType.ToLower().Contains(FoodType.Trim().ToLower()));
        //    }
        //    return await query.ToListAsync();
        //}

        public async Task<Food> UpdateFood(Food food)
        {
            var result = await _context.Foods.FirstOrDefaultAsync(x => x.FoodId == food.FoodId);
            if (result != null)
            {
                result.FoodType = food.FoodType;
                result.FoodCost = food.FoodCost;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
     
    }
}
