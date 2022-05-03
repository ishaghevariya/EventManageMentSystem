using DataAcessLayer;
using DataAcessLayer.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
    public class FlowerController : Controller
    {
        private readonly IConfiguration _configuration;
        public string AdminApiString;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FlowerController(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
            AdminApiString = _configuration.GetValue<string>("APISTRING");
        }
        [HttpGet]
        public async Task<IActionResult> Index()
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
        //[HttpPost]
        //public async Task<IActionResult> Index(string FlowerType)
        //{
        //    List<Flower> flower = new List<Flower>();
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri(AdminApiString);
        //    HttpResponseMessage response = await client.GetAsync($"/api/Flowers/Search/{FlowerType}");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var result = response.Content.ReadAsStringAsync().Result;
        //        flower = JsonConvert.DeserializeObject<List<Flower>>(result);
        //    }
        //    return View(flower);
        //}
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FlowerViewModel flowermodel)
        {
            string uniqueFileName = UploadImage(flowermodel);
            flowermodel.FileName = uniqueFileName;
            flowermodel.FlowerImage = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            var response = await client.PostAsJsonAsync<FlowerViewModel>($"api/Flowers/AddFlower", flowermodel);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage httpResponse1 = await client1.GetAsync($"/api/Flowers/GetImageName/{id}");
            if (httpResponse1.IsSuccessStatusCode)
            {
                var result = httpResponse1.Content.ReadAsStringAsync().Result;
                var imagedelete = Path.Combine(_webHostEnvironment.WebRootPath, "FlowerImages", result);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(AdminApiString);
                HttpResponseMessage response = await client.DeleteAsync($"api/Flowers/{id}");
                if (response.IsSuccessStatusCode)
                {

                    FileInfo fi = new FileInfo(imagedelete);
                    if (fi != null)
                    {
                        System.IO.File.Delete(imagedelete);
                        fi.Delete();
                    }
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        private async Task<Flower> GetFlowerById(int id)
        {
            Flower flower = new Flower();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage response = await client.GetAsync($"api/Flowers/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                flower = JsonConvert.DeserializeObject<Flower>(result);
            }
            return flower;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Flower flower = await GetFlowerById(id);
            FlowerViewModel vm = new FlowerViewModel();
            vm.Id = flower.FlowerId;
            vm.FlowerType = flower.FlowerType;
            vm.FileName = flower.FlowerImage;
            vm.FlowerCost = flower.FlowerCost;

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(FlowerViewModel flowerViewModel)
        {
            HttpClient client = new HttpClient();
            if (flowerViewModel.FlowerImage != null)
            {
                string uniqueFileName = UploadImage(flowerViewModel);
                flowerViewModel.FileName = uniqueFileName;
                flowerViewModel.FlowerImage = null;
            }
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/Flowers/{flowerViewModel.Id}", flowerViewModel);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(flowerViewModel);
        }


        public string UploadImage(FlowerViewModel flower)
        {
            string uniqueFileName = null;

            if (flower.FlowerImage != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "FlowerImages");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + flower.FlowerImage.FileName;
                var file = flower.FlowerImage;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                if (Directory.Exists(uploadsFolder))
                {
                    //    string fullpath = Path.Combine(uploadsFolder, uniqueFileName);
                    //    int width = 640;
                    //    int height = 425;
                    //    Image image = Image.FromStream(file.OpenReadStream());
                    //    var newImage = new Bitmap(width, height);
                    //    using (var a = Graphics.FromImage(newImage))
                    //    {
                    //        a.DrawImage(image, 0, 0, width, height);
                    //        newImage.Save(fullpath);
                    //    }
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        flower.FlowerImage.CopyTo(fileStream);
                    }
                }

            }
            return uniqueFileName;
        }
    }
}
