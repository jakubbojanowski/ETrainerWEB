using System.Security.Claims;
using ETrainerWEB.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETrainerWEB.Controllers
{
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
        public IActionResult ExerciseTypes()
        {
            var result =  _exerciseTypeService.GetExercisesType().Result;
            if(result != null) 
                return Ok(result);
            return NotFound();
        } 
        //Get exerciseType by id 
        [HttpGet("{exerciseTypeId:int}")]
        public IActionResult ExerciseType([FromRoute]int exerciseTypeId)
        {
            var result = _exerciseTypeService.GetExerciseTypeById(exerciseTypeId);
            if(result != null)
                return Ok(result);
            return NotFound();
        }
        //Get all category
        [HttpGet]
        public IActionResult Categories()
        {
            var result =  _exerciseTypeService.GetCategories().Result;
            if(result != null) 
                return Ok(result);
            return NotFound();
        } 
    }
}
