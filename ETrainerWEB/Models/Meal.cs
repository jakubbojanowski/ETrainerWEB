using System;
using System.Collections.Generic;

namespace ETrainerWEB.Models
{
    public class Meal
    {
        public Meal()
        {
            MealsDishes = new List<MealsDishes>();
        }
        public int Id { set; get; }
        public string UserId { set; get; }
        public DateTime Date { set; get; }
        public string Name { set; get; }
        public virtual ICollection<MealsDishes> MealsDishes { get; set; }
    }
}
