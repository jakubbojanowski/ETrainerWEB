using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ETrainerWEB.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            Workouts = new List<Workout>();
            ExerciseSchemas = new List<ExerciseSchema>();
            WorkoutSchemas = new List<WorkoutSchema>();
            Meals = new List<Meal>();
            Dishes = new List<Dish>();
            Ingredients = new List<Ingredient>();
            Measurements = new List<Measurement>();
        }
        public ICollection<Workout> Workouts { get; set; }
        public ICollection<ExerciseSchema> ExerciseSchemas { get; set; }
        public ICollection<WorkoutSchema> WorkoutSchemas { get; set; }
        public ICollection<Meal> Meals { get; set; }
        public ICollection<Dish> Dishes { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Measurement> Measurements { get; set; }
    }
}