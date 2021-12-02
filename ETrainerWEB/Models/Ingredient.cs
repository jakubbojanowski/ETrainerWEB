using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ETrainerWEB.Models
{
    public class Ingredient
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public float PortionWeight { set; get; }
        public float CaloricityPerGram { set; get; }
        public User User { set; get; }
        public ICollection<DishesIngredients> DishesIngredients { get; set; }
    }
}
