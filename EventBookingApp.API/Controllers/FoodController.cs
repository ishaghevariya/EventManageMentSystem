using DataAcessLayer;
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
    public class FoodController : ControllerBase
    {
        private readonly IFoodRepo _foodRepo;
        public FoodController(IFoodRepo foodRepo)
        {
            _foodRepo = foodRepo;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Food>> GetFood(int id)
        {
            try
            {
                var result = await _foodRepo.GetFood(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retwring Data from database");
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetFoods()
        {
            try
            {
                return Ok(await _foodRepo.GetFoods());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retwring Data from database");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Food>> AddFood(Food food)
        {
            try
            {
                if (food == null)
                {
                    return BadRequest();
                }
                var createFood = await _foodRepo.AddFood(food);
                return CreatedAtAction(nameof(GetFood), new { id = createFood.FoodId}, createFood);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when post data to database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Food>> UpdateFood(Food food, int id)
        {
            try
            {
                if (id != food.FoodId)
                {
                    return BadRequest("Id Mismathch");
                }
                var foodUpdate = await _foodRepo.GetFood(id);
                if (foodUpdate == null)
                {
                    return NotFound($"Food Id={id} not found ");
                }
                return await _foodRepo.UpdateFood(food);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when update data to database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Food>> DeleteFood(int id)
        {
            try
            {
                var foodDelete = await _foodRepo.GetFood(id);
                if (foodDelete == null)
                {
                    return NotFound($"Food Id = {id} not found");
                }
                return await _foodRepo.DeleteFood(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when update data to database");
            }
        }
    }
}
