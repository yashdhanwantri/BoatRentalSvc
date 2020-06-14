using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoatRentalSvc.Classes;
using BoatRentalSvc.Interfaces;
using BoatRentalSvc.Models.EditModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BoatRentalSvc.Controllers
{
    [System.Web.Http.RoutePrefix("api/boatRental")]
    [ApiController]
    public class BoatRentalController : ControllerBase
    {
        private IBoatRentalBusinessLogic _boatRentalBusinessLogic;
        private IBoatBusinessLogic _boatBusinessLogic;
        public BoatRentalController(IBoatRentalBusinessLogic boatRentalBusinessLogic, IBoatBusinessLogic boatBusinessLogic)
        {
            _boatBusinessLogic = boatBusinessLogic;
            _boatRentalBusinessLogic = boatRentalBusinessLogic;
        }
        [HttpGet]
        [Route("getAllBoats")]
        public async Task<IActionResult> GetAllBoats()
        {
            try
            {
                var result = _boatBusinessLogic.GetAllBoats();

                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpGet]
        [Route("getBoats/{id}")]
        public async Task<IActionResult> GetBoatByID(int id)
        {
            try
            {
                var result = _boatBusinessLogic.GetBoatById(id);
                if (result != null)
                    return Ok(result);
                return NotFound();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpPost]
        [Route("registerBoat")]
        public async Task<IActionResult> RegisterBoat([Microsoft.AspNetCore.Mvc.FromBody] object json)
        {
            try
            {
                var editModel = JsonConvert.DeserializeObject<BoatEditModel>(json.ToString());
                var result = await _boatBusinessLogic.RegisterBoat(editModel);
                
                return Created("", result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deregisterBoat/{id}")]
        public async Task<IActionResult> DeregisterBoat(int id)
        {
            try
            {
                var result = await _boatBusinessLogic.RemoveBoat(id);
                if (!result)
                {
                    return NotFound($"Boat with ID: {id} not found");
                }
                return Ok($"Boat with ID: {id} successfully deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}