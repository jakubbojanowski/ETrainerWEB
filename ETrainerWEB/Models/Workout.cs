using System;
using System.Collections.Generic;


namespace ETrainerWEB.Models
{
    public class Workout
    {
        public Workout()
        {
            Exercises = new List<Exercise>();
        }
        public int Id { set; get; }
        public string Name { set; get; }
        public int UserId { set; get; }
        public DateTime Date { set; get; }
        public int Duration { set; get; }
        public virtual ICollection<Exercise> Exercises { get; set; }

    }
}
