using DataAcessLayer;
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
  
    public class FoodController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Food> food = new List<Food>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44362/");
            HttpResponseMessage response = await client.GetAsync("/api/Food");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                food = JsonConvert.DeserializeObject<List<Food>>(result);
            }
            return View(food);
        }
        private static async Task<Food> GetFoodById(int id)
        {
            Food food = new Food();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44362/");
            HttpResponseMessage response = await client.GetAsync($"api/Food/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                food = JsonConvert.DeserializeObject<Food>(result);
            }
            return food;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Food food)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44362/");
            var response = await client.PostAsJsonAsync<Food>($"/api/Food", food);
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
            HttpResponseMessage response = await client.DeleteAsync($"api/Food/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Food food = await GetFoodById(id);
            return View(food);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Food food)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44362/");
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/Food/{food.FoodId}", food);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(food);
        }
    }
}
