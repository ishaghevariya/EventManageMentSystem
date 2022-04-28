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
                FromDate = booking.FromDate,
                ToDate = booking.ToDate,
                EventTime = booking.EventTime,
                BookingStatusId = 2,
                Address = booking.Address,
                AreapinCode = booking.AreapinCode,
                NumberOfPerson = booking.NumberOfPerson,
                UserId = booking.UserId,
                VenuType = booking.VenuType,
                IsCancle = 1,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
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
                if (item.IsCancle == 1)
                {
                    BookingViewModel vm = new BookingViewModel();
                    vm.Id = item.Id;
                    vm.Address = item.Address;
                    vm.AreapinCode = item.AreapinCode;
                    vm.BookingStatusId = item.BookingStatusId;
                    vm.FromDate = item.FromDate;
                    vm.ToDate = item.ToDate;
                    vm.EventId = item.EventId;
                    vm.EventTime = item.EventTime;
                    vm.NumberOfPerson = item.NumberOfPerson;
                    vm.VenuType = item.VenuType;
                    vm.UserId = userid;
                    var status = _context.BookingStatuses.Where(x => x.Id == item.BookingStatusId).Select(x => x.Status).FirstOrDefault();
                    vm.Status = status;
                    var eventName = _context.Events.Where(x => x.Id == item.EventId).Select(x => x.EventTypes).FirstOrDefault();
                    vm.EventName = eventName;
                    lvm.Add(vm);
                }
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
                vm.FromDate = item.FromDate;
                vm.ToDate = item.ToDate;
                vm.EventId = item.EventId;
                vm.EventTime = item.EventTime;
                vm.NumberOfPerson = item.NumberOfPerson;
                vm.VenuType = item.VenuType;
                vm.IsCancle = item.IsCancle;
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
            BookingDetalis model = new BookingDetalis()
            {
                FlowerId = bookingDetalis.FlowerId,
                EquipmentId = bookingDetalis.EquipmentId,
                FoodId = bookingDetalis.FoodId,
                UpdatedDate = DateTime.Now,
                CreatedDate = DateTime.Now
            };
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

        //public async Task<int> GetCurrentBookingId()
        //{
        //    var data = await _context.Bookings.OrderByDescending(x => x.Id).Take(1).Select(x => x.Id).FirstOrDefaultAsync();
        //    return data;
        //}
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

        public async Task<IEnumerable<BookingDetalisViewModel>> AllBookingDetalis(int Id)
        {
            List<BookingDetalisViewModel> model = new List<BookingDetalisViewModel>();
            var data = await _context.BookingDetalis.Where(x => x.BookingId == Id).ToListAsync();
            foreach (var item in data)
            {
                BookingDetalisViewModel vm = new BookingDetalisViewModel();
                vm.BookingDetalisId = item.BookingDetalisId;
                vm.BookingId = item.BookingId;
                //vm.EquipmentId = item.EquipmentId;
                var EquipmentName = _context.Equipments.Where(x => x.EquipmentId == item.EquipmentId).Select(x => x.EquipmentType).FirstOrDefault();
                vm.EquipmentType = EquipmentName;
                //vm.FoodId = item.FoodId;
                var FoodName = _context.Foods.Where(x => x.FoodId == item.FoodId).Select(x => x.FoodType).FirstOrDefault();
                vm.FoodType = FoodName;
                //vm.FlowerId = item.FlowerId;
                var FlowerName = _context.Flowers.Where(x => x.FlowerId == item.FlowerId).Select(x => x.FlowerType).FirstOrDefault();
                vm.FlowerType = FlowerName;
                model.Add(vm);
            }
            return model;
        }
        //public async Task<BookingDetalis> AllBookingId(int Id)
        //{
        //    var data = await _context.BookingDetalis.Where(x => x.BookingId == Id).FirstOrDefaultAsync();
        //    return data;
        //}

        public async Task<IEnumerable<EventCountViewModel>> GetTotalBooking()
        {
            List<EventCountViewModel> model = new List<EventCountViewModel>();
            var countData = _context.Events.ToList();
            foreach (var item in countData)
            {
                EventCountViewModel evm = new EventCountViewModel();
                var data = await _context.Bookings.Where(x => x.EventId == item.Id).CountAsync();
                evm.EventId = item.Id;
                var eventname = _context.Events.Where(x => x.Id == item.Id).Select(x => x.EventTypes).FirstOrDefault();
                evm.EventName = eventname;
                evm.Count = data;
                model.Add(evm);
            }
            return model;
        }
        public async Task<IEnumerable<EventCountViewModel>> GetCancleBooking()
        {
            List<EventCountViewModel> model = new List<EventCountViewModel>();
            var countData = _context.Events.ToList();
            foreach (var item in countData)
            {
                EventCountViewModel evm = new EventCountViewModel();
                var data = await _context.Bookings.Where(x => x.EventId == item.Id && x.IsCancle == 0).CountAsync();
                evm.EventId = item.Id;
                var eventname = _context.Events.Where(x => x.Id == item.Id).Select(x => x.EventTypes).FirstOrDefault();
                evm.EventName = eventname;
                evm.Count = data;
                model.Add(evm);
            }
            return model;
        }
        public async Task<IEnumerable<EquipmentCountViewModel>> GetTotalEquipmentBooking()
        {
            List<EquipmentCountViewModel> model = new List<EquipmentCountViewModel>();
            var countData = await _context.Equipments.ToListAsync();
            foreach (var item in countData)
            {
                EquipmentCountViewModel evm = new EquipmentCountViewModel();
                var data = await _context.BookingDetalis.Where(x => x.EquipmentId == item.EquipmentId).CountAsync();
                evm.EquipmentId = item.EquipmentId;
                var equipmentName = _context.Equipments.Where(x => x.EquipmentId == item.EquipmentId).Select(x => x.EquipmentType).FirstOrDefault();
                evm.EquipmentName = equipmentName;
                evm.Count = data;
                model.Add(evm);
            }
            return model;
        }

        public async Task<IEnumerable<FlowerCountViewModel>> GetTotalFlowerBooking()
        {
            List<FlowerCountViewModel> model = new List<FlowerCountViewModel>();
            var countData = await _context.Flowers.ToListAsync();
            foreach (var item in countData)
            {
                FlowerCountViewModel evm = new FlowerCountViewModel();
                var data = await _context.BookingDetalis.Where(x => x.FlowerId == item.FlowerId).CountAsync();
                evm.FlowerId = item.FlowerId;
                var FloweName = _context.Flowers.Where(x => x.FlowerId == item.FlowerId).Select(x => x.FlowerType).FirstOrDefault();
                evm.FlowerName = FloweName;
                evm.Count = data;
                model.Add(evm);
            }
            return model;
        }

        public async Task<IEnumerable<FoodCountViewModel>> GetTotalFoodBooking()
        {
            List<FoodCountViewModel> model = new List<FoodCountViewModel>();
            var countData = await _context.Foods.ToListAsync();
            foreach (var item in countData)
            {
                FoodCountViewModel evm = new FoodCountViewModel();
                var data = await _context.BookingDetalis.Where(x => x.FoodId == item.FoodId).CountAsync();
                evm.FoodId = item.FoodId;
                var foodname = _context.Foods.Where(x => x.FoodId == item.FoodId).Select(x => x.FoodType).FirstOrDefault();
                evm.FoodName = foodname;
                evm.Count = data;
                model.Add(evm);
            }
            return model;
        }

        public async Task<Booking> DeleteBooking(int id)
        {
            var result = await _context.Bookings.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (result != null)
            {
                var bookingId = await _context.BookingDetalis.Where(x => x.BookingId == result.Id).FirstOrDefaultAsync();
                if (bookingId != null)
                {
                    _context.BookingDetalis.Remove(bookingId);
                    await _context.SaveChangesAsync();
                }
                _context.Bookings.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<InvoiceViewModel>> Invoice(int id)
        {
            List<InvoiceViewModel> lvm = new List<InvoiceViewModel>();
            var data = await _context.Bookings.Where(x => x.UserId == id).ToListAsync();
            foreach (var item in data)
            {
                if (item.IsCancle == 1)
                {
                    InvoiceViewModel model = new InvoiceViewModel();
                    model.BookingId = item.Id;
                    model.EventId = item.EventId;
                    int BookingCost = _context.Events.Where(x => x.Id == item.EventId).Select(x => x.EventCost).Sum();
                    model.EventCost = BookingCost;
                    var eventname = _context.Events.Where(x => x.Id == item.EventId).Select(x => x.EventTypes).FirstOrDefault();
                    model.EventName = eventname;
                    var result = await _context.BookingDetalis.Where(x => x.BookingId == item.Id).ToListAsync();
                    foreach (var data2 in result)
                    {
                        model.BookingDetalisId = data2.BookingDetalisId;
                        int FlowerCost = _context.Flowers.Where(x => x.FlowerId == data2.FlowerId).Select(x => x.FlowerCost).Sum();
                        model.FlowerCost = FlowerCost;
                        model.FlowerId = data2.FlowerId;
                        int EquipmentCost = _context.Equipments.Where(x => x.EquipmentId == data2.EquipmentId).Select(x => x.EquipmentCost).Sum();
                        model.EquipmentCost = EquipmentCost;
                        model.EquipmentId = data2.EquipmentId;
                        int FoodCost = _context.Foods.Where(x => x.FoodId == data2.FoodId).Select(x => x.FoodCost).Sum();
                        model.FoodCost = FoodCost;
                        model.FoodId = data2.FoodId;
                        int total = BookingCost +
                               FlowerCost + EquipmentCost + FoodCost;
                        model.total = total;
                    }
                    lvm.Add(model);
                }
            }
            return lvm;
        }

        public async Task<Booking> CancleBooking(int id)
        {
            var data = await _context.Bookings.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data != null)
            {
                data.IsCancle = 0;
                await _context.SaveChangesAsync();
                return data;
            }
            return null;
        }


    }
}
