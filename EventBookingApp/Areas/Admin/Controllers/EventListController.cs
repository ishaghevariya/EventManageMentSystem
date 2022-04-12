﻿using DataAcessLayer;
using DataAcessLayer.ViewModel;
using EventBookingApp.API.ViewModel;
using EventBookingApp.Web.Areas.Admin.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;
        public string AdminApiString;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EventListController(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
            AdminApiString = _configuration.GetValue<string>("APISTRING");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Event> events = new List<Event>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage response = await client.GetAsync("/api/AddEvent");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                events = JsonConvert.DeserializeObject<List<Event>>(result);
                ViewBag.Images = events;
            }
            return View(events);
        }
        [HttpPost]
        public async Task<IActionResult> Index(string EventTypes)
        {
            List<Event> events = new List<Event>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage response = await client.GetAsync($"/api/AddEvent/Search/{EventTypes}");
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
        public async Task<IActionResult> Create(EventViewModels eventmodel)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(AdminApiString);
                var response = await client.PostAsJsonAsync($"/api/AddEvent/AddData", eventmodel);
                if (response.IsSuccessStatusCode)
                {
                    //Get Current EventId
                    HttpClient client2 = new HttpClient();
                    client2.BaseAddress = new Uri(AdminApiString);
                    HttpResponseMessage httpResponse = await client2.GetAsync($"/api/AddEvent/GetCurrentRecordId");
                    string eventid = null;
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        eventid = httpResponse.Content.ReadAsStringAsync().Result;
                    }
                    foreach (var item in eventmodel.images)
                    {
                        EventGalleryViewModel model = new EventGalleryViewModel();
                        var file = item;
                        FileStream fs = null;
                        var guid = Guid.NewGuid().ToString();
                        var uniqueFileName = guid + '_' + file.FileName;
                        model.ImageName = uniqueFileName;
                        model.EventId = Convert.ToInt32(eventid);
                        string folderName = "EventImages/";
                        model.URL = await UploadImage(folderName, item);
                        HttpClient client3 = new HttpClient();
                        client3.BaseAddress = new Uri(AdminApiString);
                        HttpResponseMessage httpResponse1 = await client3.PostAsJsonAsync($"/api/AddEvent/StoringImage", model);
                        if (httpResponse1.IsSuccessStatusCode)
                        {
                            string path = Path.Combine(_webHostEnvironment.WebRootPath, "EventImages");
                            if (Directory.Exists(path))
                            {
                                using (fs = new FileStream(Path.Combine(path, uniqueFileName), FileMode.Create))
                                {
                                    await file.CopyToAsync(fs);
                                }
                                fs = new FileStream(Path.Combine(path, uniqueFileName), FileMode.Open);
                            }
                            model.URL =await UploadImage(folderName, item);
                            HttpClient client4 = new HttpClient();
                            client4.BaseAddress = new Uri(AdminApiString);
                            HttpResponseMessage httpResponse2 = await client4.PutAsJsonAsync($"/api/AddEvent/imgLink/{uniqueFileName}",model);
                            if (httpResponse2.IsSuccessStatusCode)
                            {
                                var result = httpResponse2.Content.ReadAsStringAsync().Result;
                            }
                            ViewBag.Link = await UploadImage(folderName,item);
                        }
                       
                    }
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public async Task<IActionResult> UpdateImages(int Eventid)
        {
            List<ImageViewModels> imagemodel = new List<ImageViewModels>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage response = await client.GetAsync($"api/AddEvent/UpdateImage/{Eventid}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                imagemodel = JsonConvert.DeserializeObject<List<ImageViewModels>>(result);
            }
            return View(imagemodel);
        }
        public async Task<IActionResult> Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
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
            vm.EventCost = events.EventCost;
            //vm.FileName = events.Images;
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EventViewModel eventmodel)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/AddEvent/{eventmodel.Id}", eventmodel);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(eventmodel);
        }
        private async Task<string> UploadImage(string folderPath,IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "/" + folderPath;
        }
    }
}
