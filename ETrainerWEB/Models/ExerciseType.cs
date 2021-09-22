using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Trainer_WEB.Models
{
    public class ExerciseType
    {
        public ExerciseType()
        {
            Exercises = new List<Exercise>();
            ExerciseSchemas = new List<ExerciseSchema>();

        }
        public int id { set; get; }
        public string name { set; get; }
        public string properties { set; get; }

        public virtual ICollection<Exercise> Exercises { get; set; }
        public virtual ICollection<ExerciseSchema> ExerciseSchemas { get; set; }

    }
}
