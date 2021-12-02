using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ETrainerWEB.Models.DTO
{
    public class IngredientDTo
    {
        public int Id { set; get; }
        public string UserId { set; get; }
        public string Name { set; get; }
        public float PortionWeight { set; get; }
        public float CaloricityPerGram { set; get; }
        [JsonIgnore]
        public ICollection<DishesIngredients> DishesIngredients { get; set; }
    }
}