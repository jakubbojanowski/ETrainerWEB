using ETrainerWEB.Models.DTO;
using ETrainerWEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace ETrainerWEB.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult User()
        {
            var result =  _userService.GetProfile();
            if(result != null) 
                return Ok(result);
            return NotFound();
        }
        [HttpPut]
        public IActionResult Measurement([FromBody]MeasurementDTO measurementDTO)
        {
            var result =  _userService.EditMeasurement(measurementDTO).Result;
            if(result) 
                return Ok();
            return NotFound();
        }
        [HttpPost]
        public IActionResult CreateMeasurement([FromBody]MeasurementDTO measurementDTO)
        { 
            var result = _userService.CreateMeasurement(measurementDTO).Result;
            if(result) 
                return Ok();
            return NotFound();
        }
    }
}