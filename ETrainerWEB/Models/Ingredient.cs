using System.Collections.Generic;

namespace ETrainerWEB.Models
{
    public class Ingredient
    {
        public Ingredient()
        {
            DishesIngredients = new List<DishesIngredients>();
        }
        public int Id { set; get; }
        public int UserId { set; get; }
        public string Name { set; get; }
        public float PortionWeight { set; get; }
        public float CaloricityPerGram { set; get; }
        public virtual ICollection<DishesIngredients> DishesIngredients { get; set; }

    }
}
