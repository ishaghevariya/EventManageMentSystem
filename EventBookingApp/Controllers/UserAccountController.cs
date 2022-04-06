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
        public UserAccountController(ILogger<UserAccountController> logger, IConfiguration configuration,IEmailSender emailSender)
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
            ApplicationUser user = new ApplicationUser();

            client.BaseAddress = new Uri(AdminApiString);
            var response = await client.GetAsync($"api/Account/Login?email={email}&password={password}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                if (result == "true")
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
                  //  HttpContext.Session.SetString("Name", email);
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
            var response = await client.PostAsJsonAsync<ApplicationUser>($"api/Account/Registration",applicationUser);
            if (response.IsSuccessStatusCode)
            {
                var MsgBody = "Hello  We have registred you on our portal sucessfully,Thank you.";
                var message = new Message(applicationUser.Email, "No Reply", MsgBody);
                _emailSender.SendEmail(message);
                return RedirectToAction("Login");
            }
            return View();
        }

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
           // HttpContext.Session.Remove("Name");
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
