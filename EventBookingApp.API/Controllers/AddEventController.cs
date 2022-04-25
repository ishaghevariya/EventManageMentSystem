using DataAcessLayer;
using DataAcessLayer.ViewModel;
using EventBookingApp.API.Data;
using EventBookingApp.API.Repositary;
using EventBookingApp.API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [HttpGet("GetEventByTypes")]
        public IEnumerable<eventTypeViewModel> GetEventByTypes()
        {
            try
            {
                var result = _eventRepo.GetEventsType();
                return result;
            }
            catch (Exception)
            {
                throw;
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
        public async Task<ActionResult<Event>> AddData(EventViewModel evetmodel)
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
        [HttpPost("StoringImage")]
        public async Task<int> StoringImage(EventGalleryModel vm)
        {
            try
            {
                if (vm == null)
                {
                    return 0;
                }
                var data = await _eventRepo.StoringImages(vm);
                return data;
            }
            catch (Exception)
            {
                return 0;
            }
        }


        [HttpPut("imgLink/{uniqueName}")]
        public string imgLink(string uniqueName, EventGalleryModel pvm)
        {
            var data = _eventRepo.AddImgLink(uniqueName, pvm);
            return "true";
        }

        [HttpGet("GetCurrentRecordId")]
        public async Task<int> GetCurrentRecordId()
        {
            var data = await _eventRepo.GetCurrentRecordId();
            return data;
        }

        [HttpGet("UpdateImage/{id}")]
        public async Task<IEnumerable<ImageViewModel>> UpdateImage(int id)
        {
            var data = await _eventRepo.UpdateImage(id);
            return data;
        }

        [HttpGet("GetEventImages")]
        public async Task<IEnumerable<ImageViewModel>> GetEventImages()
        {
            var data = await _eventRepo.GetEventImages();
            return data;
        }
        [HttpGet("DeleteImage/{id}")]
        public void DeleteImage(string id)
        {
            _eventRepo.DeleteImage(id);

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

        [HttpGet("Search/{EventTypes}")]
        public async Task<ActionResult<IEnumerable<Event>>> Search(string EventTypes)
        {
            try
            {
                var result = await _eventRepo.search(EventTypes);
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
    }
}
