﻿using DataAcessLayer;
using DataAcessLayer.ViewModel;
using EventBookingApp.API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EventBookingApp.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly IConfiguration _configuration;
        public string AdminApiString;
        public BookingController(IConfiguration configuration)
        {
            _configuration = configuration;
            AdminApiString = _configuration.GetValue<string>("APISTRING");
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = HttpContext.Session.GetString("UserId");
            int id = Convert.ToInt32(data);
            List<BookingViewModel> bookings = new List<BookingViewModel>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage response = await client.GetAsync($"api/EventBooking/GetBookings/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                bookings = JsonConvert.DeserializeObject<List<BookingViewModel>>(result);
            }
            return View(bookings);
        }

        public async Task<IActionResult> InsertBooking()
        {
            List<eventTypeViewModel> vm1 = new List<eventTypeViewModel>();
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri(AdminApiString);
            var response1 = await client1.GetAsync($"api/AddEvent/GetEventByTypes");
            if (response1.IsSuccessStatusCode)
            {
                var result = response1.Content.ReadAsStringAsync().Result;
                vm1 = JsonConvert.DeserializeObject<List<eventTypeViewModel>>(result);
                ViewBag.type = vm1;

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertBooking(BookingViewModel vm, int TypeName)
        {
            HttpClient client = new HttpClient();
            var data = HttpContext.Session.GetString("UserId");
            vm.EventId = TypeName;
            vm.UserId = Convert.ToInt32(data);
            client.BaseAddress = new Uri(AdminApiString);
            var response = await client.PostAsJsonAsync($"api/EventBooking/AddBooking", vm);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> InsertBooklingDetalis()
        {
            List<FlowerTypeViewModel> vm1 = new List<FlowerTypeViewModel>();
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri(AdminApiString);
            var response1 = await client1.GetAsync($"api/EventBooking/GetFlowerByTypes");
            if (response1.IsSuccessStatusCode)
            {
                var result = response1.Content.ReadAsStringAsync().Result;
                vm1 = JsonConvert.DeserializeObject<List<FlowerTypeViewModel>>(result);
                ViewBag.Flowertype = vm1;
            }
            List<EquipmentTypeViewModel> vm2 = new List<EquipmentTypeViewModel>();
            HttpClient client2 = new HttpClient();
            client2.BaseAddress = new Uri(AdminApiString);
            var response2 = await client2.GetAsync($"api/EventBooking/GetEquipmentByTypes");
            if (response2.IsSuccessStatusCode)
            {
                var result2 = response2.Content.ReadAsStringAsync().Result;
                vm2 = JsonConvert.DeserializeObject<List<EquipmentTypeViewModel>>(result2);
                ViewBag.Equipmenttype = vm2;
            }
            List<FoodTypeViewModel> vm3 = new List<FoodTypeViewModel>();
            HttpClient client3 = new HttpClient();
            client3.BaseAddress = new Uri(AdminApiString);
            var response3 = await client3.GetAsync($"api/EventBooking/GetFoodByTypes");
            if (response3.IsSuccessStatusCode)
            {
                var result3 = response3.Content.ReadAsStringAsync().Result;
                vm3 = JsonConvert.DeserializeObject<List<FoodTypeViewModel>>(result3);
                ViewBag.Foodtype = vm3;
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> InsertBooklingDetalis(BookingDetalis vm, int Flower, int Food, int Equipment)
        {
            //CurrentBookingId
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage httpResponse = await client1.GetAsync($"api/EventBooking/GetCurrentBookingId");
            string bookingid = null;
            if (httpResponse.IsSuccessStatusCode)
            {
                bookingid = httpResponse.Content.ReadAsStringAsync().Result;
            }
            HttpClient client = new HttpClient();
            vm.BookingId = Convert.ToInt32(bookingid);
            vm.FoodId = Food;
            vm.FlowerId = Flower;
            vm.EquipmentId = Equipment;
            client.BaseAddress = new Uri(AdminApiString);
            var response = await client.PostAsJsonAsync($"api/EventBooking/AddBookingDetalis", vm);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
