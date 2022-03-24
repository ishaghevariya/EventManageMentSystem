﻿using DataAcessLayer;
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
        Task<Event> AddEvent(Event eventmodel);
        Task<Event> UpdateEvent(Event eventmodel);
        Task<Event> DeleteEvent(int id);
//public string UploadImage(EventViewModel eventmodel);

    }
}