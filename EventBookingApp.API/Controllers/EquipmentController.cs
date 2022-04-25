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
  
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentRepo _equipmentRepo;
        public EquipmentController(IEquipmentRepo equipmentRepo)
        {
            _equipmentRepo = equipmentRepo;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Equipment>> GetEquipment(int id)
        {
            try
            {
                var result = await _equipmentRepo.GetEquipment(id);
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
        public async Task<ActionResult> GetEquipments()
        {
            try
            {
                return Ok(await _equipmentRepo.GetEquipments());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retwring Data from database");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Equipment>> AddEquipment(Equipment equipment)
        {
            try
            {
                if(equipment == null)
                {
                    return BadRequest();
                }
                var createEquipment = await _equipmentRepo.AddEquipment(equipment);
                return CreatedAtAction(nameof(GetEquipment), new { id = createEquipment.EquipmentId }, createEquipment);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when post data to database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Equipment>> UpdateEquipment(Equipment equipment,int id)
        {
            try
            {
                if(id != equipment.EquipmentId)
                {
                    return BadRequest("Id Mismathch");
                }
                var equipmentUpdate = await _equipmentRepo.GetEquipment(id);
                if(equipmentUpdate == null)
                {
                    return NotFound($"Equipment Id={id} not found ");
                }
                return await _equipmentRepo.UpdateEquipment(equipment);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when update data to database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Equipment>> DeleteEquipment(int id)
        {
            try
            {
                var equipmentDelete = await _equipmentRepo.GetEquipment(id);
                if(equipmentDelete == null)
                {
                    return NotFound($"Equipment Id = {id} not found");
                }
                return await _equipmentRepo.DeleteEquipment(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when update data to database");
            }
        }
        //[HttpGet("Search/{EquipmentType}")]
        //public async Task<ActionResult<IEnumerable<Equipment>>> Search(string EquipmentType)
        //{
        //    try
        //    {
        //        var result = await _equipmentRepo.Search(EquipmentType);
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
