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
        //Get all exercise schemas
        [HttpGet]
        public IActionResult WorkoutSchemas()
        {
            var result = _workoutSchemaService.GetWorkoutSchemas().Result;
            if (result != null)
                return Ok(result);
            return NotFound();
        }
        //Add new exerciseSchema
        [HttpPost]
        public IActionResult WorkoutSchema([FromBody] WorkoutSchemaDTO workoutSchemaDTO)
        {
            var result = _workoutSchemaService.AddWorkoutSchema(workoutSchemaDTO).Result;
            if (result)
                return Ok();
            return NotFound();
        }

        //Edit exerciseSchema
        [HttpPut]
        public IActionResult EditWorkoutSchema([FromBody] WorkoutSchemaDTO workoutSchemaDTO)
        {
            var result = _workoutSchemaService.EditWorkoutSchema(workoutSchemaDTO).Result;
            if (result)
                return Ok();
            return NotFound();
        }
        //Delete exerciseSchema
        [HttpDelete("{workoutSchemaId:int}")]
        public IActionResult DeleteWorkoutSchema([FromRoute]int workoutSchemaId)
        {
            var result = _workoutSchemaService.DeleteWorkoutSchema(workoutSchemaId).Result;
            if (result)
                return Ok();
            return NotFound();
        }
    }
}