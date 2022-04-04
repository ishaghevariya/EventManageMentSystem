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

        public  IActionResult InsertBooking()
        {
            //ViewBag.EventId = id;
            //ViewBag.UserId = 2;
            //List<Event> events = new List<Event>();
             
            //cl.Insert(0, new Country { Cid = 0, Cname = "--Select Country Name--" });
            //ViewBag.message = cl;
            
            return View(new BookingViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> InsertBooking(BookingViewModel vm)
        {

            HttpClient client = new HttpClient();
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
