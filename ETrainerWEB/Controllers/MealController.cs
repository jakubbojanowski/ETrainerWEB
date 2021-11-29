using System;
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
        public IActionResult Meal([FromQuery] DateTime date)
        {
            var result = _mealService.GetMealsByDate(date);
            if (result != null)
                return Ok(result);
            return NotFound();
        }
        //Add new meal
        [HttpPost]
        public IActionResult Meal([FromBody] MealDTO mealDTO)
        {
            var result = _mealService.AddMeal(mealDTO).Result;
            if (result != 0)
                return Ok(result);
            return NotFound();
        }
        //Edit meal
        [HttpPut]
        public IActionResult EditMeal([FromBody] MealDTO mealDTO)
        {
            var result = _mealService.EditMeal(mealDTO).Result;
            if (result != 0)
                return Ok(result);
            return NotFound();
        }
        //Delete meal
        [HttpDelete("{mealId:int}")]
        public IActionResult Meal([FromRoute]int mealId)
        {
            var result = _mealService.DeleteMeal(mealId).Result;
            if (result)
                return Ok();
            return NotFound();
        }
        //Get dishes for meal 
        [HttpGet("{mealId:int}")]
        public IActionResult Dishes([FromRoute] int mealId)
        {
            var result = _mealService.GetMealsDishes(mealId);
            if (result != null)
                return Ok(result);
            return NotFound();
        }
        //Add dish to meal
        [HttpPost]
        public IActionResult AddDish([FromBody] MealsDishesDTO mealsDishesDTO)
        {
            var result = _mealService.AddDishToMeal(mealsDishesDTO).Result;
            if (result)
                return Ok();
            return NotFound();
        }
        //Edit dish amount
        [HttpPut]
        public IActionResult EditMealDishes([FromBody] MealsDishesDTO mealsDishesDTO)
        {
            var result = _mealService.EditMealDishes(mealsDishesDTO).Result;
            if (result)
                return Ok();
            return NotFound();
        }
        //Delete dish from meal
        [HttpDelete]
        public IActionResult DeleteDish([FromQuery] int mealId,int dishId)
        {
            var result = _mealService.DeleteDishFromMeal(mealId,dishId).Result;
            if (result)
                return Ok();
            return NotFound();
        }
    }
}