using ETrainerWEB.Models.DTO;
using ETrainerWEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace ETrainerWEB.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class ExerciseController : ControllerBase
    {
        private readonly ExerciseService _exerciseService;

        public ExerciseController(ExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        //Get all exercises
        [HttpGet]
        public IActionResult Exercises()
        {
            var result = _exerciseService.GetExercises().Result;
            if (result != null)
                return Ok(result);
            return NotFound();

        }
        //Get exercise by id 
        [HttpGet("{exerciseId:int}")]
        public IActionResult Exercise([FromRoute]int exerciseId)
        {
            var result = _exerciseService.GetExerciseById(exerciseId);
            if(result != null)
                return Ok(result);
            return NotFound();
        }
        //Add new exercise 
        [HttpPost]
        public IActionResult Exercise([FromBody()] ExerciseDTO exercise)
        {
            var result = _exerciseService.AddExercise(exercise).Result;
            if(result != 0) 
                return Ok(result);
            return NotFound();
        }

        //Edit exercise
        [HttpPut]
        public IActionResult EditExercise([FromBody] ExerciseDTO exercise)
        {
            var result = _exerciseService.EditExercise(exercise).Result;
            if (result)
                return Ok();
            return NotFound();
        }

        //Delete exercise
        [HttpDelete("{exerciseId:int}")]
        public IActionResult DeleteExercise([FromRoute]int exerciseId)
        {
            var result = _exerciseService.DeleteExercise(exerciseId).Result;
            if (result)
                return Ok();
            return NotFound();
        }
}
}
