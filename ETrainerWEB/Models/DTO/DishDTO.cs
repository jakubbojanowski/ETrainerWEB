using System.Collections.Generic;

namespace ETrainerWEB.Models.DTO
{
    public class DishDTO
    {
        public int Id { set; get; }
        public string UserId { set; get; }
        public string Name { set; get; }
        public float PortionWeight { set; get; }
        public float CaloricityPerGram { set; get; }
        //public  ICollection<MealsDishes> MealsDishes { get; set; }
        //public  ICollection<DishesIngredients> DishesIngredients { get; set; }
    }
}