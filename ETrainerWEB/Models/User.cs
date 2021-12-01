using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ETrainerWEB.Models
{
    public class User : IdentityUser
    {
        public DateTime DateOfBirth { set; get; }
        public string City { set; get; }
        public string Country { set; get; }
        public ICollection<Workout> Workouts { get; set; }
        public ICollection<ExerciseSchema> ExerciseSchemas { get; set; }
        public ICollection<WorkoutSchema> WorkoutSchemas { get; set; }
        public ICollection<Meal> Meals { get; set; }
        public Measurement Measurement { get; set; }
    }
}