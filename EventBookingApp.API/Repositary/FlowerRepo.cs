using DataAcessLayer;
using DataAcessLayer.ViewModel;
using EventBookingApp.API.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EventBookingApp.API.Repositary
{
    public class FlowerRepo : IFlowerRepo
    {
        private readonly ApplicationDbContext _context;

        public FlowerRepo(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<Flower> AddFlower(FlowerViewModel flower)
        {

            Flower flowers = new Flower
            {
                FlowerType = flower.FlowerType,
                FlowerImage = flower.FileName,
                FlowerCost = flower.FlowerCost,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
            var result = await _context.AddAsync(flowers);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Flower> DeleteFlower(int id)
        {
            var result = await _context.Flowers.Where(x => x.FlowerId == id).FirstOrDefaultAsync();
            if (result != null)
            {
                _context.Flowers.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<Flower> GetFlower(int id)
        {
            return await _context.Flowers.FirstOrDefaultAsync(x => x.FlowerId == id);
        }
        //public async Task<IEnumerable<Flower>> Search(string FlowerType)
        //{
        //    IQueryable<Flower> query = _context.Flowers;
        //    if (!string.IsNullOrEmpty(FlowerType))
        //    {
        //        query = query.Where(o => o.FlowerType.ToLower().Contains(FlowerType.Trim().ToLower()));
        //    }
        //    return await query.ToListAsync();
        //}

        public async Task<IEnumerable<Flower>> GetFlowers()
        {
            return await _context.Flowers.ToListAsync();
        }

        public string GetImagename(int id)
        {
            var Id = id;
            var data = _context.Flowers.Where(x => x.FlowerId == Id).Select(x => x.FlowerImage).FirstOrDefault();
            return data;
        }

        public async Task<Flower> UpdateFlower(FlowerViewModel flower)
        {
            var result = await _context.Flowers.FirstOrDefaultAsync(x => x.FlowerId == flower.Id);
            if (result != null)
            {
                result.FlowerType = flower.FlowerType;
                result.FlowerImage = flower.FileName;
                result.FlowerCost = flower.FlowerCost;
                result.UpdatedDate = DateTime.Now;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }


    }
}
