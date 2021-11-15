using System.Collections.Generic;

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
        public string UserId { set; get; }
        public string Name { set; get; }
        public float PortionWeight { set; get; }
        public float CaloricityPerGram { set; get; }
        public virtual ICollection<MealsDishes> MealsDishes { get; set; }
        public virtual ICollection<DishesIngredients> DishesIngredients { get; set; }

    }
}
