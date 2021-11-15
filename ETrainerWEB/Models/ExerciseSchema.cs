using System.Collections.Generic;

namespace ETrainerWEB.Models
{
    public class ExerciseSchema
    {
        public ExerciseSchema()
        {
            //WorkoutSchemasExercisesSchemas = new List<WorkoutSchemaExerciseSchema>();
        }

        public int Id { set; get; }
        public string Name { set; get; }
        public string UserId { set; get; }
        public int TypeId { set; get; }
        public string Properties { set; get; }
       // public virtual ICollection<WorkoutSchemaExerciseSchema> WorkoutSchemasExercisesSchemas { get; set; }
    }
}
