using DataAcessLayer;
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
    public class EventRepo : IEventRepo
    {
        private readonly ApplicationDbContext _context;
        //private readonly string uniqueFileName;
        //  private readonly IWebHostEnvironment _webHostEnvironment;

        public EventRepo(ApplicationDbContext context)
        {
            _context = context;
        }   
        public async Task<Event> AddEvent(Event eventmodel)
        {
            var result = await _context.AddAsync(eventmodel);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Event> DeleteEvent(int id)
        {
            var result = await _context.Events.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (result != null)
            {
                _context.Events.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<Event> GetEvent(int id)
        {
            return await _context.Events.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Event>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }
        public async Task<Event> UpdateEvent(Event eventmodel)
        {
            var result = await _context.Events.FirstOrDefaultAsync(x => x.Id == eventmodel.Id);
            if (result != null)
            {
                result.EventTypes = eventmodel.EventTypes;
                result.Images = eventmodel.Images;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }



        //public string UploadImage(EventViewModel eventmodel)
        //{
        //    string uniqueFileName = null;

        //    if (eventmodel.Images != null)
        //    {
        //        string uploadsFolder = Path.Combine("Resources", "images");
        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + eventmodel.Images.FileName;
        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            eventmodel.Images.CopyTo(fileStream);
        //        }
        //    }
        //    return uniqueFileName;
        //}


    }
}
