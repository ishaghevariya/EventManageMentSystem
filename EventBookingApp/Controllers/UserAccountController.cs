using DataAcessLayer;
using EmailServices;
using EventBookingApp.API.ViewModel;
using EventBookingApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            var response = await client.GetAsync($"api/Account/Login?email={email}&password={password}");
            if (response.IsSuccessStatusCode)
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
            client.BaseAddress = new Uri(AdminApiString);
            var response = await client.PostAsJsonAsync<ApplicationUser>($"api/Account/Registration", applicationUser);
            if (response.IsSuccessStatusCode)
            {
                var MsgBody = "Hello  We have registred you on our portal sucessfully,Thank you.";
                var message = new Message(applicationUser.Email, "No Reply", MsgBody);
                _emailSender.SendEmail(message);
                return RedirectToAction("Login");
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
        public IActionResult ChangePassword()
        {
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


        public IActionResult Index()
        {
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
        public IActionResult Events()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Gallery()
        {
            return View();
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
