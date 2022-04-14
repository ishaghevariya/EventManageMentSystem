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
        Task<BookingDetalis> AddBookingDetalis(BookingDetalis bookingDetalis);
        Task<BookingDetalis> AddBookingId(int id);
        Task<Booking> GetBooking(int id);
        Task<IEnumerable<Booking>> GetBookings(int userid);
        Task<IEnumerable<int>> GetAllEventId(int userid);
        Task<string> GetEventName(int id);
        Task<int> GetCurrentRecordId();
        Task<int> GetCurrentBookingId();
        Task<IEnumerable<Booking>> AllBookings();
        IEnumerable<FlowerTypeViewModel> GetFlowerType();
        IEnumerable<FoodTypeViewModel> GetFoodType();
        IEnumerable<EquipmentTypeViewModel> GetEquipmentType();
    }
}
