using DataAcessLayer;
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
            //GetEventId
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage httpResponse = await client1.GetAsync($"api/EventBooking/GetCurrentRecordId");
            string eventid = null;
            if (httpResponse.IsSuccessStatusCode)
            {
                eventid = httpResponse.Content.ReadAsStringAsync().Result;
                HttpClient client2 = new HttpClient();
                client2.BaseAddress = new Uri(AdminApiString);
                HttpResponseMessage httpResponse1 = await client2.GetAsync($"api/EventBooking/GetEventName/{eventid}");
                if (httpResponse1.IsSuccessStatusCode)
                {
                    var result = httpResponse1.Content.ReadAsStringAsync().Result;
                    ViewBag.EventType = result;
                }
            }
            var data = HttpContext.Session.GetString("UserId");
            int id = Convert.ToInt32(data);
            List<Booking> bookings = new List<Booking>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage response = await client.GetAsync($"api/EventBooking/GetBookings/{id}");
            if(response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                bookings = JsonConvert.DeserializeObject<List<Booking>>(result);
                
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
        public async Task<IActionResult> InsertBooking(BookingViewModel vm,int TypeName)
        {
           
            HttpClient client = new HttpClient();
            var data = HttpContext.Session.GetString("UserId");
            vm.EventId = TypeName;
            vm.UserId = Convert.ToInt32(data);
            client.BaseAddress = new Uri(AdminApiString);
            var response = await client.PostAsJsonAsync<BookingViewModel>($"api/EventBooking/AddBooking", vm);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
