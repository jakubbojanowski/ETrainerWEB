using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ETrainerWEB.Models
{
    public class MealsDishes
    {
        public int Id { set; get; }
        public Meal Meal { set; get; }
        public int MealId { set; get; }
        public Dish Dish { set; get; }
        public int DishId { set; get; }
        public double Amount { set; get; }
    }
}