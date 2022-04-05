using DataAcessLayer;
using EventBookingApp.API.ViewModel;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public IActionResult Index()
        {
            //List<Event> events = new List<Event>();
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("https://localhost:44362/");
            //HttpResponseMessage response = await client.GetAsync("/api/AddEvent");
            //if (response.IsSuccessStatusCode)
            //{
            //    var result = response.Content.ReadAsStringAsync().Result;
            //    events = JsonConvert.DeserializeObject<List<Event>>(result);
            //}
            return View();
        }

        public async Task<IActionResult> InsertBooking()
        {
            List<eventTypeViewModel> vm1 = new List<eventTypeViewModel>();
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri("https://localhost:44362/");
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
            vm.EventId = TypeName;
            client.BaseAddress = new Uri("https://localhost:44362/");
            var response = await client.PostAsJsonAsync<BookingViewModel>($"api/Booking/AddBooking", vm);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
