using DataAcessLayer;
using DataAcessLayer.ViewModel;
using EventBookingApp.API.ViewModel;
using EventBookingApp.Web.Helper;
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
                var response = await client.GetAsync($"api/Account/Login/{email}/{password}");
                if (response.IsSuccessStatusCode)
                {
                    if (email == "ishaghevariya09@gmail.com")
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
            ModelState.AddModelError("", "Inavalid Username and Password");
            return View();
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
                        if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        {
                            ModelState.AddModelError("", "Current password is not valid.");
                            return View();
                        }
                        return RedirectToAction("AdminLogin");
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
            //TotalBookedEvent
            List<EventCountViewModel> model = new List<EventCountViewModel>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            var response = await client.GetAsync($"api/EventBooking/GetBookingCount");
            if (response.IsSuccessStatusCode)
            {
                var count = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<List<EventCountViewModel>>(count);
                ViewBag.count = model;
            }
            //TotalCancleBooking
            List<string> Cname = new List<string>();
            List<int> CCount = new List<int>();
            List<EventCountViewModel> model4 = new List<EventCountViewModel>();
            HttpClient client4 = new HttpClient();
            client4.BaseAddress = new Uri(AdminApiString);
            var response4 = await client4.GetAsync($"api/EventBooking/GetCancleBooking");
            if (response.IsSuccessStatusCode)
            {
                var count4 = response4.Content.ReadAsStringAsync().Result;
                model4 = JsonConvert.DeserializeObject<List<EventCountViewModel>>(count4);
                foreach (var item in model4)
                {
                    Cname.Add(item.EventName);
                    CCount.Add(item.Count);
                }
                ViewBag.Cname = JsonConvert.SerializeObject(Cname);
                ViewBag.Ccount = JsonConvert.SerializeObject(CCount);
            }
            //TotalBookedEquipment
            List<string> name = new List<string>();
            List<int> Ecount = new List<int>();
            List<EquipmentCountViewModel> model2 = new List<EquipmentCountViewModel>();
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri(AdminApiString);
            var response1 = await client1.GetAsync($"api/EventBooking/GetTotalEquipmentBooking");
            if (response1.IsSuccessStatusCode)
            {
                var count2 = response1.Content.ReadAsStringAsync().Result;
                model2 = JsonConvert.DeserializeObject<List<EquipmentCountViewModel>>(count2);
                foreach (var item in model2)
                {
                    name.Add(item.EquipmentName);
                    Ecount.Add(item.Count);

                }
                ViewBag.Ename = JsonConvert.SerializeObject(name);
                ViewBag.ECount = JsonConvert.SerializeObject(Ecount);
            }
            //TotalBookedflower
            List<string> fname = new List<string>();
            List<int> fcount = new List<int>();
            List<FlowerCountViewModel> Flowermodel = new List<FlowerCountViewModel>();
            HttpClient client2 = new HttpClient();
            client2.BaseAddress = new Uri(AdminApiString);
            var response2 = await client2.GetAsync($"api/EventBooking/GetTotalFlowerBooking");
            if (response2.IsSuccessStatusCode)
            {
                var count3 = response2.Content.ReadAsStringAsync().Result;
                Flowermodel = JsonConvert.DeserializeObject<List<FlowerCountViewModel>>(count3);
                foreach (var item in Flowermodel)
                {
                    fname.Add(item.FlowerName);
                    fcount.Add(item.Count);
                }
                ViewBag.fname = JsonConvert.SerializeObject(fname);
                ViewBag.fcount = JsonConvert.SerializeObject(fcount);
            }
            //TotalBookedFood
            List<string> foname = new List<string>();
            List<int> focount = new List<int>();
            List<FoodCountViewModel> Foodmodel = new List<FoodCountViewModel>();
            HttpClient client3 = new HttpClient();
            client3.BaseAddress = new Uri(AdminApiString);
            var response3 = await client2.GetAsync($"api/EventBooking/GetTotalFoodBooking");
            if (response3.IsSuccessStatusCode)
            {
                var count4 = response3.Content.ReadAsStringAsync().Result;
                Foodmodel = JsonConvert.DeserializeObject<List<FoodCountViewModel>>(count4);
                foreach (var item in Foodmodel)
                {
                    foname.Add(item.FoodName);
                    focount.Add(item.Count);
                }
                ViewBag.foname = JsonConvert.SerializeObject(foname);
                ViewBag.focount = JsonConvert.SerializeObject(focount);
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
                ViewBag.Message = "Your Profile Updated Sucessfully";
                return View(user);
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
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    TempData["Message"] = "User Have a Booked Event You Can not Delete User!!.";
                    return RedirectToAction("UserDetalis");
                }
                else
                {
                    return RedirectToAction("UserDetalis");
                }
            }
            return RedirectToAction("UserDetalis");
        }

        //[HttpGet]
        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> UserDetalis(int pageNumber = 1)
        //{
        //    List<ApplicationUser> users = new List<ApplicationUser>();
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri(AdminApiString);
        //    HttpResponseMessage response = await client.GetAsync($"api/Account/GetUsers");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var result = response.Content.ReadAsStringAsync().Result;
        //        users = JsonConvert.DeserializeObject<List<ApplicationUser>>(result);
        //    }
        //    var resultdata = users.AsEnumerable();
        //    int pageSize = 3;
        //    return View(PaginatedList<ApplicationUser>.CreateAsync(resultdata, pageNumber, pageSize));
        //}

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
        //[HttpPost]
        //public async Task<IActionResult> UserDetalis(string UserName, int pageNumber = 1)
        //{
        //    List<ApplicationUser> users = new List<ApplicationUser>();
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri(AdminApiString);
        //    HttpResponseMessage response = await client.GetAsync($"api/Account/Search/{UserName}");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var result = response.Content.ReadAsStringAsync().Result;
        //        users = JsonConvert.DeserializeObject<List<ApplicationUser>>(result);
        //    }
        //    var resultdata = users.AsEnumerable();
        //    int pageSize = 3;
        //    return View(PaginatedList<ApplicationUser>.CreateAsync(resultdata, pageNumber, pageSize));
        //}
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
        public async Task<IActionResult> DeleteBooking(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage response = await client.DeleteAsync($"api/EventBooking/DeleteBooking/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("AllBookings");
            }
            return null;
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
        [HttpGet]
        public async Task<IActionResult> AllFeedback()
        {
            List<FeedbackViewModel> vm = new List<FeedbackViewModel>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            var response1 = await client.GetAsync($"api/Account/GetFeedbacks");
            if (response1.IsSuccessStatusCode)
            {
                var result = response1.Content.ReadAsStringAsync().Result;
                vm = JsonConvert.DeserializeObject<List<FeedbackViewModel>>(result);
            }
            return View(vm);
        }
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage response = await client.DeleteAsync($"api/Account/DeleteFeedback/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("AllFeedback");
            }
            return View();
        }
    }
}
