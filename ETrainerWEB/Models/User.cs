using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
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
            /*Friends = new List<Friends>();
            Friended = new List<Friends>();*/
            
        }
        
        public DateTime DateOfBirth { set; get; }
        public string City { set; get; }
        public string Country { set; get; }
        public virtual ICollection<Workout> Workouts { get; set; }
        public virtual ICollection<ExerciseSchema> ExerciseSchemas { get; set; }
        public virtual ICollection<WorkoutSchema> WorkoutSchemas { get; set; }
        public virtual ICollection<Meal> Meals { get; set; }
        public virtual Measurement Measurement { get; set; }
        
        /*public virtual ICollection<Friends> Friends { get; set; }
        public virtual ICollection<Friends> Friended { get; set; }*/
        
    }
}