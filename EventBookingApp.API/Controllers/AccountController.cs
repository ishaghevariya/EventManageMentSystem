using DataAcessLayer;
using DataAcessLayer.ViewModel;
using EventBookingApp.API.Repositary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBookingApp.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IRegistrationRepo _registrationRepo;
        public AccountController(IRegistrationRepo registrationRepo)
        {
            _registrationRepo = registrationRepo;
        }
        [HttpGet("GetUser/{id:int}")]
        public async Task<ActionResult<ApplicationUser>> GetUser(int id)
        {
            try
            {
                var result = await _registrationRepo.GetUser(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving data from database");
            }
        }

        //[HttpGet("GetUserByEmail/{email}")]
        //public async Task<ActionResult<ApplicationUser>> GetUserByEmail(string email)
        //{
        //    try
        //    {
        //        var result = await _registrationRepo.GetUserByEmail(email);
        //        if (result == null)
        //        {
        //            return NotFound();
        //        }
        //        return result;
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving email from database");
        //    }
        //}
        [HttpPost("Registration")]
        public async Task<ActionResult<ApplicationUser>> Registration(ApplicationUser applicationUser)
        {
            try
            {
                if (applicationUser == null)
                {
                    return BadRequest();
                }
                var userCreate = await _registrationRepo.UserRegistration(applicationUser);
                return CreatedAtAction(nameof(GetUser), new { id = userCreate.Id }, userCreate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when post data to database");

            }
        }

        [HttpPut("ChangePassword")]
        public async Task<ActionResult<ApplicationUser>> ChangePassword(ChangePasswordModel model)
        {
            try
            {
                return await _registrationRepo.changePassword(model);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when post data to database");
            }
        }

        [HttpGet("{email,password}")]
        public string Login(string email, string password)
        {
            var user = _registrationRepo.SignInMethod(email, password);
            string result = "false";
            if (user != 0)
            {
                result = "true";
            }
            return result;
        }

    }
}
