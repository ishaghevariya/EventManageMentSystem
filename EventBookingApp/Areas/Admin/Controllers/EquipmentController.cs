using DataAcessLayer;
using Microsoft.AspNetCore.Authorization;
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

namespace EventBookingApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class EquipmentController : Controller
    {

        private readonly IConfiguration _configuration;
        public string AdminApiString;

        public EquipmentController(IConfiguration configuration)
        {
            _configuration = configuration;
            AdminApiString = _configuration.GetValue<string>("APISTRING");
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Equipment> equipment = new List<Equipment>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage response = await client.GetAsync("/api/Equipment");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                equipment = JsonConvert.DeserializeObject<List<Equipment>>(result);
            }
            return View(equipment);
        }
        //[HttpPost]
        //public async Task<IActionResult> Index(string EquipmentType)
        //{
        //    List<Equipment> equipment = new List<Equipment>();
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri(AdminApiString);
        //    HttpResponseMessage response = await client.GetAsync($"/api/Equipment/Search/{EquipmentType}");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var result = response.Content.ReadAsStringAsync().Result;
        //        equipment = JsonConvert.DeserializeObject<List<Equipment>>(result);
        //    }
        //    return View(equipment);
        //}
        private async Task<Equipment> GetEquipmentById(int id)
        {
            Equipment equipment = new Equipment();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage response = await client.GetAsync($"api/Equipment/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                equipment = JsonConvert.DeserializeObject<Equipment>(result);
            }
            return equipment;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Equipment equipment)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            var response = await client.PostAsJsonAsync<Equipment>($"/api/Equipment", equipment);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage response = await client.DeleteAsync($"api/Equipment/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Equipment equipment = await GetEquipmentById(id);
            return View(equipment);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Equipment equipment)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/Equipment/{equipment.EquipmentId}", equipment);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(equipment);
        }
    }
}
