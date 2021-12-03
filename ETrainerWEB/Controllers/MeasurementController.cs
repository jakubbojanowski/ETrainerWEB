using System;
using System.Threading.Tasks;
using ETrainerWEB.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using ETrainerWEB.Services;
using Microsoft.AspNetCore.Authorization;

namespace ETrainerWEB.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[action]")]
    public class MeasurementController : ControllerBase
    {
        private readonly MeasurementService _measurementService;
        public MeasurementController(MeasurementService measurementService)
        {
            _measurementService = measurementService;
        }
        //Get measurement by date
        [HttpGet]
        public async Task<IActionResult> Measurement([FromQuery]DateTime date)
        {
            var result = await _measurementService.GetMeasurementByDate(date);
            if(result != null)
                return Ok(result);
            return NotFound();
        }
        //Get user's measurements order by date
        [HttpGet]
        public async Task<IActionResult> Measurements()
        {
            var result = await _measurementService.GetMeasurements();
            if(result != null)
                return Ok(result);
            return NotFound();
        }
        //Add new measurement
        [HttpPost]
        public async Task<IActionResult> Measurement([FromBody] MeasurementDTO measurementDTO)
        { 
            var result = await _measurementService.AddMeasurement(measurementDTO);
            if(result != 0) 
                return Ok(result);
            return NotFound();
        }
        //Edit measurement
        [HttpPut]
        public async Task<IActionResult> EditMeasurement([FromBody] MeasurementDTO measurementDTO)
        {
            var result = await _measurementService.EditMeasurement(measurementDTO);
            if(result != 0) 
                return Ok(result);
            return NotFound();
        }
        //Delete measurement
        [HttpDelete("{measurementId:int}")]
        public async Task<IActionResult> DeleteMeasurement([FromRoute]int measurementId)
        {
            var result = await _measurementService.DeleteMeasurement(measurementId);
            if (result)
                return Ok();
            return NotFound();
        }
    }
}