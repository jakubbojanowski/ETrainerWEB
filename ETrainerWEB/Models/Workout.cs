using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace ETrainerWEB.Models
{
    public class Workout
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public DateTime Date { set; get; }
        [JsonIgnore]
        public User User { set; get; }
        public ICollection<Exercise> Exercises { get; set; }

    }
}
