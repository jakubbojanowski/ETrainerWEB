using System.Threading.Tasks;
using ETrainerWEB.Models.DTO;
using ETrainerWEB.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETrainerWEB.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> User()
        {
            var result =  await _userService.GetProfile();
            if(result != null) 
                return Ok(result);
            return NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> Measurement([FromBody]MeasurementDTO measurementDTO)
        {
            var result =  await _userService.EditMeasurement(measurementDTO);
            if(result) 
                return Ok();
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMeasurement([FromBody]MeasurementDTO measurementDTO)
        { 
            var result = await _userService.CreateMeasurement(measurementDTO);
            if(result) 
                return Ok();
            return NotFound();
        }
    }
}