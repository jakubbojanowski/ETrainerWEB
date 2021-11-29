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
        public IActionResult ExerciseSchemas()
        {
            var result = _exerciseSchemaService.GetExerciseSchemas().Result;
            if (result != null)
                return Ok(result);
            return NotFound();
        }
        //Add new exerciseSchema
        [HttpPost]
        public IActionResult ExerciseSchema([FromBody] ExerciseSchemaDTO exerciseSchema)
        {
            var result = _exerciseSchemaService.AddExerciseSchema(exerciseSchema).Result;
            if (result != 0)
                return Ok(result);
            return NotFound();
        }

        //Edit exerciseSchema
        [HttpPut]
        public IActionResult EditExerciseSchema([FromBody] ExerciseSchemaDTO exerciseSchema)
        {
            var result = _exerciseSchemaService.EditExerciseSchema(exerciseSchema).Result;
            if (result)
                return Ok();
            return NotFound();
        }
        //Delete exerciseSchema
        [HttpDelete("{exerciseSchemaId:int}")]
        public IActionResult DeleteExerciseSchema([FromRoute]int exerciseSchemaId)
        {
            var result = _exerciseSchemaService.DeleteExerciseSchema(exerciseSchemaId).Result;
            if (result)
                return Ok();
            return NotFound();
        }
    }
}
