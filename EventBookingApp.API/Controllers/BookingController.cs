using DataAcessLayer;
using EventBookingApp.API.Repositary;
using EventBookingApp.API.ViewModel;
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
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepo _bookingRepo;
        public BookingController(IBookingRepo bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }
        public async Task<ActionResult<Booking>> GetBookingById(int id)
        {
            try
            {
                var result = await _bookingRepo.GetBooking(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrveing data from database ");
            }
        }
        [HttpPost("AddBooking")]
        public async Task<ActionResult<Booking>> AddBooking(BookingViewModel booking)
        {
            try
            {
                if (booking == null)
                {
                    return BadRequest();
                }
                var userCreate = await _bookingRepo.AddBooking(booking);
                return CreatedAtAction(nameof(GetBookingById), new { id = userCreate.Id }, userCreate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when post data to database ");
            }
        }

    }
}
