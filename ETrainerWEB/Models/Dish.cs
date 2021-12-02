using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ETrainerWEB.Models
{
    public class Dish
    {
        public Dish()
        {
            MealsDishes = new List<MealsDishes>();
            DishesIngredients = new List<DishesIngredients>();
        }
        public int Id { set; get; }
        public string Name { set; get; }
        public float PortionWeight { set; get; }
        public float CaloricityPerGram { set; get; }
        public User User { set; get; }
        public ICollection<MealsDishes> MealsDishes { get; set; }
        public ICollection<DishesIngredients> DishesIngredients { get; set; }

    }
}
