using DataAcessLayer;
using DataAcessLayer.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EventBookingApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class EventListController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EventListController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
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
        public async  Task<IActionResult> Create(EventViewModel eventmodel)
        {
            string uniqueFileName = UploadImage(eventmodel);
            eventmodel.FileName = uniqueFileName;
            eventmodel.Images = null;
            HttpClient client = new HttpClient();           
            client.BaseAddress = new Uri("https://localhost:44362/");
            var response = await client.PostAsJsonAsync<EventViewModel>($"/api/AddEvent/AddData",eventmodel);
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
            EventViewModel vm = new EventViewModel();
            vm.Id = events.Id;
            vm.EventTypes = events.EventTypes;
            vm.FileName = events.Images;
     
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EventViewModel eventmodel)
        {
            HttpClient client = new HttpClient();
            if (eventmodel.Images != null)
            {
                string uniqueFileName = UploadImage(eventmodel);
                eventmodel.FileName = uniqueFileName;
                eventmodel.Images = null;
            }
            client.BaseAddress = new Uri("https://localhost:44362/");
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/AddEvent/{eventmodel.Id}", eventmodel);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(eventmodel);
        }
        private string UploadImage(EventViewModel eventmodel)
        {
            string uniqueFileName = null;

            if (eventmodel.Images != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + eventmodel.Images.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    eventmodel.Images.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
