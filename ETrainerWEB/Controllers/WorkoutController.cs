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
    public class WorkoutController : ControllerBase
    {
        private readonly WorkoutService _workoutService;
        public WorkoutController(WorkoutService workoutService)
        {
            _workoutService = workoutService;
        }
        //Get workout by date
        [HttpGet]
        public async Task<IActionResult> Workout([FromQuery]DateTime date)
        {
            var result  = await _workoutService.GetWorkoutByDate(date);
            if(result != null) 
                return Ok(result);
            return NotFound();
        }
        //Get workout ID by date
        [HttpGet]
        public async Task<IActionResult> WorkoutId([FromQuery]DateTime date)
        {
            var result = await _workoutService.GetWorkoutIdByDate(date);
            if(result != 0)
                return Ok(result);
            return NotFound();
        }
        //Add new workout
        [HttpPost]
        public async Task<IActionResult> Workout([FromBody] WorkoutDTO workout)
        {
            var result = await _workoutService.AddWorkout(workout);
            if (result != 0)
                return Ok(result);
            return NotFound();
        }
    }
}
