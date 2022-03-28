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
    public class FlowersController : ControllerBase
    {
        private readonly IFlowerRepo _flowerRepo;
        public FlowersController(IFlowerRepo flowerRepo)
        {
            _flowerRepo = flowerRepo;
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
        public async Task<ActionResult<FlowerViewModel>> AddFlower([FromForm] FlowerViewModel flowermodel)
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
                    return NotFound($"flower Id={id} not found");
                }
                return await _flowerRepo.DeleteFlower(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when Delete data from database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Flower>> UpdateFlower(Flower flower, int id)
        {
            try
            {
                if (id != flower.FlowerId)
                {
                    return BadRequest("Id Mismatch");
                }
                var flowerUpdate = await _flowerRepo.GetFlower(id);
                if (flowerUpdate == null)
                {
                    return NotFound($"Flower Id={id} not found");
                }
                return await _flowerRepo.UpdateFlower(flower);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving data from database");
            }
        }
    }
}
