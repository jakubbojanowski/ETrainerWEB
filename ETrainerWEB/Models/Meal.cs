using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ETrainerWEB.Models
{
    public class Meal
    {
        public int Id { set; get; }
        public DateTime Date { set; get; }
        public string Name { set; get; }
        [JsonIgnore]
        public User User { set; get; }
        [JsonIgnore]
        public ICollection<MealsDishes> MealsDishes { get; set; }
    }
}
