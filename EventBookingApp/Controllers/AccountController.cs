using DataAcessLayer;
using EventBookingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EventBookingApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
 
        public async Task<IActionResult> Login(string email,string password)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44362/");
            var response = await client.GetAsync($"api/Account/Login?email={email}&password={password}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                if (result == "true") {
                    return RedirectToAction("Index");   
                }
                return RedirectToAction("Login");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(ApplicationUser applicationUser)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44362/");
            var response = await client.PostAsJsonAsync<ApplicationUser>($"api/Account/Registration",applicationUser);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
