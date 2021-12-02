using System;
using System.Collections.Generic;

namespace ETrainerWEB.Models.DTO
{
    public class WorkoutDTO
    {   
        
        public int Id { set; get; } 
        public string Name { set; get; }
        public DateTime Date { set; get; }
        public User User { set; get; }
        public ICollection<ExerciseDTO> Exercises { get; set; }

    }
}