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
    [Route("api")]
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

        #region Boat Registration/Deregistration/Fetch Endpoints
        [HttpGet]
        [Route("boat/getAllBoats")]
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
        [Route("boat/getBoats/{id}")]
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
        [Route("boat/registerBoat")]
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
        [Route("boat/deregisterBoat/{id}")]
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
        #endregion

        #region Boat Rental Endpoints
        [HttpGet]
        [Route("boatRental/getAllRental")]
        public async Task<IActionResult> GetAllRentals()
        {
            try
            {
                var result = _boatRentalBusinessLogic.GetBoatRentals();
                if (result == null)
                {
                    return NotFound($"No Boat Rental Exists!!");
                }
                else
                    return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("boatRental/getRental/{id}/{asOfTime}")]
        public async Task<IActionResult> GetRental(int id, string asOfTime)
        {
            try
            {
                DateTime parsedDate;
                if (!DateTime.TryParse(asOfTime, out parsedDate))
                    throw new Exception($"Invalid asOfTime {asOfTime}");
                var result = _boatRentalBusinessLogic.GetBoatRental(id, parsedDate);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        [Route("boatRental/rentBoat/{boatId}/{customerName}/{effectiveDate}")]
        public async Task<IActionResult> RentBoat(int boatId, string customerName, string effectiveDate)
        {
            try
            {
                DateTime parsedDate;
                if (!DateTime.TryParse(effectiveDate, out parsedDate))
                    throw new Exception($"Invalid asOfTime {effectiveDate}");
                var result = await _boatRentalBusinessLogic.RentBoat(boatId, customerName, parsedDate);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost]
        [Route("boatRental/returnBoat/{boatId}/{customerName}")]
        public async Task<IActionResult> ReturnBoat(int boatId, string customerName)
        {
            try
            {
                var result = await _boatRentalBusinessLogic.ReturnBoat(boatId, customerName);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}