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
    public class ExerciseSchemaController : ControllerBase
    {
        private readonly ExerciseSchemaService _exerciseSchemaService;
        public ExerciseSchemaController(ExerciseSchemaService exerciseSchemaService)
        {
            _exerciseSchemaService = exerciseSchemaService;
        }
        //Get all exercise schemas
        [HttpGet]
        public async Task<IActionResult> ExerciseSchemas()
        {
            var result = await _exerciseSchemaService.GetExerciseSchemas();
            if (result != null)
                return Ok(result);
            return NotFound();
        }
        //Add new exerciseSchema
        [HttpPost]
        public async Task<IActionResult> ExerciseSchema([FromBody] ExerciseSchemaDTO exerciseSchema)
        {
            var result = await _exerciseSchemaService.AddExerciseSchema(exerciseSchema);
            if (result != 0)
                return Ok(result);
            return NotFound();
        }
        //Edit exerciseSchema
        [HttpPut]
        public async Task<IActionResult> EditExerciseSchema([FromBody] ExerciseSchemaDTO exerciseSchema)
        {
            var result = await _exerciseSchemaService.EditExerciseSchema(exerciseSchema);
            if (result != 0)
                return Ok(result);
            return NotFound();
        }
        //Delete exerciseSchema
        [HttpDelete("{exerciseSchemaId:int}")]
        public async Task<IActionResult> DeleteExerciseSchema([FromRoute]int exerciseSchemaId)
        {
            var result = await _exerciseSchemaService.DeleteExerciseSchema(exerciseSchemaId);
            if (result)
                return Ok();
            return NotFound();
        }
    }
}
