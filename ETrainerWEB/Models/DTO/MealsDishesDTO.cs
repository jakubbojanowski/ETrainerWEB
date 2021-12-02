using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ETrainerWEB.Models.DTO
{
    public class MealsDishesDTO
    {
        public int Id { set; get; }
        [JsonIgnore]
        public Meal Meal { set; get; }
        public int CurrentMealId { set; get; }
        [JsonIgnore]
        public Dish Dish { set; get; }
        public int CurrentDishId { set; get; }
        public double Amount { set; get; }
    }
}