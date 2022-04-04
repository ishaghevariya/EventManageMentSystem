using DataAcessLayer;
using EventBookingApp.API.Data;
using EventBookingApp.API.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBookingApp.API.Repositary
{
    public class BookingRepo : IBookingRepo
    {
        private readonly ApplicationDbContext _context;
        public BookingRepo(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Booking> AddBooking(BookingViewModel booking)
        {
            Booking Book = new Booking
            {
                EventId = booking.EventId,
                NumberOfDays = booking.NumberOfDays,
                EventDate = booking.EventDate,
                BookingStatusId = 1,
                Address = booking.Address,
                AreapinCode = booking.AreapinCode,
                NumberOfPerson = booking.NumberOfPerson,
                VenuType = booking.VenuType,
            };
            var result = await _context.AddAsync(Book);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Booking> GetBooking(int id)
        {
            return await _context.Bookings.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
