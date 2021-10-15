using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETrainerWEB.Models
{
    public class User
    {
        public User()
        {
            Workouts = new List<Workout>();
            ExerciseSchemas = new List<ExerciseSchema>();
            WorkoutSchemas = new List<WorkoutSchema>();
            Meals = new List<Meal>();
            /*Friends = new List<Friends>();
            Friended = new List<Friends>();*/
            Measurement = new Measurement();
        }
        
        public int Id { set; get; }
        public string Login { set; get; }
        public string Password { set; get; }
        public string Email { set; get; }
        public DateTime DateOfBirth { set; get; }
        public string City { set; get; }
        public string Country { set; get; }
        public virtual ICollection<Workout> Workouts { get; set; }
        public virtual ICollection<ExerciseSchema> ExerciseSchemas { get; set; }
        public virtual ICollection<WorkoutSchema> WorkoutSchemas { get; set; }
        public virtual ICollection<Meal> Meals { get; set; }
        /*public virtual ICollection<Friends> Friends { get; set; }
        public virtual ICollection<Friends> Friended { get; set; }*/
        public virtual Measurement Measurement { get; set; }
    }
}