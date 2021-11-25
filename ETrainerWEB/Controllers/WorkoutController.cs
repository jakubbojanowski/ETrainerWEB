using System;
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
        public IActionResult Workout([FromQuery]DateTime date)
        {
            var result = _workoutService.GetWorkoutByDate(date);
            if(result != null)
                return Ok(result);
            return NotFound();
        }
        //Add new workout
        [HttpPost]
        public IActionResult Workout([FromBody] WorkoutDTO workout)
        { 
            var result = _workoutService.AddWorkout(workout).Result;
            if(result != 0) 
                return Ok(result);
            return NotFound();
        }
        //Edit workout
        [HttpPut]
        public IActionResult EditWorkout([FromBody] WorkoutDTO workout)
        {
            var result = _workoutService.EditWorkout(workout).Result;
            if(result) 
                return Ok();
            return NotFound();
        }
    }
}
