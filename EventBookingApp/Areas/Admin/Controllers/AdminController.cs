using DataAcessLayer;
using DataAcessLayer.ViewModel;
using EventBookingApp.API.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EventBookingApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AdminController : Controller
    {
        private readonly IConfiguration _configuration;
        public string AdminApiString;

        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;
            AdminApiString = _configuration.GetValue<string>("APISTRING");
        }
        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        public async Task<IActionResult> AdminLogin(string email, string password)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(AdminApiString);
                var response = await client.GetAsync($"api/Account/Login?email={email}&password={password}");
                if (response.IsSuccessStatusCode)
                {
                    if (email == "ishaghevariya09@gmail.com" && password == "Isha1234")
                    {
                        ClaimsIdentity identity = null;
                        var result = response.Content.ReadAsStringAsync().Result;

                        if (Convert.ToUInt32(result) > 0)
                        {
                            identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name,email),
                                                              new Claim(ClaimTypes.Role,"Admin")
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                            var principal = new ClaimsPrincipal(identity);
                            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal).Wait();
                            HttpContext.Session.SetString("UserId", result);
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "You are Not Admin!!!");
                    }
                }
            }
            return RedirectToAction("AdminLogin");
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel user)
        {
            if (ModelState.IsValid)
            {
                var data = HttpContext.Session.GetString("UserId");
                user.id = Convert.ToInt32(data);
                if (user.id != 0)
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(AdminApiString);
                    HttpResponseMessage response = await client.PutAsJsonAsync($"api/Account/ChangePassword", user);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("AdminLogin");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Current password is not valid.");
                    }
                }
                else
                {
                    return RedirectToAction("AdminLogin");
                }
            }
            return View();
        }
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("AdminLogin");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            //List<int> EventId = new List<int>();
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(AdminApiString);
            //var response = await client.GetAsync($"api/AddEvent/AllEventId");
            //if(response.IsSuccessStatusCode)
            //{
            //    var id = response.Content.ReadAsStringAsync().Result;
            //    EventId = JsonConvert.DeserializeObject<List<int>>(id);
            //    foreach(var Id in EventId)
            //    {
            List<EventCountViewModel> model = new List<EventCountViewModel>();
            HttpClient client2 = new HttpClient();
            client2.BaseAddress = new Uri(AdminApiString);
            var response2 = await client2.GetAsync($"api/EventBooking/GetBookingCount");
            if (response2.IsSuccessStatusCode)
            {
                var count = response2.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<List<EventCountViewModel>>(count);
                ViewBag.count = model;
            }
            return View();
        }
        private async Task<ApplicationUser> GetUserById(int id)
        {
            var data = HttpContext.Session.GetString("UserId");
            id = Convert.ToInt32(data);
            ApplicationUser user = new ApplicationUser();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage response = await client.GetAsync($"api/Account/GetUser/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<ApplicationUser>(result);
            }
            return user;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Profile()
        {
            var data = HttpContext.Session.GetString("UserId");
            int id = Convert.ToInt32(data);
            ApplicationUser user = await GetUserById(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(ApplicationUser user)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/Account/UpdateProfile/{user.Id}", user);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(user);
        }
        public async Task<IActionResult> Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage response = await client.DeleteAsync($"api/Account/DeleteUser/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("UserDetalis");
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UserDetalis()
        {
            List<ApplicationUser> users = new List<ApplicationUser>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage response = await client.GetAsync($"api/Account/GetUsers");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<ApplicationUser>>(result);
            }
            return View(users);
        }
        [HttpPost]
        public async Task<IActionResult> UserDetalis(string UserName)
        {
            List<ApplicationUser> users = new List<ApplicationUser>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage response = await client.GetAsync($"api/Account/Search/{UserName}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<ApplicationUser>>(result);
            }
            return View(users);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AllBookings()
        {
            List<BookingStatus> vm1 = new List<BookingStatus>();
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri(AdminApiString);
            var response1 = await client1.GetAsync($"api/EventBooking/GetBookingStatus");
            if (response1.IsSuccessStatusCode)
            {
                var result = response1.Content.ReadAsStringAsync().Result;
                vm1 = JsonConvert.DeserializeObject<List<BookingStatus>>(result);
                ViewBag.BookingStatus = vm1;
            }
            List<BookingViewModel> Booking = new List<BookingViewModel>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage response = await client.GetAsync($"api/EventBooking/AllBooking");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                Booking = JsonConvert.DeserializeObject<List<BookingViewModel>>(result);
            }
            return View(Booking);
        }
        [HttpPost]
        public async Task<JsonResult> AllBookings(int StatusId, int Id)
        {
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri(AdminApiString);
            var response1 = await client1.GetAsync($"api/EventBooking/UpdateBookingStatus/{Id}/{StatusId}");
            if (response1.IsSuccessStatusCode)
            {
                var result = response1.Content.ReadAsStringAsync().Result;
                return Json("true");
            }
            return Json("false");
        }
        [HttpGet]
        public async Task<IActionResult> AllBookingDecoration(int Id)
        {
            List<BookingDetalisViewModel> vm = new List<BookingDetalisViewModel>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            var response1 = await client.GetAsync($"api/EventBooking/AllBookingDetalis/{Id}");
            if (response1.IsSuccessStatusCode)
            {
                var result = response1.Content.ReadAsStringAsync().Result;
                vm = JsonConvert.DeserializeObject<List<BookingDetalisViewModel>>(result);
            }
            return View(vm);
        }
    }
}
