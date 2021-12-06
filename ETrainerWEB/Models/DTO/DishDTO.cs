using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ETrainerWEB.Models.DTO
{
    public class DishDTO
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public double PortionWeight { set; get; }
        public double CaloricityPerGram { set; get; }
        [JsonIgnore]
        public User User { set; get; }
        [JsonIgnore]
        public  ICollection<MealsDishes> MealsDishes { get; set; }
        [JsonIgnore]
        public  ICollection<DishesIngredients> DishesIngredients { get; set; }
    }
}