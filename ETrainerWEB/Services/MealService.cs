using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETrainerWEB.Data;
using ETrainerWEB.Models;
using ETrainerWEB.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ETrainerWEB.Services
{
    public class MealService
    {
        private readonly ETrainerDbContext _db;
        private readonly PropertyCopierService<Meal> _propertyCopier;
        private readonly AutomapperService _automapper;
        private readonly string _userId;
        public MealService(ETrainerDbContext db,PropertyCopierService<Meal> propertyCopierService,AutomapperService automapperService,IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _propertyCopier = propertyCopierService;
            _automapper = automapperService;
            _userId  = _db.Users.Where(e => e.UserName == httpContextAccessor.HttpContext.User.Identity.Name).Select(r => r.Id).FirstOrDefault();
        }
        public async Task<List<MealDTO>> GetMealsByDate(DateTime date)
        {
            if (string.IsNullOrEmpty(_userId)) return null;
            var meals = await _db.Meals.Where(e=>e.UserId == _userId).ToListAsync();
            var mealsDTO= _automapper.Mapper.Map<List<Meal>, List<MealDTO>>(meals);
            return mealsDTO;
        }
        public async Task<int> AddMeal(MealDTO mealDTO)
        {
            if (string.IsNullOrEmpty(_userId)) return 0;
            var exist = await _db.Meals.FirstOrDefaultAsync(c => c.UserId ==_userId && c.Name == mealDTO.Name && c.Date.Date == mealDTO.Date.Date);
            if ( exist != null) return 0;
            mealDTO.UserId = _userId;
            var meal = _automapper.Mapper.Map<MealDTO,Meal>(mealDTO);
            await _db.Meals.AddAsync(meal);
            await _db.SaveChangesAsync();
            return meal.Id;
        }
        public async Task<int> EditMeal(MealDTO mealDTO)
        { 
            if (string.IsNullOrEmpty(_userId)) return 0;
            var meal = await _db.Meals.FirstOrDefaultAsync(c => c.UserId ==_userId && c.Id == mealDTO.Id);
            if (meal == null) return 0;
            mealDTO.UserId = _userId;
            var updatedMeal = _automapper.Mapper.Map<MealDTO, Meal>(mealDTO);
            _propertyCopier.Copy(updatedMeal,meal);
            await _db.SaveChangesAsync();
            return meal.Id;
        }
        public async Task<bool> DeleteMeal(int id)
        {
            if (string.IsNullOrEmpty(_userId)) return false;
            var meal = await _db.Meals.FirstOrDefaultAsync(e =>e.UserId == _userId && e.Id == id);
            if (meal == null) return false;
            _db.Meals.Remove(meal);
            return await _db.SaveChangesAsync() > 0;
        }
        public async Task<List<DishDTO>> GetMealsDishes(int mealId)
        {
            var dishesId = await _db.MealsDishes.Where(w=> w.MealId==mealId).Select(e=>e.DishId).ToListAsync();
            var dishes = await _db.Dishes.Where(r =>r.UserId == _userId && dishesId.Contains(r.Id)).ToListAsync();
            var dishesDTO = _automapper.Mapper.Map<List<Dish>,List<DishDTO>>(dishes);
            return dishesDTO;
        }
        public async Task<bool> AddDishToMeal(MealsDishesDTO mealsDishesDTO)
        {
            var mealDish = _automapper.Mapper.Map<MealsDishesDTO,MealsDishes>(mealsDishesDTO);
            await _db.MealsDishes.AddAsync(mealDish);
            return await _db.SaveChangesAsync() > 0;
        }
        public async Task<bool> EditMealDishes(MealsDishesDTO mealsDishesDTO)
        { 
            if (string.IsNullOrEmpty(_userId)) return false;
            var meal = await _db.MealsDishes.FirstOrDefaultAsync(c => c.MealId ==mealsDishesDTO.MealId && c.DishId == mealsDishesDTO.DishId);
            if (meal == null) return false;
            meal.Amount = mealsDishesDTO.Amount;
            return await _db.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteDishFromMeal(int mealId,int dishId)
        {
            var mealDish = await _db.MealsDishes.FirstOrDefaultAsync(e => e.MealId ==mealId && e.DishId == dishId);
            if (mealDish == null) return false;
            _db.MealsDishes.Remove(mealDish);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}