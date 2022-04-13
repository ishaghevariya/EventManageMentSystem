using DataAcessLayer;
using DataAcessLayer.ViewModel;
using EventBookingApp.API.Data;
using EventBookingApp.API.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBookingApp.API.Repositary
{
    public interface IEventRepo
    {
        Task<IEnumerable<Event>> search(string EventTypes);
        IEnumerable<eventTypeViewModel> GetEventsType();
        Task<Event> GetEvent(int id);
        Task<IEnumerable<Event>> GetEvents();
        Task<Event> AddEvent(EventViewModel eventmodel);
        Task<Event> UpdateEvent(EventViewModel eventmodel);
        Task<Event> DeleteEvent(int id);
        public Task<int> StoringImages(EventGalleryModel pm);
        public string AddImgLink(string imgName, EventGalleryModel pvm);
        public Task<int> GetCurrentRecordId();
        public void DeleteImage(string id);
        public Task<IEnumerable<ImageViewModel>> UpdateImage(int Eventid);

    }
}
