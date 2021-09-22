using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Trainer_WEB.Models
{
    public class Workout
    {
        public Workout()
        {
            Exercises = new List<Exercise>();
        }
        public int id { set; get; }
        public string name { set; get; }
        public int userId { set; get; }
        public int duration { set; get; }
        public virtual ICollection<Exercise> Exercises { get; set; }

    }
}
