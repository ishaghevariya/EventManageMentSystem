using DataAcessLayer;
using DataAcessLayer.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        public async Task<IActionResult> AdminLogin(string email, string password)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44362/");
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
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal,props).Wait();

                    HttpContext.Session.SetString("Name", email);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("AdminLogin");
            }
            return View();
        }
        //private static async Task<ApplicationUser> GetUserByEmail(string email)
        //{
        //    ApplicationUser user = new ApplicationUser();
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("https://localhost:44362/");
        //    HttpResponseMessage response = await client.GetAsync($"api/Account/{email}");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var result = response.Content.ReadAsStringAsync().Result;
        //        user = JsonConvert.DeserializeObject<ApplicationUser>(result);
        //    }
        //    return user;
        //}
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel user)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44362/");
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/Account/ChangePassword", user);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("AdminLogin");
            }
            return View(user);
        }
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("Name");
            return RedirectToAction("AdminLogin");
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
      
    }
}
