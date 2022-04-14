using DataAcessLayer;
using DataAcessLayer.ViewModel;
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
    public class EventBookingController : ControllerBase
    {
        private readonly IBookingRepo _bookingRepo;
     
        public EventBookingController(IBookingRepo bookingRepo)
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

        [HttpGet("GetBookings/{id:int}")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings(int id)
        {
            try
            {
                return Ok(await _bookingRepo.GetBookings(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when get data from database ");
            }
        }

        [HttpGet("GetEventName/{id:int}")]
        public async Task<string> GetEventName(int id)
        {
            try
            {
                var data = await _bookingRepo.GetEventName(id);
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("GetCurrentRecordId")]
        public async Task<int> GetCurrentRecordId()
        {
            var data = await _bookingRepo.GetCurrentRecordId();
            return data;
        }
        [HttpGet("GetCurrentBookingId")]
        public async Task<int> GetCurrentBookingId()
        {
            var data = await _bookingRepo.GetCurrentBookingId();
            return data;
        }
        [HttpGet("AllBooking")]
        public async Task<ActionResult> AllBooking()
        {
            try
            {
                return Ok(await _bookingRepo.AllBookings());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when get data from database ");
            }
        }
        public async Task<ActionResult<BookingDetalis>> GetBookingDetalisById(int id)
        {
            try
            {
                var result = await _bookingRepo.AddBookingId(id);
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
        [HttpPost("AddBookingDetalis")]
        public async Task<ActionResult<BookingDetalis>> AddBookingDetalis(BookingDetalis booking)
        {
            try
            {
                if (booking == null)
                {
                    return BadRequest();
                }
                var BookingDetalisCreate = await _bookingRepo.AddBookingDetalis(booking);
                return CreatedAtAction(nameof(GetBookingDetalisById), new { id = BookingDetalisCreate.BookingDetalisId }, BookingDetalisCreate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when post data to database ");
            }
        }
        [HttpGet("GetFlowerByTypes")]
        public IEnumerable<FlowerTypeViewModel> GetFlowerByTypes()
        {
            try
            {
                var result = _bookingRepo.GetFlowerType();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("GetEquipmentByTypes")]
        public IEnumerable<EquipmentTypeViewModel> GetEquipmentByTypes()
        {
            try
            {
                var result = _bookingRepo.GetEquipmentType();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("GetFoodByTypes")]
        public IEnumerable<FoodTypeViewModel> GetFoodByTypes()
        {
            try
            {
                var result = _bookingRepo.GetFoodType();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("GetAllEventId/{userid:int}")]
        public async Task<IEnumerable<int>> GetAllEventId(int userid)
        {
            try
            {
                var result = await _bookingRepo.GetAllEventId(userid);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
