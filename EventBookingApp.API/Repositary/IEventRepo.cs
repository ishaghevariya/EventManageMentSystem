using DataAcessLayer;
using DataAcessLayer.ViewModel;
using EventBookingApp.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBookingApp.API.Repositary
{
    public interface IEventRepo
    {
        Task<Event> GetEvent(int id);
        Task<IEnumerable<Event>> GetEvents();
        Task<Event> AddEvent(EventViewModel eventmodel);
        Task<Event> UpdateEvent(EventViewModel eventmodel);
        Task<Event> DeleteEvent(int id);
//public string UploadImage(EventViewModel eventmodel);

    }
}
