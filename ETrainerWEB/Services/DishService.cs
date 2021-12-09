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
    public class DishService
    {
        private readonly ETrainerDbContext _db;
        private readonly PropertyCopierService<Dish> _propertyCopier;
        private readonly AutomapperService _automapper;
        private readonly string _userId;
        public DishService(ETrainerDbContext db,PropertyCopierService<Dish> propertyCopierService,AutomapperService automapperService,IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _propertyCopier = propertyCopierService;
            _automapper = automapperService;
            _userId  = _db.Users.Where(e => e.UserName == httpContextAccessor.HttpContext.User.Identity.Name).Select(r => r.Id).FirstOrDefault();
        }
        public async Task<List<DishDTO>> GetDishes()
        {
            if (string.IsNullOrEmpty(_userId)) return null;
            var dishes = await _db.Dishes.Where(c=> c.User.Id ==_userId || c.User.Id == null).ToListAsync();
            var dishesDTO= _automapper.Mapper.Map<List<Dish>, List<DishDTO>>(dishes);
            return dishesDTO;
        }
        public async Task<int> AddDish(DishDTO dishDTO)
        {
            if (string.IsNullOrEmpty(_userId)) return 0;
            dishDTO.User = await _db.Users.FirstOrDefaultAsync(e => e.Id == _userId);
            var exist = await _db.Dishes.FirstOrDefaultAsync(c => c.User.Id ==_userId && c.Name == dishDTO.Name && Math.Abs(c.PortionWeight - dishDTO.PortionWeight) < 0.1 && Math.Abs(c.CaloricityPerGram - dishDTO.CaloricityPerGram) < 0.1);
            if ( exist != null) return 0;
            var dish = _automapper.Mapper.Map<DishDTO,Dish>(dishDTO);
            await _db.Dishes.AddAsync(dish);
            await _db.SaveChangesAsync();
            return dish.Id;
        }
        public async Task<int> EditDish(DishDTO dishDTO)
        { 
            if (string.IsNullOrEmpty(_userId)) return 0;
            dishDTO.User = await _db.Users.FirstOrDefaultAsync(e => e.Id == _userId);
            var dish = await _db.Dishes.FirstOrDefaultAsync(c => c.User.Id ==_userId && c.Id == dishDTO.Id);
            if (dish == null) return 0;
            var updatedDish = _automapper.Mapper.Map<DishDTO, Dish>(dishDTO);
            _propertyCopier.Copy(updatedDish,dish);
            await _db.SaveChangesAsync();
            return dish.Id;
        }
        public async Task<bool> DeleteDish(int id)
        {
            if (string.IsNullOrEmpty(_userId)) return false;
            var dish = await _db.Dishes.FirstOrDefaultAsync(e =>e.User.Id == _userId && e.Id == id);
            if (dish == null) return false;
            _db.Dishes.Remove(dish);
            return await _db.SaveChangesAsync() > 0;
        }
        public async Task<List<IngredientDTO>> GetDishesIngredients(int dishId)
        {
            var ingredientsId = await _db.DishesIngredients.Where(w=> w.Dish.Id==dishId).Select(e=>e.Ingredient.Id).ToListAsync();
            var ingredients = await _db.Ingredients.Where(r =>(r.User.Id == _userId || r.User.Id == null) && ingredientsId.Contains(r.Id)).Include(e=>e.DishesIngredients).ToListAsync();
            var ingredientsDTO = _automapper.Mapper.Map<List<Ingredient>,List<IngredientDTO>>(ingredients);
            return ingredientsDTO;
        }
        public async Task<bool> AddIngredientToDish(DishesIngredientsDTO dishesIngredientsDTO)
        {
            var exist = await _db.DishesIngredients.FirstOrDefaultAsync(c => c.Dish.Id==dishesIngredientsDTO.CurrentDishId&&c.Ingredient.Id==dishesIngredientsDTO.CurrentIngredientId);
            if ( exist != null) return false;
            dishesIngredientsDTO.Dish = await _db.Dishes.FirstOrDefaultAsync(e => e.Id==dishesIngredientsDTO.CurrentDishId);
            dishesIngredientsDTO.Ingredient = await _db.Ingredients.FirstOrDefaultAsync(e => e.Id==dishesIngredientsDTO.CurrentIngredientId);
            var dishIngredient = _automapper.Mapper.Map<DishesIngredientsDTO,DishesIngredients>(dishesIngredientsDTO);
            await _db.DishesIngredients.AddAsync(dishIngredient);
            return await _db.SaveChangesAsync() > 0;
        }
        public async Task<bool> EditDishIngredient(DishesIngredientsDTO dishesIngredientsDTO)
        { 
            if (string.IsNullOrEmpty(_userId)) return false;
            dishesIngredientsDTO.Dish = await _db.Dishes.FirstOrDefaultAsync(e => e.Id==dishesIngredientsDTO.CurrentDishId);
            dishesIngredientsDTO.Ingredient = await _db.Ingredients.FirstOrDefaultAsync(e => e.Id==dishesIngredientsDTO.CurrentIngredientId);
            var dishIngredient = await _db.DishesIngredients.FirstOrDefaultAsync(c => c.Dish.Id ==dishesIngredientsDTO.CurrentDishId && c.Ingredient.Id == dishesIngredientsDTO.CurrentIngredientId);
            if (dishIngredient == null) return false;
            dishIngredient.Amount = dishesIngredientsDTO.Amount;
            return await _db.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteIngredientFromDish(int dishId,int ingredientId)
        {
            var dishIngredient = await _db.DishesIngredients.FirstOrDefaultAsync(e => e.Dish.Id ==dishId && e.Ingredient.Id == ingredientId);
            if (dishIngredient == null) return false;
            _db.DishesIngredients.Remove(dishIngredient);
            return await _db.SaveChangesAsync() > 0;
        }
        public async Task<double> GetAmount(int dishId,int ingredientId)
        {
            var amount = await _db.DishesIngredients.Where(w => w.Dish.Id == dishId && w.Ingredient.Id == ingredientId)
                .Select(e => e.Amount).FirstOrDefaultAsync();
            return amount;
        }
    }
}