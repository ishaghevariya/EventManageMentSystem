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

        public async Task<Event> AddEvent(EventViewModel eventmodel)
        {
            //string uniqueFileName = UploadImage(eventmodel);
            Event events = new Event
            {
                EventTypes = eventmodel.EventTypes,
                EventCost = eventmodel.EventCost,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
            var result = await _context.AddAsync(events);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public string AddImgLink(string imgName, EventGalleryModel pvm)
        {
            var data = _context.EventGalleries.Where(x => x.ImageName == imgName).FirstOrDefault();
            data.URL = pvm.URL;
            _context.SaveChanges();
            return "true";
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

        public void DeleteImage(string id)
        {
            var Id = Convert.ToInt32(id);
            var data = _context.EventGalleries.Where(x => x.Id == Id).FirstOrDefault();
            _context.EventGalleries.Remove(data);
            _context.SaveChanges();
        }

        public async Task<int> GetCurrentRecordId()
        {
            var data = await _context.Events.OrderByDescending(x => x.Id).Take(1).Select(x => x.Id).FirstOrDefaultAsync();
            return data;
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

        public async Task<int> StoringImages(EventGalleryModel pm)
        {
            EventGallery eventGallery = new EventGallery();
            eventGallery.ImageName = pm.ImageName;
            eventGallery.EventId = pm.EventId;
            eventGallery.URL = pm.URL;
            await _context.EventGalleries.AddAsync(eventGallery);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<Event> UpdateEvent(EventViewModel eventmodel)
        {
            var result = await _context.Events.FirstOrDefaultAsync(x => x.Id == eventmodel.Id);
            if (result != null)
            {
                result.EventTypes = eventmodel.EventTypes;
                result.EventCost = eventmodel.EventCost;
                result.UpdatedDate = DateTime.Now;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<ImageViewModel>> UpdateImage(int Eventid)
        {
            List<ImageViewModel> model = new List<ImageViewModel>();
            var data = await _context.EventGalleries.Where(x => x.EventId == Eventid).ToListAsync();
            foreach(var item in data)
            {
                ImageViewModel imagemodel = new ImageViewModel();
                imagemodel.ImageName = item.ImageName;
                imagemodel.Id = item.Id;
                imagemodel.EventId = item.EventId;
                imagemodel.URL = item.URL;
                model.Add(imagemodel);
            }
            return model;
        }
        public async Task<IEnumerable<ImageViewModel>> GetEventImages()
        {
            List<ImageViewModel> model = new List<ImageViewModel>();
            var data = await _context.EventGalleries.ToListAsync();
            foreach (var item in data)
            {
                ImageViewModel imagemodel = new ImageViewModel();
                imagemodel.ImageName = item.ImageName;
                imagemodel.Id = item.Id;
                imagemodel.EventId = item.EventId;
                imagemodel.URL = item.URL;
                model.Add(imagemodel);
            }
            return model;
        }
    }
}
