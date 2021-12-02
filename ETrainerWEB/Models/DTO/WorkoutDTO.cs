using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ETrainerWEB.Models.DTO
{
    public class WorkoutDTO
    {   
        
        public int Id { set; get; }
        public DateTime Date { set; get; }
        [JsonIgnore]
        public User User { set; get; }
        public ICollection<ExerciseDTO> Exercises { get; set; }

    }
}