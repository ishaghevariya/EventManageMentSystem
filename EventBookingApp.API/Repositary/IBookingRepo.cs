using DataAcessLayer;
using EventBookingApp.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBookingApp.API.Repositary
{
    public interface IBookingRepo
    {
        Task<Booking> AddBooking(BookingViewModel booking);
        Task<Booking> GetBooking(int id);
    }
}
