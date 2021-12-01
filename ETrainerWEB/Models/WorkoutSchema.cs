using System.Collections.Generic;

namespace ETrainerWEB.Models
{
    public class WorkoutSchema
    { 
        public int Id { set; get; }
        public string Name{ set; get; }
        public string UserId { set; get; }
        public ICollection<WorkoutSchemaExerciseSchema> WorkoutSchemasExercisesSchemas { get; set; }
    }
}