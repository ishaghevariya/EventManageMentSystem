using DataAcessLayer;
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
        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            try
            {
                var result = await _registrationRepo.GetUserByEmail(email);
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
                var email = _registrationRepo.GetUserByEmail(applicationUser.Email);
                if (email != null) 
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
        public async Task<ActionResult<ApplicationUser>> ChangePassword(ChangePasswordModel model)
        {
            try
            {
                ApplicationUser user = await _registrationRepo.GetUser(model.id);
                if(user.Password != model.CurrentPassword)
                {
                    return BadRequest("Current Password is not valid");
                }
                return await _registrationRepo.ChangePassword(model);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when change password");
            }
        }

        [HttpPost("ForgotPassword")]
        public async Task<ActionResult<ApplicationUser>> ForgotPassword(ForgotPasswordViewModel model)
        {
            try
            {
                var email = await _registrationRepo.GetUserByEmail(model.Email);
                if (email!=null)
                {
                    return await _registrationRepo.ForgotPassword(model);
                }
                return BadRequest("Email is not matched!!!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when forgot password");
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
        [HttpPost("ResetPassword")]
        public async Task<ActionResult<ApplicationUser>> ResetPassword(ResetPasswordViewModel model)
        {
            try
            {
                return await _registrationRepo.ResetPassword(model);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when Reset password");
            }
        }

        [HttpGet("GetUsersByPagging")]
        public async Task<ActionResult> GetUsersByPagging(int pageNo, int pageSize)
        {
            try
            {
                return Ok(await _registrationRepo.GetUsersByPaggination(pageNo,pageSize));
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

        [HttpGet("GetFeedback/{id:int}")]
        public async Task<ActionResult<FeedBack>> GetFeedback(int id)
        {
            try
            {
                var result = await _registrationRepo.GetFeedBack(id);
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
        [HttpPost("AddFeedback")]
        public async Task<ActionResult<FeedBack>> AddFeedback(FeedbackViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }
                var FeedbackCreate = await _registrationRepo.FeedBack(model);
                return CreatedAtAction(nameof(GetFeedback), new { id = FeedbackCreate.Id }, FeedbackCreate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when post data to database");

            }
        }

    }
}
