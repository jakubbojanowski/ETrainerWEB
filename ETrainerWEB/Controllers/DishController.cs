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
    public class DishController : ControllerBase
    {
        private readonly DishService _dishService;
        public DishController(DishService dishService)
        {
            _dishService = dishService;
        }
        //Get user's dishes
        [HttpGet]
        public async Task<IActionResult> Dish()
        {
            var result = await _dishService.GetDishes();
            if (result != null)
                return Ok(result);
            return NotFound();
        }
        //Add new dish
        [HttpPost]
        public async Task<IActionResult> Dish([FromBody] DishDTO dishDTO)
        {
            var result = await _dishService.AddDish(dishDTO);
            if (result != 0)
                return Ok(result);
            return NotFound();
        }
        //Edit dish
        [HttpPut]
        public async Task<IActionResult> EditDish([FromBody] DishDTO dishDTO)
        {
            var result = await _dishService.EditDish(dishDTO);
            if (result != 0)
                return Ok(result);
            return NotFound();
        }
        //Delete dish
        [HttpDelete("{dishId:int}")]
        public async Task<IActionResult> Dish([FromRoute] int dishId)
        {
            var result = await _dishService.DeleteDish(dishId);
            if (result)
                return Ok();
            return NotFound();
        }
        //Get ingredients for dish 
        [HttpGet("{dishId:int}")]
        public async Task<IActionResult> Ingredients([FromRoute] int dishId)
        {
            var result = await _dishService.GetDishesIngredients(dishId);
            if (result != null)
                return Ok(result);
            return NotFound();
        }
        //Add ingredient to dish
        [HttpPost]
        public async Task<IActionResult> AddIngredient([FromBody] DishesIngredientsDTO dishIngredientsDTO)
        {
            var result = await _dishService.AddIngredientToDish(dishIngredientsDTO);
            if (result)
                return Ok();
            return NotFound();
        }
        //Edit ingredient amount
        [HttpPut]
        public async Task<IActionResult> EditDishIngredient([FromBody] DishesIngredientsDTO dishesIngredientsDTO)
        {
            var result = await _dishService.EditDishIngredient(dishesIngredientsDTO);
            if (result)
                return Ok();
            return NotFound();
        }
        //Delete ingredient from dish
        [HttpDelete]
        public async Task<IActionResult> DeleteIngredient([FromQuery] int dishId,int ingredientId)
        {
            var result = await _dishService.DeleteIngredientFromDish(dishId, ingredientId);
            if (result)
                return Ok();
            return NotFound();
        }
    }
}
