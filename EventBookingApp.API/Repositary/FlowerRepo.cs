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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FlowerRepo(ApplicationDbContext context,IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<Flower> AddFlower(FlowerViewModel flower)
        {
            string uniqueFileName = UploadImage(flower); 
            Flower flowers = new Flower
            {
               FlowerType = flower.FlowerType,
               FlowerImage = uniqueFileName,
               FlowerCost = flower.FlowerCost
            };
            _context.Add(flowers);
            await _context.SaveChangesAsync();
            return flowers;
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
            return await _context.Flowers.FirstOrDefaultAsync(x=>x.FlowerId == id);
        }

        public async Task<IEnumerable<Flower>> GetFlowers()
        {
            return await _context.Flowers.ToListAsync();
        }
        public async Task<Flower> UpdateFlower(Flower flower)
        {
            var result = await _context.Flowers.FirstOrDefaultAsync(x => x.FlowerId == flower.FlowerId);
            if (result != null)
            {
                result.FlowerType = flower.FlowerType;
                result.FlowerImage = flower.FlowerImage;
                result.FlowerCost = flower.FlowerCost;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
        private string UploadImage(FlowerViewModel flower)
        {
            string uniqueFileName = null;

            if (flower.FlowerImage != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + flower.FlowerImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    flower.FlowerImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

    }
}
