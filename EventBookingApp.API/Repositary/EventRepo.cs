using DataAcessLayer;
using DataAcessLayer.ViewModel;
using EventBookingApp.API.Data;
using EventBookingApp.API.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
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
         //private readonly IWebHostEnvironment _webHostEnvironment;

        public EventRepo(ApplicationDbContext context)
        {
            _context = context;
           
        }
     
        public async Task<Event>AddEvent(EventViewModel eventmodel)
        {
            //string uniqueFileName = UploadImage(eventmodel);
            Event events = new Event
            {
                EventTypes = eventmodel.EventTypes,
                Images = eventmodel.FileName
            };
            var result = await _context.AddAsync(events);
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
        public IEnumerable<eventTypeViewModel> GetEventsType()
        {
            List<eventTypeViewModel> vm = new List<eventTypeViewModel>();
            var data = _context.Events.Select(x => new
            {
                x.Id,
                x.EventTypes
            }).ToList();
            foreach (var item in data)
            {
                eventTypeViewModel e = new eventTypeViewModel();
                e.Id = item.Id;
                e.EventTypes = item.EventTypes;

                vm.Add(e);
               
            }

            return vm;
        }

        public async Task<IEnumerable<Event>> search(string EventTypes)
        {
            IQueryable<Event> query = _context.Events;
            if (!string.IsNullOrEmpty(EventTypes))
            {
                query = query.Where(o => o.EventTypes.ToLower().Contains(EventTypes.Trim().ToLower()));
            }
            return await query.ToListAsync();
        }

        public async Task<Event> UpdateEvent(EventViewModel eventmodel)
        {
            var result = await _context.Events.FirstOrDefaultAsync(x => x.Id == eventmodel.Id);
            if (result != null)
            {
                result.EventTypes = eventmodel.EventTypes;
                result.Images = eventmodel.FileName;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
       
        //private string UploadImage(EventViewModel eventmodel)
        //{
        //    string uniqueFileName = null;

        //    if (eventmodel.Images != null)
        //    {
        //        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
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
