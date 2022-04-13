using DataAcessLayer;
using DataAcessLayer.ViewModel;
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
        Task<IEnumerable<Booking>> GetBookings(int userid);
        Task<string> GetEventName(int id);
        Task<int> GetCurrentRecordId();
        Task<IEnumerable<Booking>> AllBookings();
    }
}
