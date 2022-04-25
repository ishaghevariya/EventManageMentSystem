using DataAcessLayer;
using DataAcessLayer.ViewModel;
using EventBookingApp.API.ViewModel;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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
            //GetFlowers
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
            ////GetEquipments
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
            ////GetFoods
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
            //GetBookingData
            var data = HttpContext.Session.GetString("UserId");
            int id = Convert.ToInt32(data);
            List<BookingViewModel> bookings = new List<BookingViewModel>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage response = await client.GetAsync($"api/EventBooking/GetBookings/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result1 = response.Content.ReadAsStringAsync().Result;
                bookings = JsonConvert.DeserializeObject<List<BookingViewModel>>(result1);
            }
            return View(bookings);
        }
        [HttpPost]
        public async Task<JsonResult> Index( int BookingId, int Flower, int Food, int Equipment)
        {
            BookingDetalis vm = new BookingDetalis();
            HttpClient client = new HttpClient();
            vm.BookingId = BookingId;
            vm.FoodId = Food;
            vm.FlowerId = Flower;
            vm.EquipmentId = Equipment;
            client.BaseAddress = new Uri(AdminApiString);
            var response = await client.PostAsJsonAsync($"api/EventBooking/AddBookingDetalis", vm);
            if (response.IsSuccessStatusCode)
            {
                return Json("true");
            }
            return Json("false");
        }
        [HttpGet]
        public async Task<IActionResult> ShowBookingDetalis(int Id)
        {
            List<BookingDetalisViewModel> vm = new List<BookingDetalisViewModel>();
            HttpClient client2 = new HttpClient();
            client2.BaseAddress = new Uri(AdminApiString);
            var response2 = await client2.GetAsync($"api/EventBooking/AllBookingDetalis/{Id}");
            if (response2.IsSuccessStatusCode)
            {
                var result = response2.Content.ReadAsStringAsync().Result;
                vm = JsonConvert.DeserializeObject<List<BookingDetalisViewModel>>(result);
                ViewBag.Booking = vm;
            }
            return View(vm);
        }
        [HttpGet]
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
            if (ModelState.IsValid)
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
            }
            else
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
            }
            return View();
        }

        public async Task<IActionResult> DeleteBooking(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage response = await client.DeleteAsync($"api/EventBooking/DeleteBooking/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddFeedback()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddFeedback(FeedbackViewModel model)
        {
            var data = HttpContext.Session.GetString("UserId");
            model.UserId = Convert.ToInt32(data);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            var response = await client.PostAsJsonAsync($"api/Account/AddFeedback", model);
            if (response.IsSuccessStatusCode)
            {
                ViewBag.message = "Your Feedback Add Sucessfully";

            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ShowFlower()
        {
            List<Flower> flower = new List<Flower>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage response = await client.GetAsync("/api/Flowers");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                flower = JsonConvert.DeserializeObject<List<Flower>>(result);
            }
            return View(flower);
        }
        //[HttpGet]
        //public async Task<IActionResult> InsertBooklingDetalis(int BookingId)
        //{
        //    List<FlowerTypeViewModel> vm1 = new List<FlowerTypeViewModel>();
        //    HttpClient client1 = new HttpClient();
        //    client1.BaseAddress = new Uri(AdminApiString);
        //    var response1 = await client1.GetAsync($"api/EventBooking/GetFlowerByTypes");
        //    if (response1.IsSuccessStatusCode)
        //    {
        //        var result = response1.Content.ReadAsStringAsync().Result;
        //        vm1 = JsonConvert.DeserializeObject<List<FlowerTypeViewModel>>(result);
        //        ViewBag.Flowertype = vm1;
        //    }
        //    List<EquipmentTypeViewModel> vm2 = new List<EquipmentTypeViewModel>();
        //    HttpClient client2 = new HttpClient();
        //    client2.BaseAddress = new Uri(AdminApiString);
        //    var response2 = await client2.GetAsync($"api/EventBooking/GetEquipmentByTypes");
        //    if (response2.IsSuccessStatusCode)
        //    {
        //        var result2 = response2.Content.ReadAsStringAsync().Result;
        //        vm2 = JsonConvert.DeserializeObject<List<EquipmentTypeViewModel>>(result2);
        //        ViewBag.Equipmenttype = vm2;
        //    }
        //    List<FoodTypeViewModel> vm3 = new List<FoodTypeViewModel>();
        //    HttpClient client3 = new HttpClient();
        //    client3.BaseAddress = new Uri(AdminApiString);
        //    var response3 = await client3.GetAsync($"api/EventBooking/GetFoodByTypes");
        //    if (response3.IsSuccessStatusCode)
        //    {
        //        var result3 = response3.Content.ReadAsStringAsync().Result;
        //        vm3 = JsonConvert.DeserializeObject<List<FoodTypeViewModel>>(result3);
        //        ViewBag.Foodtype = vm3;
        //    }
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> InsertBooklingDetalis(BookingDetalis vm, int BookingId, int Flower, int Food, int Equipment)
        //{
        //    //CurrentBookingId
        //    //HttpClient client1 = new HttpClient();
        //    //client1.BaseAddress = new Uri(AdminApiString);
        //    //HttpResponseMessage httpResponse = await client1.GetAsync($"api/EventBooking/GetCurrentBookingId");
        //    //string bookingid = null;
        //    //if (httpResponse.IsSuccessStatusCode)
        //    //{
        //    //    bookingid = httpResponse.Content.ReadAsStringAsync().Result;
        //    //}
        //    HttpClient client = new HttpClient();
        //    vm.BookingId = BookingId;
        //    vm.FoodId = Food;
        //    vm.FlowerId = Flower;
        //    vm.EquipmentId = Equipment;
        //    client.BaseAddress = new Uri(AdminApiString);
        //    var response = await client.PostAsJsonAsync($"api/EventBooking/AddBookingDetalis", vm);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
    }
}
