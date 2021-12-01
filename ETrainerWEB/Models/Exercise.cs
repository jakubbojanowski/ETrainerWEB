﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ETrainerWEB.Models
{
    public class Exercise
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Icon { set; get; }
        public string Properties { set; get; }
        [JsonIgnore]
        public Workout Workout { set; get; }
        [NotMapped] 
        public int CurrentWorkoutId { set; get; }
    }
}
