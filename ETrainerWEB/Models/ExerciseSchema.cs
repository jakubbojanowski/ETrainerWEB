using System.Collections.Generic;

namespace ETrainerWEB.Models
{
    public class ExerciseSchema
    {
        public ExerciseSchema()
        {
            WorkoutSchemasExercisesSchemas = new List<WorkoutSchemaExerciseSchema>();
        }
        public int Id { set; get; }
        public string Name { set; get; }
        public string Icon { set; get; }
        public string Properties { set; get; }
        public User User { set; get; }
        public ICollection<WorkoutSchemaExerciseSchema> WorkoutSchemasExercisesSchemas { get; set; }
    }
}
