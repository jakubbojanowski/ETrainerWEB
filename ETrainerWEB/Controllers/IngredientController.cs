using System;
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
    public class IngredientController : ControllerBase
    {
        private readonly IngredientService _ingredientService;
        public IngredientController(IngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }
        //Get meals by date
        [HttpGet]
        public async Task<IActionResult> Ingredient()
        {
            var result = await _ingredientService.GetIngredients();
            if (result != null)
                return Ok(result);
            return NotFound();
        }
        //Add new meal
        [HttpPost]
        public async Task<IActionResult> Ingredient([FromBody] IngredientDTO ingredientDTO)
        {
            var result = await _ingredientService.AddIngredient(ingredientDTO);
            if (result != 0)
                return Ok(result);
            return NotFound();
        }
        //Edit ingredient
        [HttpPut]
        public async Task<IActionResult> EditIngredient([FromBody] IngredientDTO ingredientDTO)
        {
            var result = await _ingredientService.EditIngredient(ingredientDTO);
            if (result != 0)
                return Ok(result);
            return NotFound();
        }
        //Delete ingredient
        [HttpDelete("{ingredientId:int}")]
        public async Task<IActionResult> Ingredient([FromRoute]int ingredientId)
        {
            var result = await _ingredientService.DeleteIngredient(ingredientId);
            if (result)
                return Ok();
            return NotFound();
        }
    }
}