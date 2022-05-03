using DataAcessLayer;
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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EventBookingApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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
                       // FileStream fs = null;
                        var guid = Guid.NewGuid().ToString();
                        var uniqueFileName = guid + '_' + file.FileName;
                        model.ImageName = uniqueFileName;
                        model.EventId = Convert.ToInt32(eventid);
                        string folderName = "EventImages/";
                        model.URL = folderName + uniqueFileName;
                        HttpClient client3 = new HttpClient();
                        client3.BaseAddress = new Uri(AdminApiString);
                        HttpResponseMessage httpResponse1 = await client3.PostAsJsonAsync($"/api/AddEvent/StoringImage", model);
                        if (httpResponse1.IsSuccessStatusCode)
                        {
                            string path = Path.Combine(_webHostEnvironment.WebRootPath, $"{folderName}");
                            if (Directory.Exists(path))
                            {
                                string fullpath = Path.Combine(path, uniqueFileName);
                                int width = 640;
                                int height = 425;
                                Image image = Image.FromStream(file.OpenReadStream(), true, true);
                                var newImage = new Bitmap(width, height);
                                using (var a= Graphics.FromImage(newImage))
                                {
                                    a.DrawImage(image, 0, 0, width, height);
                                    newImage.Save(fullpath);
                                }
                                //using (fs = new FileStream(Path.Combine(path, uniqueFileName), FileMode.Create))
                                //{
                                //    await file.CopyToAsync(fs);
                                //}
                                //fs = new FileStream(Path.Combine(path, uniqueFileName), FileMode.Open);
                            }
                            try
                            {
                                model.URL = folderName + uniqueFileName;
                                HttpClient client4 = new HttpClient();
                                client4.BaseAddress = new Uri(AdminApiString);
                                HttpResponseMessage httpResponse2 = await client4.PutAsJsonAsync($"/api/AddEvent/imgLink/{uniqueFileName}", model);
                                if (httpResponse2.IsSuccessStatusCode)
                                {
                                    var result = httpResponse2.Content.ReadAsStringAsync().Result;
                                }
                                ViewBag.Link = folderName + uniqueFileName;
                            }
                            catch (Exception ex)
                            {

                                Debug.WriteLine($"***************{ex}*************");
                                throw;
                            }
                        }
                    }
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public async Task<IActionResult> UpdateImages(int Eventid)
        {
            List<ImageViewModel> imagemodel = new List<ImageViewModel>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage response = await client.GetAsync($"api/AddEvent/UpdateImage/{Eventid}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                imagemodel = JsonConvert.DeserializeObject<List<ImageViewModel>>(result);
            }
            return View(imagemodel);
        }
        [HttpGet]
        public IActionResult AddImage(int Eventid)
        {
            EventGalleryViewModel model = new EventGalleryViewModel();
            model.EventId = Eventid;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddImage(EventGalleryViewModel gmodel)
        {
            EventGalleryViewModel model = new EventGalleryViewModel();
            foreach (var item in gmodel.Images)
            {
                var file = item;
                //FileStream fs = null;
                var guid = Guid.NewGuid().ToString();
                var uniqueFileName = guid + '_' + file.FileName;
                model.ImageName = uniqueFileName;
                model.EventId = gmodel.EventId;
                string folderName = "EventImages/";
                model.URL = folderName + uniqueFileName;
                HttpClient client3 = new HttpClient();
                client3.BaseAddress = new Uri(AdminApiString);
                HttpResponseMessage httpResponse1 = await client3.PostAsJsonAsync($"api/AddEvent/StoringImage", model);
                if (httpResponse1.IsSuccessStatusCode)
                {
                    string path = Path.Combine(_webHostEnvironment.WebRootPath, "EventImages");
                    if (Directory.Exists(path))
                    {
                        string fullpath = Path.Combine(path, uniqueFileName);
                        int width = 640;
                        int height = 425;
                        Image image = Image.FromStream(file.OpenReadStream(), true, true);
                        var newImage = new Bitmap(width, height);
                        using (var a = Graphics.FromImage(newImage))
                        {
                            a.DrawImage(image, 0, 0, width, height);
                            newImage.Save(fullpath);
                        }
                        //using (fs = new FileStream(Path.Combine(path, uniqueFileName), FileMode.Create))
                        //{
                        //    await file.CopyToAsync(fs);
                        //}
                        //fs = new FileStream(Path.Combine(path, uniqueFileName), FileMode.Open);
                    }
                    try
                    {
                        model.URL = folderName + uniqueFileName;
                        HttpClient client4 = new HttpClient();
                        client4.BaseAddress = new Uri(AdminApiString);
                        HttpResponseMessage httpResponse2 = await client4.PutAsJsonAsync($"api/AddEvent/imgLink/{uniqueFileName}", model);
                        if (httpResponse2.IsSuccessStatusCode)
                        {
                            var result = httpResponse2.Content.ReadAsStringAsync().Result;
                        }
                        ViewBag.Link = folderName + uniqueFileName;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"***************{ex}*************");
                        throw;
                    }
                }

            }
            return LocalRedirect($"~/Admin/EventList/UpdateImages?Eventid={model.EventId}");
        }

        [HttpPost]
        public async Task<string> DeleteImage(string Id)
        {
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage httpResponse1 = await client1.GetAsync($"/api/AddEvent/GetImageName/{Id}");
            if (httpResponse1.IsSuccessStatusCode)
            {
                var result = httpResponse1.Content.ReadAsStringAsync().Result;
                var imagedelete = Path.Combine(_webHostEnvironment.WebRootPath, "EventImages", result);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(AdminApiString);
                HttpResponseMessage httpResponse = await client.GetAsync($"/api/AddEvent/DeleteImage/{Id}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    FileInfo fi = new FileInfo(imagedelete);
                    if (fi != null)
                    {
                        System.IO.File.Delete(imagedelete);
                        fi.Delete();
                    }
                    return "true";
                }
            }
            return "null";
        }
        public async Task<IActionResult> Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage response = await client.DeleteAsync($"api/AddEvent/{id}");
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    TempData["Message"] = "Event Is Already Booked You Can not Delete It!!.";
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        private async Task<Event> GetEventById(int id)
        {
            Event events = new Event();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
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
        //private async Task<string> UploadImage(string folderPath, IFormFile file)
        //{
        //    folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
        //    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
        //    await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
        //    return "/" + folderPath;
        //}
    }
}
