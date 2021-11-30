using System.Threading.Tasks;
using ETrainerWEB.Models;
using ETrainerWEB.Models.DTO;
using ETrainerWEB.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETrainerWEB.Controllers
{
    [Authorize] 
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
        public async Task<IActionResult> WorkoutSchemas()
        {
            var result = await _workoutSchemaService.GetWorkoutSchemas();
            if (result != null)
                return Ok(result);
            return NotFound();
        }
        //Add new workoutSchema
        [HttpPost]
        public async Task<IActionResult> WorkoutSchema([FromBody] WorkoutSchemaDTO workoutSchemaDTO)
        {
            var result = await _workoutSchemaService.AddWorkoutSchema(workoutSchemaDTO);
            if (result != 0)
                return Ok(result);
            return NotFound();
        }

        //Edit workoutSchema
        [HttpPut]
        public async Task<IActionResult> EditWorkoutSchema([FromBody] WorkoutSchemaDTO workoutSchemaDTO)
        {
            var result = await _workoutSchemaService.EditWorkoutSchema(workoutSchemaDTO);
            if (result != 0)
                return Ok(result);
            return NotFound();
        }
        //Delete workoutSchema
        [HttpDelete("{workoutSchemaId:int}")]
        public async Task<IActionResult> DeleteWorkoutSchema([FromRoute]int workoutSchemaId)
        {
            var result = await _workoutSchemaService.DeleteWorkoutSchema(workoutSchemaId);
            if (result)
                return Ok();
            return NotFound();
        }
        //Get exerciseSchemas for workoutSchema
        [HttpGet("{workoutId:int}")]
        public async Task<IActionResult> ExerciseSchemas([FromRoute]int workoutId)
        {
            var result = await _workoutSchemaService.GetExerciseSchema(workoutId);
            if (result != null)
                return Ok(result);
            return NotFound();
        }
        //Add exerciseSchema to workoutSchema
        [HttpPost]
        public async Task<IActionResult> AddExerciseSchema([FromBody] WorkoutSchemaExerciseSchemaDTO workoutSchemaExerciseSchemaDTO)
        {
            var result = await _workoutSchemaService.AddExerciseSchemaToWorkoutSchema(workoutSchemaExerciseSchemaDTO);
            if (result)
                return Ok();
            return NotFound();
        }
        //Delete exerciseSchema from workoutSchema
        [HttpDelete]
        public async Task<IActionResult> DeleteExerciseSchema([FromQuery]int workoutSchemaId,int exerciseSchemaId)
        {
            var result = await _workoutSchemaService.DeleteExerciseSchemaFromWorkoutSchema(workoutSchemaId,exerciseSchemaId);
            if (result)
                return Ok();
            return NotFound();
        }
    }
}