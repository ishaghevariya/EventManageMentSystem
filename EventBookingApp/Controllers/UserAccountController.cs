using DataAcessLayer;
using DataAcessLayer.ViewModel;
using EmailServices;
using EventBookingApp.API.ViewModel;
using EventBookingApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EventBookingApp.Controllers
{

    public class UserAccountController : Controller
    {
        private readonly ILogger<UserAccountController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IEmailSender _emailSender;
        public string AdminApiString;
        public UserAccountController(ILogger<UserAccountController> logger, IConfiguration configuration, IEmailSender emailSender)
        {
            _logger = logger;
            _configuration = configuration;
            _emailSender = emailSender;
            AdminApiString = _configuration.GetValue<string>("APISTRING");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(AdminApiString);
                var response = await client.GetAsync($"api/Account/Login?email={email}&password={password}");
                if (response.IsSuccessStatusCode)
                {
                    if (email != "ishaghevariya09@gmail.com")
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        if (Convert.ToInt32(result) > 0)
                        {
                            var cliams = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,email)
                    };
                            var identity = new ClaimsIdentity(
                                cliams, CookieAuthenticationDefaults.AuthenticationScheme);
                            var principal = new ClaimsPrincipal(identity);
                            var props = new AuthenticationProperties();
                            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
                            HttpContext.Session.SetString("UserId", result);
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "You are Admin please registor first as a user!!!");
                    }
                    // return RedirectToAction("Login");
                }
            }
            ModelState.AddModelError("", "Inavalid Username and Password");
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
            client.BaseAddress = new Uri(AdminApiString);
            var response = await client.PostAsJsonAsync<ApplicationUser>($"api/Account/Registration", applicationUser);
            if (response.IsSuccessStatusCode)
            {
                var MsgBody = "Hello  We have registred you on our portal sucessfully,Thank you.";
                var message = new Message(applicationUser.Email, "No Reply", MsgBody);
                _emailSender.SendEmail(message);
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("", "Email is already registor please use another email.");
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
        [Authorize]
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
        [HttpGet]
        [Authorize]
        public IActionResult UserChangePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserChangePassword(ChangePasswordModel user)
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
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Current password is not valid.");
                    }
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel user)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(AdminApiString);
                HttpResponseMessage response = await client.PostAsJsonAsync($"api/Account/ForgotPassword", user);
                if (response.IsSuccessStatusCode)
                {
                    var linkurl = Url.Action("ResetPassword", "UserAccount", new { email = user.Email });
                    var MsgBody = "Hello<br/> Please Click <a href='https://localhost:5001" + linkurl + "'>here<a/> to Reset your password<br/> Thank you,<br/>EMS";
                    var message = new Message(user.Email, "No Reply", MsgBody);
                    _emailSender.SendEmail(message);
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "Please check your email Id.");
                }
            }
            else
            {
                return RedirectToAction("ForgotPassword");
            }
            return View();
        }
        [HttpGet]
        public IActionResult ResetPassword(string email)
        {
            if (email == null)
            {
                ModelState.AddModelError("", "Invalid Link PLease try to contact admin");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(AdminApiString);
                HttpResponseMessage response = await client.GetAsync($"api/Account/GetUserByEmail/{model.Email}");
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    user = JsonConvert.DeserializeObject<ApplicationUser>(result);
                    if (user != null)
                    {
                        HttpClient client1 = new HttpClient();
                        client1.BaseAddress = new Uri(AdminApiString);
                        HttpResponseMessage response1 = await client1.PostAsJsonAsync($"api/Account/ResetPassword", model);
                        if (response1.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Login");
                        }
                    }
                }
            }
            return View();
        }
        //[HttpPost]
        //public async Task<JsonResult> GetEmail(string email)
        //{

        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("https://localhost:44362/");
        //    HttpResponseMessage response = await client.GetAsync($"api/Account/{email}");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var result = response.Content.ReadAsStringAsync().Result;
        //        return Json(result == null);
        //    }
        //    return null;
        //}


        public async Task<IActionResult> Index()
        {
            List<eventTypeViewModel> vm1 = new List<eventTypeViewModel>();
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri(AdminApiString);
            var response1 = await client1.GetAsync($"api/AddEvent/GetEventByTypes");
            if (response1.IsSuccessStatusCode)
            {
                var result = response1.Content.ReadAsStringAsync().Result;
                vm1 = JsonConvert.DeserializeObject<List<eventTypeViewModel>>(result);
                ViewBag.type = vm1;
            }
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public async Task<IActionResult> Events()
        {
            List<eventTypeViewModel> vm1 = new List<eventTypeViewModel>();
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri(AdminApiString);
            var response1 = await client1.GetAsync($"api/AddEvent/GetEventByTypes");
            if (response1.IsSuccessStatusCode)
            {
                var result = response1.Content.ReadAsStringAsync().Result;
                vm1 = JsonConvert.DeserializeObject<List<eventTypeViewModel>>(result);
                ViewBag.type = vm1;

            }
            List<ImageViewModel> imagemodel = new List<ImageViewModel>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage response = await client.GetAsync($"api/AddEvent/GetEventImages");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                imagemodel = JsonConvert.DeserializeObject<List<ImageViewModel>>(result);
                ViewBag.images = imagemodel;
            }
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> Events(BookingViewModel vm)
        {
            HttpClient client = new HttpClient();
            var data = HttpContext.Session.GetString("UserId");
            if (data != null)
            {
                vm.UserId = Convert.ToInt32(data);
                client.BaseAddress = new Uri(AdminApiString);
                var response = await client.PostAsJsonAsync($"api/EventBooking/AddBooking", vm);
                if (response.IsSuccessStatusCode)
                {
                    return Json("true");
                }
                return Json("false");                
            }
                return Json("false");
           // return Json("true");
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Gallery()
        {
            List<ImageViewModel> imagemodel = new List<ImageViewModel>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage response = await client.GetAsync($"api/AddEvent/GetEventImages");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                imagemodel = JsonConvert.DeserializeObject<List<ImageViewModel>>(result);
            }
            return View(imagemodel);
        }
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
