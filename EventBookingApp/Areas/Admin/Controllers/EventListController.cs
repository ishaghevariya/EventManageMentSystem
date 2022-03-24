using DataAcessLayer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EventBookingApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventListController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Event> events = new List<Event>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44362/");
            HttpResponseMessage response = await client.GetAsync("/api/AddEvent");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                events = JsonConvert.DeserializeObject<List<Event>>(result);
            }
            return View(events);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Create(Event eventmodel)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44362/");
            var response = await client.PostAsJsonAsync<Event>($"api/AddEvent/AddData", eventmodel);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44362/");
            HttpResponseMessage response = await client.DeleteAsync($"api/AddEvent/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        private static async Task<Event> GetEventById(int id)
        {
            Event events = new Event();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44362/");
            HttpResponseMessage response = await client.GetAsync($"api/AddEvent/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                events = JsonConvert.DeserializeObject<Event>(result);
            }
            return events;
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Event events = await GetEventById(id);
            return View(events);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Event events)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44362/");
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/AddEvent/{events.Id}", events);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(events);
        }
    }
}
