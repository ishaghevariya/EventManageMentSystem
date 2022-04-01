using DataAcessLayer;
using DataAcessLayer.ViewModel;
using EventBookingApp.API.Data;
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
   
    public class AddEventController : ControllerBase
    {
        private readonly IEventRepo _eventRepo;
        public AddEventController(IEventRepo eventRepo)
        {
            _eventRepo = eventRepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetEvents()
        {
            try
            {
                return Ok(await _eventRepo.GetEvents());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving data from database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            try
            {
                var result = await _eventRepo.GetEvent(id);
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

        [HttpPost("AddData")]
        public async Task<ActionResult<EventViewModel>> AddData(EventViewModel evetmodel)
        {
            try
            {
                if (evetmodel == null)
                {
                    return BadRequest();
                }
                var eventCreate = await _eventRepo.AddEvent(evetmodel);
                return CreatedAtAction(nameof(GetEvent), new { id = eventCreate.Id }, eventCreate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in post data to database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Event>> DeleteEvent(int id)
        {
            try
            {
                var eventDelete = await _eventRepo.GetEvent(id);
                if (eventDelete == null)
                {
                    return NotFound($"Event Id={id} not found");
                }
                return await _eventRepo.DeleteEvent(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when Delete data from database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Event>> UpdateEvent(EventViewModel eventmodel, int id)
        {
            try
            {
                if (id != eventmodel.Id)
                {
                    return BadRequest("Id Mismatch");
                }
                var eventUpdate = await _eventRepo.GetEvent(id);
                if (eventUpdate == null)
                {
                    return NotFound($"Event Id={id} not found");
                }
                return await _eventRepo.UpdateEvent(eventmodel);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving data from database");
            }
        }
    }
}
