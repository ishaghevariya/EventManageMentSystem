using DataAcessLayer;
using DataAcessLayer.ViewModel;
using EventBookingApp.API.Data;
using EventBookingApp.API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
                BookingStatusId = 2,
                Address = booking.Address,
                AreapinCode = booking.AreapinCode,
                NumberOfPerson = booking.NumberOfPerson,
                UserId = booking.UserId,
                VenuType = booking.VenuType,
            };
            var result = await _context.Bookings.AddAsync(Book);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Booking> GetBooking(int id)
        {
            return await _context.Bookings.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<BookingViewModel>> GetBookings(int userid)
        {
            List<BookingViewModel> lvm = new List<BookingViewModel>();
            var data = await _context.Bookings.Where(x => x.UserId == userid).ToListAsync();
            foreach (var item in data) 
            {
                BookingViewModel vm = new BookingViewModel();
                vm.Address = item.Address;
                vm.AreapinCode = item.AreapinCode;
                vm.BookingStatusId = item.BookingStatusId;
                vm.EventDate = item.EventDate;
                vm.EventId = item.EventId;
                vm.NumberOfDays = item.NumberOfDays;
                vm.NumberOfPerson = item.NumberOfPerson;
                vm.VenuType = item.VenuType;
                vm.UserId = userid;
                var eventName = _context.Events.Where(x => x.Id == item.EventId).Select(x => x.EventTypes).FirstOrDefault();
                vm.EventName = eventName;
                lvm.Add(vm);
            }
            return lvm;
        }

        public async Task<IEnumerable<BookingViewModel>> AllBookings()
        {
            List<BookingViewModel> bvm = new List<BookingViewModel>();
            var data = await _context.Bookings.ToListAsync();
            foreach (var item in data)
            {
                BookingViewModel vm = new BookingViewModel();
                vm.Id = item.Id;
                vm.Address = item.Address;
                vm.AreapinCode = item.AreapinCode;
                vm.BookingStatusId = item.BookingStatusId;
                vm.EventDate = item.EventDate;
                vm.EventId = item.EventId;
                vm.NumberOfDays = item.NumberOfDays;
                vm.NumberOfPerson = item.NumberOfPerson;
                vm.VenuType = item.VenuType;
                var status = _context.BookingStatuses.Where(x => x.Id == item.BookingStatusId).Select(x => x.Status).FirstOrDefault();
                vm.Status = status;
                //var userid = _context.ApplicationUsers.Where(x => x.Id == item.UserId).Select(x => x.UserName).FirstOrDefault();
                vm.UserId = (int)item.UserId;
                var eventName = _context.Events.Where(x => x.Id == item.EventId).Select(x => x.EventTypes).FirstOrDefault();
                vm.EventName = eventName;
                bvm.Add(vm);
            }
            return bvm;
        }

        public async Task<BookingDetalis> AddBookingDetalis(BookingDetalis bookingDetalis)
        {
            var result = await _context.BookingDetalis.AddAsync(bookingDetalis);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<BookingDetalis> AddBookingId(int id)
        {
            return await _context.BookingDetalis.FirstOrDefaultAsync(x => x.BookingDetalisId == id);
        }
        public IEnumerable<FlowerTypeViewModel> GetFlowerType()
        {
            List<FlowerTypeViewModel> vm = new List<FlowerTypeViewModel>();
            var data = _context.Flowers.Select(x => new
            {
                x.FlowerId,
                x.FlowerType
            }).ToList();
            foreach (var item in data)
            {
                FlowerTypeViewModel e = new FlowerTypeViewModel();
                e.FlowerId = item.FlowerId;
                e.FlowerType = item.FlowerType;
                vm.Add(e);
            }
            return vm;
        }


        public IEnumerable<FoodTypeViewModel> GetFoodType()
        {
            List<FoodTypeViewModel> vm = new List<FoodTypeViewModel>();
            var data = _context.Foods.Select(x => new
            {
                x.FoodId,
                x.FoodType
            }).ToList();
            foreach (var item in data)
            {
                FoodTypeViewModel e = new FoodTypeViewModel();
                e.FoodId = item.FoodId;
                e.FoodType = item.FoodType;
                vm.Add(e);
            }
            return vm;
        }

        public IEnumerable<EquipmentTypeViewModel> GetEquipmentType()
        {
            List<EquipmentTypeViewModel> vm = new List<EquipmentTypeViewModel>();
            var data = _context.Equipments.Select(x => new
            {
                x.EquipmentId,
                x.EquipmentType
            }).ToList();
            foreach (var item in data)
            {
                EquipmentTypeViewModel e = new EquipmentTypeViewModel();
                e.EquipmentId = item.EquipmentId;
                e.EquipmentType = item.EquipmentType;
                vm.Add(e);
            }
            return vm;
        }

        public async Task<int> GetCurrentBookingId()
        {
            var data = await _context.Bookings.OrderByDescending(x => x.Id).Take(1).Select(x => x.Id).FirstOrDefaultAsync();
            return data;
        }
        public IEnumerable<BookingStatus> GetBookingStatuses()
        {
            List<BookingStatus> vm = new List<BookingStatus>();
            var data = _context.BookingStatuses.Select(x => new
            {
                x.Id,
                x.Status
            }).ToList();
            foreach (var item in data)
            {
                BookingStatus e = new BookingStatus();
                e.Id = item.Id;
                e.Status = item.Status;
                vm.Add(e);
            }
            return vm;
        }

        public async Task<Booking> UpdateBookingStatus(int Bid, int statusid)
        {
            var result = await _context.Bookings.Where(x => x.Id == Bid).FirstOrDefaultAsync();
            if (result != null)
            {
                result.BookingStatusId = statusid;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
