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
    public class IngredientService
    {
        private readonly ETrainerDbContext _db;
        private readonly PropertyCopierService<Ingredient> _propertyCopier;
        private readonly AutomapperService _automapper;
        private readonly string _userId;
        
        public IngredientService(ETrainerDbContext db,PropertyCopierService<Ingredient> propertyCopierService,AutomapperService automapperService,IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _propertyCopier = propertyCopierService;
            _automapper = automapperService;
            _userId  = _db.Users.Where(e => e.UserName == httpContextAccessor.HttpContext.User.Identity.Name).Select(r => r.Id).FirstOrDefault();
        }
        public async Task<List<IngredientDTO>> GetIngredients()
        {
            if (string.IsNullOrEmpty(_userId)) return null;
            var ingredients = await _db.Ingredients.Where(c=> c.User.Id ==_userId || c.User.Id == null).ToListAsync();
            var ingredientsDTO= _automapper.Mapper.Map<List<Ingredient>, List<IngredientDTO>>(ingredients);
            return ingredientsDTO;
        }
        public async Task<int> AddIngredient(IngredientDTO ingredientDTO)
        {
            if (string.IsNullOrEmpty(_userId)) return 0;
            ingredientDTO.User = await _db.Users.FirstOrDefaultAsync(e => e.Id == _userId);
            var exist = await _db.Dishes.FirstOrDefaultAsync(c => c.User.Id ==_userId && c.Name == ingredientDTO.Name && Math.Abs(c.PortionWeight - ingredientDTO.PortionWeight) < 0.1 && Math.Abs(c.CaloricityPerGram - ingredientDTO.CaloricityPerGram) < 0.1);
            if ( exist != null) return 0;
            var ingredient = _automapper.Mapper.Map<IngredientDTO,Ingredient>(ingredientDTO);
            await _db.Ingredients.AddAsync(ingredient);
            await _db.SaveChangesAsync();
            return ingredient.Id;
        }
        public async Task<int> EditIngredient(IngredientDTO ingredientDTO)
        { 
            if (string.IsNullOrEmpty(_userId)) return 0;
            ingredientDTO.User = await _db.Users.FirstOrDefaultAsync(e => e.Id == _userId);
            var ingredient = await _db.Ingredients.FirstOrDefaultAsync(c => c.User.Id ==_userId && c.Id == ingredientDTO.Id);
            if (ingredient == null) return 0;
            var updatedIngredient = _automapper.Mapper.Map<IngredientDTO, Ingredient>(ingredientDTO);
            _propertyCopier.Copy(updatedIngredient,ingredient);
            await _db.SaveChangesAsync();
            return ingredient.Id;
        }
        public async Task<bool> DeleteIngredient(int id)
        {
            if (string.IsNullOrEmpty(_userId)) return false;
            var ingredient = await _db.Ingredients.FirstOrDefaultAsync(e =>e.User.Id == _userId && e.Id == id);
            if (ingredient == null) return false;
            _db.Ingredients.Remove(ingredient);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}