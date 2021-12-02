using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ETrainerWEB.Models.DTO
{
    public class DishIngredientsDTO
    {
        public int Id { set; get; }
        [JsonIgnore]
        public Dish Dish  { set; get; }
        public int CurrentDishId { set; get; }
        [JsonIgnore]
        public Ingredient Ingredient { set; get; }
        public int CurrentIngredientId { set; get; }
        public int Amount { set; get; }
    }
}