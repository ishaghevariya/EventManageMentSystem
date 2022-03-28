using DataAcessLayer;
using DataAcessLayer.ViewModel;
using Microsoft.AspNetCore.Authorization;
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

    public class FlowerController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Flower> flower = new List<Flower>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44362/");
            HttpResponseMessage response = await client.GetAsync("/api/Flowers");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                flower = JsonConvert.DeserializeObject<List<Flower>>(result);
            }
            return View(flower);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FlowerViewModel flowermodel)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44362/");
            var response = await client.PostAsJsonAsync<FlowerViewModel>($"api/Flowers/AddFlower", flowermodel);
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
            HttpResponseMessage response = await client.DeleteAsync($"api/Flowers/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
