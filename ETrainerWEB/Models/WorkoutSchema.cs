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
        public string UserId { set; get; }
        public virtual ICollection<WorkoutSchemaExerciseSchema> WorkoutSchemasExercisesSchemas { get; set; }
    }
}