using System;
using ETrainerWEB.Data;
using ETrainerWEB.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using ETrainerWEB.Services;
using Microsoft.AspNetCore.Identity;

namespace ETrainerWEB.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class WorkoutController : ControllerBase
    {
        
        private readonly WorkoutService _workoutService;
        public WorkoutController(WorkoutService workoutService)
        {
            _workoutService = workoutService;
        }
        //Get all workouts
        [HttpGet]
        public IActionResult Workouts()
        {
            
            var result =  _workoutService.GetWorkouts().Result;
            if(result != null) 
                return Ok(result);
            return NotFound();
        }
        //Get user's workouts
        [HttpGet("{userId}")]
        public IActionResult UserWorkouts ([FromRoute]string userId)
        {
            var result =  _workoutService.GetUserWorkouts(userId).Result;
            if(result != null) 
                return Ok(result);
            return NotFound();
        }
        //Get workout by id 
        [HttpGet("{workoutId:int}")]
        public IActionResult Workout([FromRoute]int workoutId)
        {
            var result = _workoutService.GetWorkoutById(workoutId);
            if(result != null)
                return Ok(result);
            return NotFound();
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
            if(result) 
                return Ok();
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
