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
        public async Task<ActionResult<IEnumerable<BookingViewModel>>> GetBookings(int id)
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

     
        //[HttpGet("GetCurrentBookingId")]
        //public async Task<int> GetCurrentBookingId()
        //{
        //    var data = await _bookingRepo.GetCurrentBookingId();
        //    return data;
        //}

        [HttpGet("GetBookingCount")]
        public async Task<ActionResult<IEnumerable<EventCountViewModel>>> GetBookingCount()
        {
            try 
            {
                var data = await _bookingRepo.GetTotalBooking();
                return Ok(data);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when get data from database ");
            }
            
        }
        [HttpGet("GetTotalEquipmentBooking")]
        public async Task<ActionResult<IEnumerable<EquipmentCountViewModel>>> GetTotalEquipmentBooking()
        {
            try
            {
                var data = await _bookingRepo.GetTotalEquipmentBooking();
                return Ok(data);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when get data from database ");
            }
        }
        [HttpGet("GetTotalFlowerBooking")]
        public async Task<ActionResult<IEnumerable<FlowerCountViewModel>>> GetTotalFlowerBooking()
        {
            try
            {
                var data = await _bookingRepo.GetTotalFlowerBooking();
                return Ok(data);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when get data from database ");
            }
        }
        [HttpGet("GetTotalFoodBooking")]
        public async Task<ActionResult<IEnumerable<FlowerCountViewModel>>> GetTotalFoodBooking()
        {
            try
            {
                var data = await _bookingRepo.GetTotalFoodBooking();
                return Ok(data);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when get data from database ");
            }
        }

        [HttpGet("Invoice/{id:int}")]
        public async Task<ActionResult<IEnumerable<BookingDetalisViewModel>>> Invoice(int id)
        {
            try
            {
                var data = await _bookingRepo.Invoice(id);
                return Ok(data);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when get data from database ");
            }
        }
        //[HttpGet("GetAllBookingId")]
        //public async Task<BookingDetalis> GetAllBookingId(int Id)
        //{
        //    var data = await _bookingRepo.AllBookingId(Id);
        //    return data;
        //}
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
        [HttpGet("GetBookingStatus")]
        public IEnumerable<BookingStatus> GetBookingStatus()
        {
            try
            {
                var result = _bookingRepo.GetBookingStatuses();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("UpdateBookingStatus/{Bid}/{statusid}")]
        public async Task<Booking> UpdateBookingStatus(int Bid, int statusid)
        {
            try
            {
                var data = await _bookingRepo.UpdateBookingStatus(Bid, statusid);
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("AllBookingDetalis/{Id:int}")]
        public async Task<ActionResult> AllBookingDetalis(int Id)
        {
            try
            {
                return Ok(await _bookingRepo.AllBookingDetalis(Id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when get data from database ");
            }
        }

        [HttpDelete("DeleteBooking/{id:int}")]
        public async Task<ActionResult<Booking>> DeleteBooking(int id)
        {
            try
            {
                var bookingDelete = await _bookingRepo.GetBooking(id);
                if (bookingDelete == null)
                {
                    return NotFound($"Booking Id={id} not found");
                }
                return await _bookingRepo.DeleteBooking(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when Delete data from database");
            }
        }
    }
}
