using System.Collections.Generic;

namespace ETrainerWEB.Models
{
    public class ExerciseType
    {
        public ExerciseType()
        {
            Exercises = new List<Exercise>();
            ExerciseSchemas = new List<ExerciseSchema>();
        }
        public int Id { set; get; }
        public string Name { set; get; }
        public string Properties { set; get; }
        public virtual ICollection<Exercise> Exercises { get; set; }
        public virtual ICollection<ExerciseSchema> ExerciseSchemas { get; set; }

    }
}
