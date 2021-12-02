using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ETrainerWEB.Models
{
    public class Meal
    {
        public Meal()
        {
            MealsDishes = new List<MealsDishes>();
        }

        public int Id { set; get; }
        public DateTime Date { set; get; }
        public string Name { set; get; }
        public User User { set; get; }
        public ICollection<MealsDishes> MealsDishes { get; set; }
    }
}
