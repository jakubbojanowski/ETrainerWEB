using System.Threading.Tasks;
using ETrainerWEB.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETrainerWEB.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[action]")]
    public class ExerciseTypeController : ControllerBase
    {
        private readonly ExerciseTypeService _exerciseTypeService;
        public ExerciseTypeController(ExerciseTypeService exerciseTypeService)
        {
            _exerciseTypeService = exerciseTypeService;
        }
        //Get all exercise types
        [HttpGet]
        public async Task<IActionResult> ExerciseTypes()
        {
            var result =  await _exerciseTypeService.GetExercisesType();
            if(result != null) 
                return Ok(result);
            return NotFound();
        } 
        //Get exerciseType by id 
        [HttpGet("{exerciseTypeId:int}")]
        public async Task<IActionResult> ExerciseType([FromRoute]int exerciseTypeId)
        {
            var result = await _exerciseTypeService.GetExerciseTypeById(exerciseTypeId);
            if(result != null)
                return Ok(result);
            return NotFound();
        }
        //Get all category
        [HttpGet]
        public IActionResult Categories()
        {
            var result =  ExerciseTypeService.GetCategories();
            if(result != null) 
                return Ok(result);
            return NotFound();
        } 
    }
}
