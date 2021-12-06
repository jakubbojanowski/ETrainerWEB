using System.Collections.Generic;

namespace ETrainerWEB.Models
{
    public class Ingredient
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public double PortionWeight { set; get; }
        public double CaloricityPerGram { set; get; }
        public User User { set; get; }
        public ICollection<DishesIngredients> DishesIngredients { get; set; }
    }
}
