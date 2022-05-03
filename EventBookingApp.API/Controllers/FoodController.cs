using DataAcessLayer;
using EventBookingApp.API.Repositary;
using Microsoft.AspNetCore.Authorization;
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
    public class FoodController : ControllerBase
    {
        private readonly IFoodRepo _foodRepo;
        private readonly ILogger<FoodController> _logger;
        public FoodController(IFoodRepo foodRepo, ILogger<FoodController> logger)
        {
            _foodRepo = foodRepo;
            _logger = logger;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Food>> GetFood(int id)
        {
            try
            {
                var result = await _foodRepo.GetFood(id);
                if (result == null)
                {
                    _logger.LogWarning($"Food id {id} not found");
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
                    _logger.LogWarning($"Food id {id} not found");
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
                    _logger.LogWarning($"Food id {id} not found");
                    return NotFound($"Food Id = {id} not found");
                }
                return await _foodRepo.DeleteFood(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when update data to database");
            }
        }
        //[HttpGet("Search/{FoodType}")]
        //public async Task<ActionResult<IEnumerable<Food>>> Search(string FoodType)
        //{
        //    try
        //    {
        //        var result = await _foodRepo.Search(FoodType);
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
