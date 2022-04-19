﻿using DataAcessLayer;
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
        Task<IEnumerable<int>> AllBookingId();
        Task<IEnumerable<BookingViewModel>> GetBookings(int userid);
        Task<Booking> UpdateBookingStatus(int Bid,int statusid);
        Task<int> GetCurrentBookingId();
        Task<IEnumerable<BookingViewModel>> AllBookings();
        Task<IEnumerable<BookingDetalisViewModel>> AllBookingDetalis(int Id);
        IEnumerable<FlowerTypeViewModel> GetFlowerType();
        IEnumerable<FoodTypeViewModel> GetFoodType();
        IEnumerable<BookingStatus> GetBookingStatuses();
        IEnumerable<EquipmentTypeViewModel> GetEquipmentType();
    }
}
