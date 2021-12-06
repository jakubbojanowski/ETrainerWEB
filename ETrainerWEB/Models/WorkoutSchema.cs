using System.Collections.Generic;

namespace ETrainerWEB.Models
{
    public class WorkoutSchema
    {
        public WorkoutSchema()
        {
            WorkoutSchemasExercisesSchemas = new List<WorkoutSchemaExerciseSchema>();
        }
        public int Id { set; get; }
        public string Name{ set; get; }
        public User User { set; get; }
        public ICollection<WorkoutSchemaExerciseSchema> WorkoutSchemasExercisesSchemas { get; set; }
    }
}