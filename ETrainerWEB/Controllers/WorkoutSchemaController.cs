using ETrainerWEB.Models;
using ETrainerWEB.Models.DTO;
using ETrainerWEB.Services;
using Microsoft.AspNetCore.Mvc;

namespace ETrainerWEB.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class WorkoutSchemaController : ControllerBase
    {
        private readonly WorkoutSchemaService _workoutSchemaService;
        public WorkoutSchemaController(WorkoutSchemaService workoutSchemaService)
        {
            _workoutSchemaService = workoutSchemaService;
        }
        //Get all workoutSchemas
        [HttpGet]
        public IActionResult WorkoutSchemas()
        {
            var result = _workoutSchemaService.GetWorkoutSchemas().Result;
            if (result != null)
                return Ok(result);
            return NotFound();
        }
        //Add new workoutSchema
        [HttpPost]
        public IActionResult WorkoutSchema([FromBody] WorkoutSchemaDTO workoutSchemaDTO)
        {
            var result = _workoutSchemaService.AddWorkoutSchema(workoutSchemaDTO).Result;
            if (result)
                return Ok();
            return NotFound();
        }

        //Edit workoutSchema
        [HttpPut]
        public IActionResult EditWorkoutSchema([FromBody] WorkoutSchemaDTO workoutSchemaDTO)
        {
            var result = _workoutSchemaService.EditWorkoutSchema(workoutSchemaDTO).Result;
            if (result)
                return Ok();
            return NotFound();
        }
        //Delete workoutSchema
        [HttpDelete("{workoutSchemaId:int}")]
        public IActionResult DeleteWorkoutSchema([FromRoute]int workoutSchemaId)
        {
            var result = _workoutSchemaService.DeleteWorkoutSchema(workoutSchemaId).Result;
            if (result)
                return Ok();
            return NotFound();
        }
        //Get exerciseSchemas for workoutSchema
        [HttpGet("{workoutId:int}")]
        public IActionResult ExerciseSchemas([FromRoute]int workoutId)
        {
            var result = _workoutSchemaService.GetExerciseSchema(workoutId).Result;
            if (result != null)
                return Ok(result);
            return NotFound();
        }
        //Add exerciseSchema to workoutSchema
        [HttpPost]
        public IActionResult AddExerciseSchema([FromBody] WorkoutSchemaExerciseSchemaDTO workoutSchemaExerciseSchemaDTO)
        {
            var result = _workoutSchemaService.AddExerciseSchemaToWorkoutSchema(workoutSchemaExerciseSchemaDTO).Result;
            if (result)
                return Ok();
            return NotFound();
        }
        //Delete exerciseSchema from workoutSchema
        [HttpDelete]
        public IActionResult DeleteExerciseSchema([FromQuery]int exerciseSchemaId)
        {
            var result = _workoutSchemaService.DeleteExerciseSchemaFromWorkoutSchema(exerciseSchemaId).Result;
            if (result)
                return Ok();
            return NotFound();
        }
    }
}