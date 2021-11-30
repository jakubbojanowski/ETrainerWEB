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
    public class MealController : ControllerBase
    {
        private readonly MealService _mealService;
        public MealController(MealService mealService)
        {
            _mealService = mealService;
        }
        //Get meals by date
        [HttpGet]
        public async Task<IActionResult> Meal([FromQuery] DateTime date)
        {
            var result = await _mealService.GetMealsByDate(date);
            if (result != null)
                return Ok(result);
            return NotFound();
        }
        //Add new meal
        [HttpPost]
        public async Task<IActionResult> Meal([FromBody] MealDTO mealDTO)
        {
            var result = await _mealService.AddMeal(mealDTO);
            if (result != 0)
                return Ok(result);
            return NotFound();
        }
        //Edit meal
        [HttpPut]
        public async Task<IActionResult> EditMeal([FromBody] MealDTO mealDTO)
        {
            var result = await _mealService.EditMeal(mealDTO);
            if (result != 0)
                return Ok(result);
            return NotFound();
        }
        //Delete meal
        [HttpDelete("{mealId:int}")]
        public async Task<IActionResult> Meal([FromRoute]int mealId)
        {
            var result = await _mealService.DeleteMeal(mealId);
            if (result)
                return Ok();
            return NotFound();
        }
        //Get dishes for meal 
        [HttpGet("{mealId:int}")]
        public async Task<IActionResult> Dishes([FromRoute] int mealId)
        {
            var result = await _mealService.GetMealsDishes(mealId);
            if (result != null)
                return Ok(result);
            return NotFound();
        }
        //Add dish to meal
        [HttpPost]
        public async Task<IActionResult> AddDish([FromBody] MealsDishesDTO mealsDishesDTO)
        {
            var result = await _mealService.AddDishToMeal(mealsDishesDTO);
            if (result)
                return Ok();
            return NotFound();
        }
        //Edit dish amount
        [HttpPut]
        public async Task<IActionResult> EditMealDishes([FromBody] MealsDishesDTO mealsDishesDTO)
        {
            var result = await _mealService.EditMealDishes(mealsDishesDTO);
            if (result)
                return Ok();
            return NotFound();
        }
        //Delete dish from meal
        [HttpDelete]
        public async Task<IActionResult> DeleteDish([FromQuery] int mealId,int dishId)
        {
            var result = await _mealService.DeleteDishFromMeal(mealId,dishId);
            if (result)
                return Ok();
            return NotFound();
        }
    }
}