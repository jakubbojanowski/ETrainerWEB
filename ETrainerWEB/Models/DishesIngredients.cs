using System.Text.Json.Serialization;

namespace ETrainerWEB.Models
{
    public class DishesIngredients
    {
        public int Id { set; get; }
        public Dish Dish  { set; get; }
        public int DishId { set; get; }
        public Ingredient Ingredient { set; get; }
        public int IngredientId { set; get; }
        public int Amount { set; get; }
    }
}