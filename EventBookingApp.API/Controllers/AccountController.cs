﻿using DataAcessLayer;
using DataAcessLayer.ViewModel;
using EventBookingApp.API.Repositary;
using EventBookingApp.API.ViewModel;
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
        [HttpGet("GetUsers")]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                return Ok(await _registrationRepo.GetUsers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving data from database");
            }
        }
        [HttpGet("GetUserByEmail/{email}")]
        public bool GetUserByEmail(string email)
        {
            try
            {
                var result = _registrationRepo.GetUserByEmail(email);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("UpdateProfile/{id:int}")]
        public async Task<ActionResult<ApplicationUser>> UpdateProfile(ApplicationUser User, int id)
        {
            try
            {
                if (id != User.Id)
                {
                    return BadRequest("Id Mismathch");
                }
                var Update = await _registrationRepo.GetUser(id);
                if (Update == null)
                {
                    return NotFound($"User Id={id} not found ");
                }
                return await _registrationRepo.Profile(User);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when update data to database");
            }
        }
        [HttpPost("Registration")]
        public async Task<ActionResult<ApplicationUser>> Registration(ApplicationUser applicationUser)
        {
            try
            {
                if (applicationUser == null)
                {
                    return BadRequest();
                }
                if (_registrationRepo.GetUserByEmail(applicationUser.Email)) 
                {
                    return StatusCode(409, $"User '{applicationUser.Email}' already exists.");
                }
                var userCreate = await _registrationRepo.UserRegistration(applicationUser);
                return CreatedAtAction(nameof(GetUser), new { id = userCreate.Id }, userCreate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when post data to database");

            }
        }
        [HttpDelete("DeleteUser/{id:int}")]
        public async Task<ActionResult<ApplicationUser>> DeleteUser(int id)
        {
            try
            {
                var UserDelete = await _registrationRepo.GetUser(id);
                if (UserDelete == null)
                {
                    return NotFound($"User Id={id} not found");
                }
                return await _registrationRepo.DeleteUser(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when Delete data from database");
            }
        }

        [HttpPut("ChangePassword")]
        public async Task<ActionResult<ApplicationUser>> ChangePassword(ChangePasswordModel model,string password)
        {
            try
            {
                if(password != model.CurrentPassword)
                {
                    return BadRequest("Password is Not Matched");
                }
                return await _registrationRepo.ChangePassword(model);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when post data to database");
            }
        }

        [HttpGet("{email,password}")]
        public int Login(string email,string password)
        {
            var user = _registrationRepo.SignInMethod(email, password);
            //string result = "false";
            //if (user != null)
            //{
            //    result = "true";
            //    HttpContext.Session.SetString("UserId", Convert.ToString(user.Id));
            //    var data = HttpContext.Session.GetString("UserId");
            //}
            return user;
        }

        [HttpGet("Search/{UserName}")]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>>Search(string UserName)
        {
            try
            {
                var result = await _registrationRepo.Search(UserName);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving data from database");
            }
        }

        //[HttpGet("{email,password}")]
        //public string Login(string email, string password)
        //{
        //    var user = _registrationRepo.SignInMethod(email, password);

        //    string result = "false";
        //    if (user != 0)
        //    {
        //        result = "true";
        //    }
        //    return result;
        //}
     
    }
}
