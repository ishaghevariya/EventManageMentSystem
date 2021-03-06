using DataAcessLayer;
using DataAcessLayer.ViewModel;
using EventBookingApp.API.Repositary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBookingApp.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]

    public class FlowersController : ControllerBase
    {
        private readonly IFlowerRepo _flowerRepo;
        private readonly ILogger<FlowersController> _logger;

        public FlowersController(IFlowerRepo flowerRepo, ILogger<FlowersController> logger)
        {
            _flowerRepo = flowerRepo;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetFlowers()
        {
            try
            {
                return Ok(await _flowerRepo.GetFlowers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving data from database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Flower>> GetFlower(int id)
        {
            try
            {
                var result = await _flowerRepo.GetFlower(id);
                if (result == null)
                {
                    _logger.LogWarning($"Flower id {id} not found");
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving data from database");
            }
        }
        [HttpPost("AddFlower")]
        public async Task<ActionResult<FlowerViewModel>> AddFlower(FlowerViewModel flowermodel)
        {
            try
            {
                if (flowermodel == null)
                {
                    return BadRequest();
                }
                var flowerCreate = await _flowerRepo.AddFlower(flowermodel);
                return CreatedAtAction(nameof(GetFlower), new { id = flowerCreate.FlowerId }, flowerCreate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in post data to database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Flower>> DeleteFlower(int id)
        {
            try
            {
                var flowerDelete = await _flowerRepo.GetFlower(id);
                if (flowerDelete == null)
                {
                    _logger.LogWarning($"Flower id {id} not found");
                    return NotFound($"flower Id={id} not found");
                }
                return await _flowerRepo.DeleteFlower(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when Delete data from database");
            }
        }
        [HttpGet("GetImageName/{id}")]
        public string GetImageName(int id)
        {
            return _flowerRepo.GetImagename(id);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Flower>> UpdateFlower(FlowerViewModel flower, int id)
        {
            try
            {
                if (id != flower.Id)
                {
                    return BadRequest("Id Mismatch");
                }
                var flowerUpdate = await _flowerRepo.GetFlower(id);
                if (flowerUpdate == null)
                {
                    _logger.LogWarning($"Flower id {id} not found");
                    return NotFound($"Flower Id={id} not found");
                }
                return await _flowerRepo.UpdateFlower(flower);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving data from database");
            }
        }
        //[HttpGet("Search/{FlowerType}")]
        //public async Task<ActionResult<IEnumerable<Flower>>> Search(string FlowerType)
        //{
        //    try
        //    {
        //        var result = await _flowerRepo.Search(FlowerType);
        //        if (result.Any())
        //        {
        //            return Ok(result);
        //        }
        //        return NotFound();
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving data from database");
        //    }
        //}
    }
}
